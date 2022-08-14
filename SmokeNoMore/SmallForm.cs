using SmokeNoMore.Models;
using SqlKata.Compilers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SmokeNoMore.Domain.AppDomain;

namespace SmokeNoMore
{
    public partial class SmallForm : Form
    {
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ReleaseCapture();


        private Poison Poison { get; set; }
        private DbConnection Connection { get; set; }
        private Compiler Compiler { get; set; }

        public SmallForm(DbConnection connection, Compiler compiler, Poison poison, List<Image> frames)
        {
            InitializeComponent();

            TopLevel = true;
            TopMost = true;

            Poison = poison;
            Connection = connection;
            Compiler = compiler;
            animationCanvas.Frames = frames;
            animationCanvas.MouseDown += AnimationCanvas_MouseDown;
            animationCanvas.MouseUp += AnimationCanvas_MouseUp;
            animationCanvas.AnimationEnd += AnimationCanvas_AnimationEnd;
            MouseDown += SmallForm_MouseDown;
            MinimumSize = new Size(1, 1);
        }

        private void SmallForm_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void AnimationCanvas_AnimationEnd(object? sender, EventArgs e)
        {
            ConsumePoison(Connection, Compiler, Poison);

            var p1 = new Plus1();
            p1.Location = new Point(
                DesktopLocation.X + animationCanvas.Location.X + animationCanvas.Width / 2 - p1.Width / 2,
                DesktopLocation.Y + animationCanvas.Location.Y);
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
    }
}
