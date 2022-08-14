namespace SmokeNoMore
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCountText = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblBtnHome = new SmokeNoMore.Controls.LabelButton();
            this.lblBtnStats = new SmokeNoMore.Controls.LabelButton();
            this.lblBtnSettings = new SmokeNoMore.Controls.LabelButton();
            this.myPanel1 = new SmokeNoMore.Controls.MyPanel();
            this.panelHome = new SmokeNoMore.Controls.MyPanel();
            this.lblAmount2 = new System.Windows.Forms.Label();
            this.lblAmount2Text = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblAmountText = new System.Windows.Forms.Label();
            this.lblCount2 = new System.Windows.Forms.Label();
            this.lblCount2Text = new System.Windows.Forms.Label();
            this.animationCanvas = new SmokeNoMore.Controls.AnimationCanvas();
            this.panelStats = new SmokeNoMore.Controls.MyPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDownloadData = new System.Windows.Forms.Button();
            this.plot = new ScottPlot.FormsPlot();
            this.panelSettings = new SmokeNoMore.Controls.MyPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.chkRunAtStartup = new System.Windows.Forms.CheckBox();
            this.myPanel1.SuspendLayout();
            this.panelHome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.animationCanvas)).BeginInit();
            this.panelStats.SuspendLayout();
            this.panelSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Century", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTitle.Location = new System.Drawing.Point(10, 10);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(267, 39);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Poison: Dunhill";
            // 
            // lblCountText
            // 
            this.lblCountText.AutoSize = true;
            this.lblCountText.Font = new System.Drawing.Font("Century", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCountText.ForeColor = System.Drawing.SystemColors.Control;
            this.lblCountText.Location = new System.Drawing.Point(10, 100);
            this.lblCountText.Name = "lblCountText";
            this.lblCountText.Size = new System.Drawing.Size(312, 21);
            this.lblCountText.TabIndex = 1;
            this.lblCountText.Text = "Cigs you have taken so far today: ";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Century", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(170)))), ((int)(((byte)(109)))));
            this.lblCount.Location = new System.Drawing.Point(328, 100);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(20, 21);
            this.lblCount.TabIndex = 2;
            this.lblCount.Text = "0";
            // 
            // lblBtnHome
            // 
            this.lblBtnHome.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBtnHome.ForeColor = System.Drawing.SystemColors.Control;
            this.lblBtnHome.Location = new System.Drawing.Point(0, 0);
            this.lblBtnHome.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.lblBtnHome.Name = "lblBtnHome";
            this.lblBtnHome.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.lblBtnHome.Size = new System.Drawing.Size(110, 33);
            this.lblBtnHome.TabIndex = 5;
            this.lblBtnHome.Text = "Home";
            // 
            // lblBtnStats
            // 
            this.lblBtnStats.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBtnStats.ForeColor = System.Drawing.SystemColors.Control;
            this.lblBtnStats.Location = new System.Drawing.Point(0, 33);
            this.lblBtnStats.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.lblBtnStats.Name = "lblBtnStats";
            this.lblBtnStats.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.lblBtnStats.Size = new System.Drawing.Size(110, 33);
            this.lblBtnStats.TabIndex = 6;
            this.lblBtnStats.Text = "Stats";
            // 
            // lblBtnSettings
            // 
            this.lblBtnSettings.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBtnSettings.ForeColor = System.Drawing.SystemColors.Control;
            this.lblBtnSettings.Location = new System.Drawing.Point(0, 66);
            this.lblBtnSettings.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.lblBtnSettings.Name = "lblBtnSettings";
            this.lblBtnSettings.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.lblBtnSettings.Size = new System.Drawing.Size(110, 33);
            this.lblBtnSettings.TabIndex = 7;
            this.lblBtnSettings.Text = "Settings";
            // 
            // myPanel1
            // 
            this.myPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(32)))), ((int)(((byte)(43)))));
            this.myPanel1.Controls.Add(this.lblBtnHome);
            this.myPanel1.Controls.Add(this.lblBtnSettings);
            this.myPanel1.Controls.Add(this.lblBtnStats);
            this.myPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.myPanel1.Location = new System.Drawing.Point(0, 0);
            this.myPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.myPanel1.Name = "myPanel1";
            this.myPanel1.Size = new System.Drawing.Size(110, 1005);
            this.myPanel1.TabIndex = 8;
            // 
            // panelHome
            // 
            this.panelHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(42)))), ((int)(((byte)(53)))));
            this.panelHome.Controls.Add(this.lblAmount2);
            this.panelHome.Controls.Add(this.lblAmount2Text);
            this.panelHome.Controls.Add(this.lblAmount);
            this.panelHome.Controls.Add(this.lblAmountText);
            this.panelHome.Controls.Add(this.lblCount2);
            this.panelHome.Controls.Add(this.lblCount2Text);
            this.panelHome.Controls.Add(this.animationCanvas);
            this.panelHome.Controls.Add(this.lblTitle);
            this.panelHome.Controls.Add(this.lblCountText);
            this.panelHome.Controls.Add(this.lblCount);
            this.panelHome.Location = new System.Drawing.Point(110, 0);
            this.panelHome.Margin = new System.Windows.Forms.Padding(0);
            this.panelHome.Name = "panelHome";
            this.panelHome.Size = new System.Drawing.Size(684, 453);
            this.panelHome.TabIndex = 9;
            // 
            // lblAmount2
            // 
            this.lblAmount2.AutoSize = true;
            this.lblAmount2.BackColor = System.Drawing.Color.Transparent;
            this.lblAmount2.Font = new System.Drawing.Font("Century", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAmount2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(170)))), ((int)(((byte)(109)))));
            this.lblAmount2.Location = new System.Drawing.Point(359, 220);
            this.lblAmount2.Name = "lblAmount2";
            this.lblAmount2.Size = new System.Drawing.Size(20, 21);
            this.lblAmount2.TabIndex = 14;
            this.lblAmount2.Text = "0";
            // 
            // lblAmount2Text
            // 
            this.lblAmount2Text.AutoSize = true;
            this.lblAmount2Text.Font = new System.Drawing.Font("Century", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAmount2Text.ForeColor = System.Drawing.SystemColors.Control;
            this.lblAmount2Text.Location = new System.Drawing.Point(10, 220);
            this.lblAmount2Text.Name = "lblAmount2Text";
            this.lblAmount2Text.Size = new System.Drawing.Size(343, 21);
            this.lblAmount2Text.TabIndex = 13;
            this.lblAmount2Text.Text = "Money spent on cigs this week so far:";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblAmount.Font = new System.Drawing.Font("Century", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(170)))), ((int)(((byte)(109)))));
            this.lblAmount.Location = new System.Drawing.Point(305, 180);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(20, 21);
            this.lblAmount.TabIndex = 12;
            this.lblAmount.Text = "0";
            // 
            // lblAmountText
            // 
            this.lblAmountText.AutoSize = true;
            this.lblAmountText.Font = new System.Drawing.Font("Century", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAmountText.ForeColor = System.Drawing.SystemColors.Control;
            this.lblAmountText.Location = new System.Drawing.Point(10, 180);
            this.lblAmountText.Name = "lblAmountText";
            this.lblAmountText.Size = new System.Drawing.Size(289, 21);
            this.lblAmountText.TabIndex = 9;
            this.lblAmountText.Text = "Money spent on cigs yesterday:";
            // 
            // lblCount2
            // 
            this.lblCount2.AutoSize = true;
            this.lblCount2.BackColor = System.Drawing.Color.Transparent;
            this.lblCount2.Font = new System.Drawing.Font("Century", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCount2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(170)))), ((int)(((byte)(109)))));
            this.lblCount2.Location = new System.Drawing.Point(303, 140);
            this.lblCount2.Name = "lblCount2";
            this.lblCount2.Size = new System.Drawing.Size(40, 21);
            this.lblCount2.TabIndex = 7;
            this.lblCount2.Text = "100";
            // 
            // lblCount2Text
            // 
            this.lblCount2Text.AutoSize = true;
            this.lblCount2Text.Font = new System.Drawing.Font("Century", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCount2Text.ForeColor = System.Drawing.SystemColors.Control;
            this.lblCount2Text.Location = new System.Drawing.Point(10, 140);
            this.lblCount2Text.Name = "lblCount2Text";
            this.lblCount2Text.Size = new System.Drawing.Size(287, 21);
            this.lblCount2Text.TabIndex = 6;
            this.lblCount2Text.Text = "Cigs you have taken yesterday:";
            // 
            // animationCanvas
            // 
            this.animationCanvas.Duration = 1000;
            this.animationCanvas.FPS = 12;
            this.animationCanvas.Frames = null;
            this.animationCanvas.Location = new System.Drawing.Point(507, 33);
            this.animationCanvas.Name = "animationCanvas";
            this.animationCanvas.Size = new System.Drawing.Size(128, 128);
            this.animationCanvas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.animationCanvas.TabIndex = 5;
            this.animationCanvas.TabStop = false;
            // 
            // panelStats
            // 
            this.panelStats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(42)))), ((int)(((byte)(53)))));
            this.panelStats.Controls.Add(this.label2);
            this.panelStats.Controls.Add(this.btnDownloadData);
            this.panelStats.Controls.Add(this.plot);
            this.panelStats.Location = new System.Drawing.Point(183, 506);
            this.panelStats.Name = "panelStats";
            this.panelStats.Size = new System.Drawing.Size(684, 453);
            this.panelStats.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(260, 397);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(265, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Download does not work yet!";
            // 
            // btnDownloadData
            // 
            this.btnDownloadData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(170)))), ((int)(((byte)(109)))));
            this.btnDownloadData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDownloadData.Enabled = false;
            this.btnDownloadData.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(32)))), ((int)(((byte)(43)))));
            this.btnDownloadData.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(32)))), ((int)(((byte)(43)))));
            this.btnDownloadData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(32)))), ((int)(((byte)(43)))));
            this.btnDownloadData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownloadData.Font = new System.Drawing.Font("Century", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDownloadData.Location = new System.Drawing.Point(33, 389);
            this.btnDownloadData.Name = "btnDownloadData";
            this.btnDownloadData.Size = new System.Drawing.Size(200, 35);
            this.btnDownloadData.TabIndex = 1;
            this.btnDownloadData.Text = "Download Data";
            this.btnDownloadData.UseVisualStyleBackColor = false;
            // 
            // plot
            // 
            this.plot.Dock = System.Windows.Forms.DockStyle.Top;
            this.plot.Location = new System.Drawing.Point(0, 0);
            this.plot.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.plot.Name = "plot";
            this.plot.Size = new System.Drawing.Size(684, 358);
            this.plot.TabIndex = 0;
            // 
            // panelSettings
            // 
            this.panelSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(42)))), ((int)(((byte)(53)))));
            this.panelSettings.Controls.Add(this.chkRunAtStartup);
            this.panelSettings.Controls.Add(this.txtUsername);
            this.panelSettings.Controls.Add(this.label3);
            this.panelSettings.Controls.Add(this.label1);
            this.panelSettings.Location = new System.Drawing.Point(1021, 24);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(684, 453);
            this.panelSettings.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(30, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 21);
            this.label1.TabIndex = 10;
            this.label1.Text = "Username";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(30, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 21);
            this.label3.TabIndex = 11;
            this.label3.Text = "Run at startup";
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Century", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtUsername.Location = new System.Drawing.Point(200, 38);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(224, 28);
            this.txtUsername.TabIndex = 12;
            // 
            // chkRunAtStartup
            // 
            this.chkRunAtStartup.AutoSize = true;
            this.chkRunAtStartup.Font = new System.Drawing.Font("Century", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkRunAtStartup.Location = new System.Drawing.Point(200, 80);
            this.chkRunAtStartup.Name = "chkRunAtStartup";
            this.chkRunAtStartup.Size = new System.Drawing.Size(18, 17);
            this.chkRunAtStartup.TabIndex = 13;
            this.chkRunAtStartup.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1924, 1005);
            this.Controls.Add(this.panelSettings);
            this.Controls.Add(this.panelStats);
            this.Controls.Add(this.panelHome);
            this.Controls.Add(this.myPanel1);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Smoke No More";
            this.myPanel1.ResumeLayout(false);
            this.panelHome.ResumeLayout(false);
            this.panelHome.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.animationCanvas)).EndInit();
            this.panelStats.ResumeLayout(false);
            this.panelStats.PerformLayout();
            this.panelSettings.ResumeLayout(false);
            this.panelSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Label lblTitle;
        private Label lblCountText;
        private Label lblCount;
        private Controls.LabelButton lblBtnHome;
        private Controls.LabelButton lblBtnStats;
        private Controls.LabelButton lblBtnSettings;
        private Controls.MyPanel myPanel1;
        private Controls.MyPanel panelHome;
        private Controls.MyPanel panelStats;
        private Controls.MyPanel panelSettings;
        private Controls.AnimationCanvas animationCanvas;
        private ScottPlot.FormsPlot plot;
        private Button btnDownloadData;
        private Label label2;
        private Label lblCount2Text;
        private Label lblCount2;
        private Label lblAmountText;
        private Label lblAmount;
        private Label lblAmount2Text;
        private Label lblAmount2;
        private Label label3;
        private Label label1;
        private TextBox txtUsername;
        private CheckBox chkRunAtStartup;
    }
}