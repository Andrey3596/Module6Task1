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
            trackBarXOne = new TrackBar();
            trackBarYOne = new TrackBar();
            trackBarXTwo = new TrackBar();
            trackBarYTwo = new TrackBar();
            X = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            trackBarCol = new TrackBar();
            ((System.ComponentModel.ISupportInitialize)picDisplay).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarXOne).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarYOne).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarXTwo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarYTwo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarCol).BeginInit();
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
            // trackBarXOne
            // 
            trackBarXOne.Location = new Point(84, 444);
            trackBarXOne.Maximum = 940;
            trackBarXOne.Name = "trackBarXOne";
            trackBarXOne.Size = new Size(104, 45);
            trackBarXOne.TabIndex = 5;
            trackBarXOne.Scroll += trackBarXOne_Scroll;
            // 
            // trackBarYOne
            // 
            trackBarYOne.Location = new Point(84, 495);
            trackBarYOne.Maximum = 426;
            trackBarYOne.Name = "trackBarYOne";
            trackBarYOne.Size = new Size(104, 45);
            trackBarYOne.TabIndex = 6;
            trackBarYOne.Scroll += trackBarYOne_Scroll;
            // 
            // trackBarXTwo
            // 
            trackBarXTwo.Location = new Point(333, 444);
            trackBarXTwo.Maximum = 940;
            trackBarXTwo.Name = "trackBarXTwo";
            trackBarXTwo.Size = new Size(104, 45);
            trackBarXTwo.TabIndex = 7;
            trackBarXTwo.Scroll += trackBarXTwo_Scroll;
            // 
            // trackBarYTwo
            // 
            trackBarYTwo.Location = new Point(333, 495);
            trackBarYTwo.Maximum = 426;
            trackBarYTwo.Name = "trackBarYTwo";
            trackBarYTwo.Size = new Size(104, 45);
            trackBarYTwo.TabIndex = 8;
            trackBarYTwo.Scroll += trackBarYTwo_Scroll;
            // 
            // X
            // 
            X.AutoSize = true;
            X.Location = new Point(64, 444);
            X.Name = "X";
            X.Size = new Size(14, 15);
            X.TabIndex = 9;
            X.Text = "X";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(64, 503);
            label1.Name = "label1";
            label1.Size = new Size(14, 15);
            label1.TabIndex = 10;
            label1.Text = "Y";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(313, 444);
            label2.Name = "label2";
            label2.Size = new Size(14, 15);
            label2.TabIndex = 11;
            label2.Text = "X";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(313, 495);
            label3.Name = "label3";
            label3.Size = new Size(14, 15);
            label3.TabIndex = 12;
            label3.Text = "Y";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(96, 525);
            label4.Name = "label4";
            label4.Size = new Size(78, 15);
            label4.TabIndex = 13;
            label4.Text = "Первый круг";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(347, 525);
            label5.Name = "label5";
            label5.Size = new Size(74, 15);
            label5.TabIndex = 14;
            label5.Text = "Второй круг";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(486, 444);
            label6.Name = "label6";
            label6.Size = new Size(95, 15);
            label6.TabIndex = 15;
            label6.Text = "Сколько частиц";
            // 
            // trackBarCol
            // 
            trackBarCol.Location = new Point(580, 444);
            trackBarCol.Maximum = 1000;
            trackBarCol.Name = "trackBarCol";
            trackBarCol.Size = new Size(104, 45);
            trackBarCol.TabIndex = 16;
            trackBarCol.Value = 500;
            trackBarCol.Scroll += trackBarCol_Scroll;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(964, 564);
            Controls.Add(trackBarCol);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(X);
            Controls.Add(trackBarYTwo);
            Controls.Add(trackBarXTwo);
            Controls.Add(trackBarYOne);
            Controls.Add(trackBarXOne);
            Controls.Add(picDisplay);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)picDisplay).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarXOne).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarYOne).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarXTwo).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarYTwo).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarCol).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picDisplay;
        private System.Windows.Forms.Timer timer1;
        private TrackBar trackBarXOne;
        private TrackBar trackBarYOne;
        private TrackBar trackBarXTwo;
        private TrackBar trackBarYTwo;
        private Label X;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TrackBar trackBarCol;
    }
}
