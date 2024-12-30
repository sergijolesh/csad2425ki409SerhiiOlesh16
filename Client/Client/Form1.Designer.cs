namespace Client
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
            btnRockOne = new Button();
            lblClientScore = new Label();
            lblServerScore = new Label();
            btnPaperOne = new Button();
            btnScissorsOne = new Button();
            lblMessage = new Label();
            imgPlayerOneMove = new PictureBox();
            label1 = new Label();
            imgPlayerTwoMove = new PictureBox();
            btnRockTwo = new Button();
            btnPaperTwo = new Button();
            btnScissorsTwo = new Button();
            btnConfig = new Button();
            btnShow = new Button();
            ((System.ComponentModel.ISupportInitialize)imgPlayerOneMove).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imgPlayerTwoMove).BeginInit();
            SuspendLayout();
            // 
            // btnRockOne
            // 
            btnRockOne.BackgroundImage = Properties.Resources.rock;
            btnRockOne.BackgroundImageLayout = ImageLayout.Center;
            btnRockOne.Location = new Point(10, 121);
            btnRockOne.Name = "btnRockOne";
            btnRockOne.Size = new Size(50, 50);
            btnRockOne.TabIndex = 1;
            btnRockOne.UseVisualStyleBackColor = true;
            btnRockOne.Click += btnRockOne_Click;
            // 
            // lblClientScore
            // 
            lblClientScore.AutoSize = true;
            lblClientScore.Font = new Font("Segoe UI", 13.8F);
            lblClientScore.Location = new Point(358, 10);
            lblClientScore.Name = "lblClientScore";
            lblClientScore.Size = new Size(26, 31);
            lblClientScore.TabIndex = 3;
            lblClientScore.Text = "0";
            // 
            // lblServerScore
            // 
            lblServerScore.AutoSize = true;
            lblServerScore.Font = new Font("Segoe UI", 13.8F);
            lblServerScore.Location = new Point(395, 10);
            lblServerScore.Name = "lblServerScore";
            lblServerScore.Size = new Size(26, 31);
            lblServerScore.TabIndex = 4;
            lblServerScore.Text = "0";
            // 
            // btnPaperOne
            // 
            btnPaperOne.BackgroundImage = Properties.Resources.paper1;
            btnPaperOne.BackgroundImageLayout = ImageLayout.Center;
            btnPaperOne.Location = new Point(10, 188);
            btnPaperOne.Name = "btnPaperOne";
            btnPaperOne.Size = new Size(50, 50);
            btnPaperOne.TabIndex = 5;
            btnPaperOne.UseVisualStyleBackColor = true;
            btnPaperOne.Click += btnPaperOne_Click;
            // 
            // btnScissorsOne
            // 
            btnScissorsOne.BackgroundImage = Properties.Resources.scissors;
            btnScissorsOne.BackgroundImageLayout = ImageLayout.Center;
            btnScissorsOne.Location = new Point(10, 254);
            btnScissorsOne.Name = "btnScissorsOne";
            btnScissorsOne.Size = new Size(50, 50);
            btnScissorsOne.TabIndex = 6;
            btnScissorsOne.UseVisualStyleBackColor = true;
            btnScissorsOne.Click += btnScissorsOne_Click;
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblMessage.Location = new Point(275, 188);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(218, 60);
            lblMessage.TabIndex = 9;
            lblMessage.Text = "Let's play!";
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // imgPlayerOneMove
            // 
            imgPlayerOneMove.Location = new Point(150, 121);
            imgPlayerOneMove.Name = "imgPlayerOneMove";
            imgPlayerOneMove.Size = new Size(183, 183);
            imgPlayerOneMove.TabIndex = 10;
            imgPlayerOneMove.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F);
            label1.Location = new Point(377, 10);
            label1.Name = "label1";
            label1.Size = new Size(23, 31);
            label1.TabIndex = 11;
            label1.Text = "-";
            // 
            // imgPlayerTwoMove
            // 
            imgPlayerTwoMove.Location = new Point(439, 121);
            imgPlayerTwoMove.Name = "imgPlayerTwoMove";
            imgPlayerTwoMove.Size = new Size(183, 183);
            imgPlayerTwoMove.TabIndex = 12;
            imgPlayerTwoMove.TabStop = false;
            // 
            // btnRockTwo
            // 
            btnRockTwo.BackgroundImage = Properties.Resources.rock;
            btnRockTwo.BackgroundImageLayout = ImageLayout.Center;
            btnRockTwo.Location = new Point(722, 121);
            btnRockTwo.Name = "btnRockTwo";
            btnRockTwo.Size = new Size(50, 50);
            btnRockTwo.TabIndex = 13;
            btnRockTwo.UseVisualStyleBackColor = true;
            btnRockTwo.Click += btnRockTwo_Click;
            // 
            // btnPaperTwo
            // 
            btnPaperTwo.BackgroundImage = Properties.Resources.paper1;
            btnPaperTwo.BackgroundImageLayout = ImageLayout.Center;
            btnPaperTwo.Location = new Point(722, 188);
            btnPaperTwo.Name = "btnPaperTwo";
            btnPaperTwo.Size = new Size(50, 50);
            btnPaperTwo.TabIndex = 14;
            btnPaperTwo.UseVisualStyleBackColor = true;
            btnPaperTwo.Click += btnPaperTwo_Click;
            // 
            // btnScissorsTwo
            // 
            btnScissorsTwo.BackgroundImage = Properties.Resources.scissors;
            btnScissorsTwo.BackgroundImageLayout = ImageLayout.Center;
            btnScissorsTwo.Location = new Point(722, 254);
            btnScissorsTwo.Name = "btnScissorsTwo";
            btnScissorsTwo.Size = new Size(50, 50);
            btnScissorsTwo.TabIndex = 15;
            btnScissorsTwo.UseVisualStyleBackColor = true;
            btnScissorsTwo.Click += btnScissorsTwo_Click;
            // 
            // btnConfig
            // 
            btnConfig.Location = new Point(331, 44);
            btnConfig.Name = "btnConfig";
            btnConfig.Size = new Size(116, 29);
            btnConfig.TabIndex = 16;
            btnConfig.Text = "Configuration";
            btnConfig.UseVisualStyleBackColor = true;
            btnConfig.Click += btnConfig_Click;
            // 
            // btnShow
            // 
            btnShow.Location = new Point(331, 393);
            btnShow.Name = "btnShow";
            btnShow.Size = new Size(116, 29);
            btnShow.TabIndex = 17;
            btnShow.Text = "Show";
            btnShow.UseVisualStyleBackColor = true;
            btnShow.Click += btnShow_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 453);
            Controls.Add(btnShow);
            Controls.Add(btnConfig);
            Controls.Add(lblMessage);
            Controls.Add(btnScissorsTwo);
            Controls.Add(btnPaperTwo);
            Controls.Add(btnRockTwo);
            Controls.Add(imgPlayerTwoMove);
            Controls.Add(label1);
            Controls.Add(imgPlayerOneMove);
            Controls.Add(btnScissorsOne);
            Controls.Add(btnPaperOne);
            Controls.Add(lblServerScore);
            Controls.Add(lblClientScore);
            Controls.Add(btnRockOne);
            Name = "Form1";
            Text = "Rock Paper Scissors";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)imgPlayerOneMove).EndInit();
            ((System.ComponentModel.ISupportInitialize)imgPlayerTwoMove).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Button btnRockTwo;
        private Button btnPaperTwo;
        private Button btnScissorsTwo;
        private Button btnConfig;
        private Button btnShow;
        public Button btnRockOne;
        public Button btnPaperOne;
        public Button btnScissorsOne;
        public Label lblClientScore;
        public Label lblServerScore;
        public Label lblMessage;
        public PictureBox imgPlayerOneMove;
        public PictureBox imgPlayerTwoMove;
    }
}
