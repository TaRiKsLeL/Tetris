namespace Tetris
{
    partial class Scores
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
            this.tabelLayoutScore = new System.Windows.Forms.TableLayoutPanel();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tabelLayoutScore
            // 
            this.tabelLayoutScore.BackColor = System.Drawing.Color.Transparent;
            this.tabelLayoutScore.ColumnCount = 2;
            this.tabelLayoutScore.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.70721F));
            this.tabelLayoutScore.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.29279F));
            this.tabelLayoutScore.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabelLayoutScore.ForeColor = System.Drawing.Color.White;
            this.tabelLayoutScore.Location = new System.Drawing.Point(30, 82);
            this.tabelLayoutScore.Name = "tabelLayoutScore";
            this.tabelLayoutScore.RowCount = 5;
            this.tabelLayoutScore.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tabelLayoutScore.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tabelLayoutScore.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tabelLayoutScore.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tabelLayoutScore.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tabelLayoutScore.Size = new System.Drawing.Size(236, 234);
            this.tabelLayoutScore.TabIndex = 0;
            this.tabelLayoutScore.Paint += new System.Windows.Forms.PaintEventHandler(this.tabelLayoutScore_Paint);
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.scoreLabel.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.scoreLabel.ForeColor = System.Drawing.Color.White;
            this.scoreLabel.Location = new System.Drawing.Point(98, 28);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(107, 34);
            this.scoreLabel.TabIndex = 1;
            this.scoreLabel.Text = "SCORE";
            // 
            // Scores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Tetris.Properties.Resources.hwgemflu;
            this.ClientSize = new System.Drawing.Size(302, 453);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.tabelLayoutScore);
            this.Name = "Scores";
            this.Text = "Scores";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tabelLayoutScore;
        private System.Windows.Forms.Label scoreLabel;
    }
}