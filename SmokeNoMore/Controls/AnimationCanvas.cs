using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmokeNoMore.Controls
{
    public class AnimationCanvas : PictureBox
    {
        private List<Image> frames;

        public List<Image> Frames
        {
            get => frames; 
            set
            {
                frames = value;
                Image = frames?.First();
            }
        }
        private int CurrentFrame { get; set; }
        public int Duration { get; set; } = 1000;
        public int FPS { get; set; } = 12;
        private bool IsRunning { get; set; } = false;

        public event EventHandler AnimationEnd;

        public AnimationCanvas()
        {
            Cursor = Cursors.Hand;
            SizeMode = PictureBoxSizeMode.StretchImage;
            Size = new Size(128, 128);

            var timer = new System.Windows.Forms.Timer();
            timer.Interval = Duration / FPS;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        public void Start()
        {
            CurrentFrame = 0;
            Image = Frames[CurrentFrame];
            IsRunning = true;
        }

        public void Stop()
        {
            CurrentFrame = 0;
            Image = Frames[CurrentFrame];
            IsRunning = false;
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            if (IsRunning)
            {
                var count = Frames.Count();
                CurrentFrame = Math.Min(CurrentFrame + 1, count - 1);
                Image = Frames[CurrentFrame];

                if (CurrentFrame == count - 1)
                {
                    IsRunning = false;
                    AnimationEnd?.Invoke(this, new EventArgs());
                }
            }
        }
    }
}
