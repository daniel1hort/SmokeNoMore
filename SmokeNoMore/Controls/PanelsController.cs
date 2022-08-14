using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmokeNoMore.Controls
{
    public class PanelsController
    {
        private readonly List<(Label, Panel)> Pages;
        private Label? activeLabel;

        public PanelsController()
        {
            Pages = new List<(Label, Panel)>();
        }

        public void AddPanel(Label label, Panel panel)
        {
            Pages.Add((label, panel));
            panel.Dock = DockStyle.Fill;
            label.Click += Label_Click;
            label.MouseEnter += Label_MouseEnter;
            label.MouseLeave += Label_MouseLeave;
            activeLabel = label;
            RefreshStyle();
        }

        private void Label_MouseLeave(object? sender, EventArgs e)
        {
            if(!(sender == activeLabel))
            {
                var label = sender as Label;
                label.BackColor = Constants.BackColor2;
            }
        }

        private void Label_MouseEnter(object? sender, EventArgs e)
        {
            var label = sender as Label;
            label.BackColor = Constants.BackColor3;
        }

        private void Label_Click(object? sender, EventArgs e)
        {
            var label = sender as Label;
            activeLabel = label;
            RefreshStyle();
        }

        private void RefreshStyle()
        {
            var page = Pages.First(a => a.Item1 == activeLabel);
            page.Item1.BackColor = Constants.BackColor3;
            page.Item2.BringToFront();
            Pages.Where(a => a.Item1 != activeLabel).ToList().ForEach(a
                => a.Item1.BackColor = Constants.BackColor2);
        }
    }
}
