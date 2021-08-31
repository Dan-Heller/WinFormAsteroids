
namespace UserInterfaceAsteroids
{
    partial class GameOverForm
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
            this.GameOver = new System.Windows.Forms.TextBox();
            this.Score = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // GameOver
            // 
            this.GameOver.BackColor = System.Drawing.SystemColors.MenuText;
            this.GameOver.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GameOver.Enabled = false;
            this.GameOver.Font = new System.Drawing.Font("Showcard Gothic", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameOver.ForeColor = System.Drawing.Color.Purple;
            this.GameOver.Location = new System.Drawing.Point(241, 62);
            this.GameOver.Name = "GameOver";
            this.GameOver.ReadOnly = true;
            this.GameOver.Size = new System.Drawing.Size(542, 119);
            this.GameOver.TabIndex = 2;
            this.GameOver.Text = "Game Over";
            this.GameOver.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.GameOver.WordWrap = false;
            // 
            // Score
            // 
            this.Score.BackColor = System.Drawing.SystemColors.MenuText;
            this.Score.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Score.Enabled = false;
            this.Score.Font = new System.Drawing.Font("Showcard Gothic", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Score.ForeColor = System.Drawing.Color.Purple;
            this.Score.Location = new System.Drawing.Point(177, 325);
            this.Score.Name = "Score";
            this.Score.ReadOnly = true;
            this.Score.Size = new System.Drawing.Size(732, 80);
            this.Score.TabIndex = 3;
            this.Score.Text = "Your Score: ";
            this.Score.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Score.Visible = false;
            this.Score.WordWrap = false;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.MenuText;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Showcard Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Purple;
            this.textBox1.Location = new System.Drawing.Point(166, 449);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(732, 26);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "Press Enter to play again";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.Visible = false;
            this.textBox1.WordWrap = false;
            // 
            // GameOverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UserInterfaceAsteroids.Properties.Resources.canvas;
            this.ClientSize = new System.Drawing.Size(1084, 731);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Score);
            this.Controls.Add(this.GameOver);
            this.Name = "GameOverForm";
            this.Text = "GameOverForm";
            this.TransparencyKey = System.Drawing.Color.White;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox GameOver;
        private System.Windows.Forms.TextBox Score;
        private System.Windows.Forms.TextBox textBox1;
    }
}