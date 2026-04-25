namespace Mod6
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            picDisplay = new PictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            tbDirection = new TrackBar();
            lblDirection = new TextBox();
            tbGraviton = new TrackBar();
            tbGraviton2 = new TrackBar();
            trackBarXOne = new TrackBar();
            trackBarYOne = new TrackBar();
            trackBarXTwo = new TrackBar();
            trackBarYTwo = new TrackBar();
            ((System.ComponentModel.ISupportInitialize)picDisplay).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbDirection).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbGraviton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbGraviton2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarXOne).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarYOne).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarXTwo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarYTwo).BeginInit();
            SuspendLayout();
            // 
            // picDisplay
            // 
            picDisplay.Location = new Point(12, 12);
            picDisplay.Name = "picDisplay";
            picDisplay.Size = new Size(940, 426);
            picDisplay.TabIndex = 0;
            picDisplay.TabStop = false;
            picDisplay.MouseClick += picDisplay_MouseClick;
            picDisplay.MouseMove += picDisplay_MouseMove;
            picDisplay.MouseWheel += PicDisplay_MouseWheel;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 40;
            timer1.Tick += timer1_Tick;
            // 
            // tbDirection
            // 
            tbDirection.Location = new Point(12, 444);
            tbDirection.Maximum = 359;
            tbDirection.Name = "tbDirection";
            tbDirection.Size = new Size(214, 45);
            tbDirection.TabIndex = 1;
            // 
            // lblDirection
            // 
            lblDirection.Location = new Point(232, 444);
            lblDirection.Name = "lblDirection";
            lblDirection.Size = new Size(29, 23);
            lblDirection.TabIndex = 2;
            // 
            // tbGraviton
            // 
            tbGraviton.Location = new Point(278, 444);
            tbGraviton.Maximum = 100;
            tbGraviton.Name = "tbGraviton";
            tbGraviton.Size = new Size(104, 45);
            tbGraviton.TabIndex = 3;
            // 
            // tbGraviton2
            // 
            tbGraviton2.Location = new Point(402, 444);
            tbGraviton2.Maximum = 100;
            tbGraviton2.Name = "tbGraviton2";
            tbGraviton2.Size = new Size(116, 45);
            tbGraviton2.TabIndex = 4;
            // 
            // trackBarXOne
            // 
            trackBarXOne.Location = new Point(577, 456);
            trackBarXOne.Maximum = 940;
            trackBarXOne.Name = "trackBarXOne";
            trackBarXOne.Size = new Size(104, 45);
            trackBarXOne.TabIndex = 5;
            trackBarXOne.Scroll += trackBarXOne_Scroll;
            // 
            // trackBarYOne
            // 
            trackBarYOne.Location = new Point(577, 507);
            trackBarYOne.Maximum = 426;
            trackBarYOne.Name = "trackBarYOne";
            trackBarYOne.Size = new Size(104, 45);
            trackBarYOne.TabIndex = 6;
            trackBarYOne.Scroll += trackBarYOne_Scroll;
            // 
            // trackBarXTwo
            // 
            trackBarXTwo.Location = new Point(715, 456);
            trackBarXTwo.Maximum = 940;
            trackBarXTwo.Name = "trackBarXTwo";
            trackBarXTwo.Size = new Size(104, 45);
            trackBarXTwo.TabIndex = 7;
            trackBarXTwo.Scroll += trackBarXTwo_Scroll;
            // 
            // trackBarYTwo
            // 
            trackBarYTwo.Location = new Point(715, 507);
            trackBarYTwo.Maximum = 426;
            trackBarYTwo.Name = "trackBarYTwo";
            trackBarYTwo.Size = new Size(104, 45);
            trackBarYTwo.TabIndex = 8;
            trackBarYTwo.Scroll += trackBarYTwo_Scroll;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(964, 564);
            Controls.Add(trackBarYTwo);
            Controls.Add(trackBarXTwo);
            Controls.Add(trackBarYOne);
            Controls.Add(trackBarXOne);
            Controls.Add(tbGraviton2);
            Controls.Add(tbGraviton);
            Controls.Add(lblDirection);
            Controls.Add(tbDirection);
            Controls.Add(picDisplay);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)picDisplay).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbDirection).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbGraviton).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbGraviton2).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarXOne).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarYOne).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarXTwo).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarYTwo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picDisplay;
        private System.Windows.Forms.Timer timer1;
        private TrackBar tbDirection;
        private TextBox lblDirection;
        private TrackBar tbGraviton;
        private TrackBar tbGraviton2;
        private TrackBar trackBarXOne;
        private TrackBar trackBarYOne;
        private TrackBar trackBarXTwo;
        private TrackBar trackBarYTwo;
    }
}
