namespace Tetris
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.startBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.highBtn = new System.Windows.Forms.RadioButton();
            this.mediumBtn = new System.Windows.Forms.RadioButton();
            this.lowBtn = new System.Windows.Forms.RadioButton();
            this.shapeCB = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.signUpBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(85)))), ((int)(((byte)(86)))));
            this.label1.Font = new System.Drawing.Font("Brutal Type", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.label1.Location = new System.Drawing.Point(69, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(468, 148);
            this.label1.TabIndex = 0;
            this.label1.Text = "TETRIS";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // startBtn
            // 
            this.startBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(85)))), ((int)(((byte)(86)))));
            this.startBtn.FlatAppearance.BorderSize = 0;
            this.startBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startBtn.Font = new System.Drawing.Font("Century Gothic", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.startBtn.Location = new System.Drawing.Point(565, 278);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(200, 92);
            this.startBtn.TabIndex = 1;
            this.startBtn.Text = "START";
            this.startBtn.UseVisualStyleBackColor = false;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(85)))), ((int)(((byte)(86)))));
            this.groupBox1.Controls.Add(this.highBtn);
            this.groupBox1.Controls.Add(this.mediumBtn);
            this.groupBox1.Controls.Add(this.lowBtn);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.groupBox1.Location = new System.Drawing.Point(469, 370);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(338, 82);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SPEED";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // highBtn
            // 
            this.highBtn.AutoSize = true;
            this.highBtn.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.highBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.highBtn.Location = new System.Drawing.Point(237, 32);
            this.highBtn.Name = "highBtn";
            this.highBtn.Size = new System.Drawing.Size(78, 27);
            this.highBtn.TabIndex = 5;
            this.highBtn.Text = "HIGH";
            this.highBtn.UseVisualStyleBackColor = true;
            // 
            // mediumBtn
            // 
            this.mediumBtn.AutoSize = true;
            this.mediumBtn.Checked = true;
            this.mediumBtn.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mediumBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.mediumBtn.Location = new System.Drawing.Point(113, 32);
            this.mediumBtn.Name = "mediumBtn";
            this.mediumBtn.Size = new System.Drawing.Size(106, 27);
            this.mediumBtn.TabIndex = 4;
            this.mediumBtn.TabStop = true;
            this.mediumBtn.Text = "MEDIUM";
            this.mediumBtn.UseVisualStyleBackColor = true;
            this.mediumBtn.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // lowBtn
            // 
            this.lowBtn.AutoSize = true;
            this.lowBtn.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lowBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.lowBtn.Location = new System.Drawing.Point(22, 32);
            this.lowBtn.Name = "lowBtn";
            this.lowBtn.Size = new System.Drawing.Size(72, 27);
            this.lowBtn.TabIndex = 3;
            this.lowBtn.Text = "LOW";
            this.lowBtn.UseVisualStyleBackColor = true;
            // 
            // shapeCB
            // 
            this.shapeCB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.shapeCB.FormattingEnabled = true;
            this.shapeCB.Items.AddRange(new object[] {
            "Mix Color",
            "Red",
            "Blue"});
            this.shapeCB.Location = new System.Drawing.Point(333, 414);
            this.shapeCB.Name = "shapeCB";
            this.shapeCB.Size = new System.Drawing.Size(121, 24);
            this.shapeCB.TabIndex = 3;
            this.shapeCB.Visible = false;
            this.shapeCB.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(85)))), ((int)(((byte)(86)))));
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.label2.Location = new System.Drawing.Point(324, 380);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "SHAPE COLOR";
            this.label2.Visible = false;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // signUpBtn
            // 
            this.signUpBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.signUpBtn.FlatAppearance.BorderSize = 0;
            this.signUpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.signUpBtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.signUpBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(216)))), ((int)(((byte)(224)))));
            this.signUpBtn.Location = new System.Drawing.Point(12, 404);
            this.signUpBtn.Name = "signUpBtn";
            this.signUpBtn.Size = new System.Drawing.Size(157, 34);
            this.signUpBtn.TabIndex = 6;
            this.signUpBtn.Text = "HIGH SCORE";
            this.signUpBtn.UseVisualStyleBackColor = false;
            this.signUpBtn.Click += new System.EventHandler(this.signUpBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.BackgroundImage = global::Tetris.Properties.Resources.back_image;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.signUpBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.shapeCB);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "TETRIS";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton highBtn;
        private System.Windows.Forms.RadioButton mediumBtn;
        private System.Windows.Forms.RadioButton lowBtn;
        private System.Windows.Forms.ComboBox shapeCB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button signUpBtn;
    }
}

