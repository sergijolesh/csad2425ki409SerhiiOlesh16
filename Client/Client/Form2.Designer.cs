namespace Client
{
    partial class Form2
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
            radioManAi = new RadioButton();
            radioManMan = new RadioButton();
            radioAiAi = new RadioButton();
            btnSave = new Button();
            btnLoad = new Button();
            SuspendLayout();
            // 
            // radioManAi
            // 
            radioManAi.AutoSize = true;
            radioManAi.Location = new Point(12, 12);
            radioManAi.Name = "radioManAi";
            radioManAi.Size = new Size(94, 24);
            radioManAi.TabIndex = 0;
            radioManAi.TabStop = true;
            radioManAi.Text = "Man vs AI";
            radioManAi.UseVisualStyleBackColor = true;
            radioManAi.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // radioManMan
            // 
            radioManMan.AutoSize = true;
            radioManMan.Location = new Point(12, 42);
            radioManMan.Name = "radioManMan";
            radioManMan.Size = new Size(109, 24);
            radioManMan.TabIndex = 1;
            radioManMan.TabStop = true;
            radioManMan.Text = "Man vs Man";
            radioManMan.UseVisualStyleBackColor = true;
            // 
            // radioAiAi
            // 
            radioAiAi.AutoSize = true;
            radioAiAi.Location = new Point(12, 72);
            radioAiAi.Name = "radioAiAi";
            radioAiAi.Size = new Size(79, 24);
            radioAiAi.TabIndex = 2;
            radioAiAi.TabStop = true;
            radioAiAi.Text = "AI vs AI";
            radioAiAi.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(12, 119);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 5;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(127, 119);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(94, 29);
            btnLoad.TabIndex = 6;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(235, 162);
            Controls.Add(btnLoad);
            Controls.Add(btnSave);
            Controls.Add(radioAiAi);
            Controls.Add(radioManMan);
            Controls.Add(radioManAi);
            Name = "Form2";
            Text = "Configuration";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RadioButton radioManAi;
        private RadioButton radioManMan;
        private RadioButton radioAiAi;
        private Button btnSave;
        private Button btnLoad;
    }
}