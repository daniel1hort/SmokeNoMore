using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmokeNoMore.Controls
{
    public class LabelButton : Label
    {
        public LabelButton()
        {
            Font = new Font("Century", 12, FontStyle.Bold);
            ForeColor = Constants.ForeColor1;
            AutoSize = false;
            Size = new Size(110, 33);
            Cursor = Cursors.Hand;
            Margin = new Padding();
            Padding = new Padding(0, 5, 0, 5);
        }
    }
}
