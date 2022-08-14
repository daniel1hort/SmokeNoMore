using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmokeNoMore
{
    public partial class Plus1 : Form
    {
        private int Tick = 0;

        public Plus1()
        {
            InitializeComponent();
            TransparencyKey = Color.Brown;
            TopMost = true;
            TopLevel = true;

            var timer = new System.Windows.Forms.Timer();
            timer.Interval = 50;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            Location = new Point(Location.X, Location.Y - 5);
            if(Tick++ == 20)
                Close();
        }
    }
}
