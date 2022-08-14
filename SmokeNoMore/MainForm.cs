using Microsoft.Data.Sqlite;
using SqlKata;
using Dapper;
using SqlKata.Compilers;
using SmokeNoMore.Tools;
using SmokeNoMore.Models;
using static SmokeNoMore.Domain.AppDomain;
using System.Data.Common;
using ScottPlot;
using SmokeNoMore.Controls;

namespace SmokeNoMore
{
    public partial class MainForm : Form
    {
        private readonly NotifyIcon notifyIcon;
        private readonly SmallForm smallForm;

        private Poison Dunhill { get; set; }
        private Models.Settings Settings { get; set; }
        private DbConnection Connection { get; set; }
        private Compiler Compiler { get; set; }

        private readonly List<Image> CigAnimation;

        public MainForm()
        {
            InitializeComponent();

            CigAnimation = Directory.GetFiles("Resources/Animations/CigSmoke")
                .Select(a => Image.FromFile(a)).ToList();

            const string dataFilePath = "Resources/Data/smokenomore.sqlite";
            Connection = new SqliteConnection($"Data Source={dataFilePath}");
            Compiler = new SqliteCompiler();

            if (!File.Exists(dataFilePath))
            {
                var directory = Path.GetDirectoryName(dataFilePath);
                Directory.CreateDirectory(directory);
                File.OpenWrite(dataFilePath).Dispose();
            }

            try { Settings = GetSettings(Connection, Compiler); }
            catch { Settings = null; }
            if (Settings is null)
            {
                new CreateSchemaIfNotExists(Connection, Compiler).Execute();
                new PopulateSchema(Connection, Compiler).Execute();
                Settings = GetSettings(Connection, Compiler);
            }

            if (Settings.LastAccess is null) // first time access
            {
                Settings.LastAccess = DateTime.Now;
                UpdateSettings(Connection, Compiler, Settings);
            }

            txtUsername.Text = Settings.Username;
            chkRunAtStartup.Checked = RunAtStartupHelper.IsInStartup();
            txtUsername.TextChanged += TxtUsername_TextChanged;
            chkRunAtStartup.CheckedChanged += ChkRunAtStartup_CheckedChanged;

            Dunhill = GetPoisons(Connection, Compiler).First();
            var count = GetCunsumptionsCount(Connection, Compiler,
                DateTime.Now.Date, DateTime.Now.Date.AddDays(1), Dunhill);
            var stats = GetDayStatsForPoison(Connection, Compiler,
                DateTime.Now.Date.AddDays(-1), Dunhill);
            var stats2 = GetWeekStatsForPoison(Connection, Compiler,
                DateTime.Now.Date, Dunhill);

            Size = new Size(800, 500);
            lblTitle.Text = $"Poison: {Dunhill.Name}";
            lblCountText.Text = $"{Capitalize(Dunhill.ItemName)}s you have taken so far today:";
            lblCount.Text = count.ToString();
            lblCount2Text.Text = $"{Capitalize(Dunhill.ItemName)}s you have taken yesterday:";
            lblCount2.Text = stats.Count.ToString();
            lblAmountText.Text = $"Money spent on {Dunhill.ItemName}s yesterday:";
            lblAmount.Text = ((decimal)stats.Count / Dunhill.Quantity * Dunhill.ActualPrice).ToString("0.00");
            lblAmount2Text.Text = $"Money spent on {Dunhill.ItemName}s this week so far:";
            lblAmount2.Text = ((decimal)stats2 / Dunhill.Quantity * Dunhill.ActualPrice).ToString("0.00");

            animationCanvas.Frames = CigAnimation;
            animationCanvas.MouseDown += AnimationCanvas_MouseDown;
            animationCanvas.MouseUp += AnimationCanvas_MouseUp;
            animationCanvas.AnimationEnd += AnimationCanvas_AnimationEnd;

            var controller = new PanelsController();
            controller.AddPanel(lblBtnStats, panelStats);
            controller.AddPanel(lblBtnSettings, panelSettings);
            controller.AddPanel(lblBtnHome, panelHome);
            lblBtnStats.Click += LblBtnStats_Click;

            RefreshPlot();

            var menuItem = new ToolStripMenuItem("Exit");
            menuItem.Click += MenuItem_Click;
            var contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add(menuItem);
            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = StaticResources.no_smoking;
            notifyIcon.ContextMenuStrip = contextMenu;
            notifyIcon.Visible = true;
            notifyIcon.DoubleClick += NotifyIcon_DoubleClick;
            Icon = StaticResources.no_smoking;

            smallForm = new SmallForm(Connection, Compiler, Dunhill, CigAnimation);
            smallForm.Hide();

            this.FormClosing += MainForm_FormClosing;
        }

        private void LblBtnStats_Click(object? sender, EventArgs e)
        {
            RefreshPlot();
        }

        private void ChkRunAtStartup_CheckedChanged(object? sender, EventArgs e)
        {
            if (RunAtStartupHelper.IsInStartup())
                RunAtStartupHelper.RemoveFromStartup();
            else
                RunAtStartupHelper.RunOnStartup();
        }

        private void TxtUsername_TextChanged(object? sender, EventArgs e)
        {
            Settings.Username = txtUsername.Text;
            UpdateSettings(Connection, Compiler, Settings);
        }

        private void NotifyIcon_DoubleClick(object? sender, EventArgs e)
        {
            smallForm.Hide();
            Show();
        }

        private void MenuItem_Click(object? sender, EventArgs e)
        {
            notifyIcon.Visible = false;
            notifyIcon.Dispose();
            Application.Exit();
        }

        private void MainForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                smallForm.Show();
                Hide();
            }
        }

        private void AnimationCanvas_AnimationEnd(object? sender, EventArgs e)
        {
            ConsumePoison(Connection, Compiler, Dunhill);
            RefreshData();

            var p1 = new Plus1();
            p1.Location = new Point(
                DesktopLocation.X + panelHome.Location.X + animationCanvas.Location.X + animationCanvas.Width / 2 - p1.Width / 2,
                DesktopLocation.Y + panelHome.Location.Y + animationCanvas.Location.Y);
            p1.Show();
        }

        private void AnimationCanvas_MouseUp(object? sender, MouseEventArgs e)
        {
            animationCanvas.Stop();
        }

        private void AnimationCanvas_MouseDown(object? sender, MouseEventArgs e)
        {
            animationCanvas.Start();
        }

        private void RefreshPlot()
        {
            var statsData = GetStatsForPoison(Connection, Compiler,
                DateTime.Now.Date.AddDays(-9),
                DateTime.Now.Date.AddDays(1),
                Dunhill);
            var xs = statsData.Select(a => a.Date.ToOADate()).ToArray();
            var ys = statsData.Select(a => (double)a.Count).ToArray();
            plot.Reset();
            var barPlot = plot.Plot.AddBar(ys, xs);
            barPlot.ShowValuesAboveBars = true;
            barPlot.Font.Color = SystemColors.Control;
            plot.Plot.XAxis.DateTimeFormat(true);
            plot.Plot.XAxis.Label("Last 10 days (including today)");
            plot.Plot.YAxis.Label($"{Capitalize(Dunhill.ItemName)}s taken");
            plot.Plot.Style(new ScottPlot.Styles.Gray1());
            plot.Plot.SetAxisLimits(barPlot.GetAxisLimits());
            plot.Plot.XAxis.LockLimits(true);
            plot.Plot.YAxis.LockLimits(true);
            plot.Refresh();
        }

        private void RefreshData()
        {
            var count = GetCunsumptionsCount(Connection, Compiler,
                DateTime.Now.Date, DateTime.Now.Date.AddDays(1), Dunhill);
            var stats = GetDayStatsForPoison(Connection, Compiler,
                DateTime.Now.Date.AddDays(-1), Dunhill);
            var stats2 = GetWeekStatsForPoison(Connection, Compiler,
                DateTime.Now.Date, Dunhill);

            lblCount.Text = count.ToString();
            lblAmount.Text = ((decimal)stats.Count / Dunhill.Quantity * Dunhill.ActualPrice).ToString("0.00");
            lblAmount2.Text = ((decimal)stats2 / Dunhill.Quantity * Dunhill.ActualPrice).ToString("0.00");
        }

        public string Capitalize(string str) 
            => str.Substring(0, 1).ToUpper() + str.Substring(1);
    }
}