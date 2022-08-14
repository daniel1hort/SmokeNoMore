namespace SmokeNoMore
{
    partial class SmallForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.animationCanvas = new SmokeNoMore.Controls.AnimationCanvas();
            ((System.ComponentModel.ISupportInitialize)(this.animationCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // animationCanvas
            // 
            this.animationCanvas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.animationCanvas.Duration = 1000;
            this.animationCanvas.FPS = 12;
            this.animationCanvas.Frames = null;
            this.animationCanvas.Location = new System.Drawing.Point(0, 32);
            this.animationCanvas.Name = "animationCanvas";
            this.animationCanvas.Size = new System.Drawing.Size(128, 128);
            this.animationCanvas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.animationCanvas.TabIndex = 0;
            this.animationCanvas.TabStop = false;
            // 
            // SmallForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(42)))), ((int)(((byte)(53)))));
            this.ClientSize = new System.Drawing.Size(128, 160);
            this.Controls.Add(this.animationCanvas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SmallForm";
            this.Text = "SmallForm";
            ((System.ComponentModel.ISupportInitialize)(this.animationCanvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.AnimationCanvas animationCanvas;
    }
}