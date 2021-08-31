
namespace UserInterfaceAsteroids
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Spaceship = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lasershot = new System.Windows.Forms.PictureBox();
            this.AsteroidPicture = new System.Windows.Forms.PictureBox();
            this.BarHeart = new System.Windows.Forms.PictureBox();
            this.Score = new System.Windows.Forms.TextBox();
            this.Countdown = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Spaceship)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lasershot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AsteroidPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarHeart)).BeginInit();
            this.SuspendLayout();
            // 
            // Spaceship
            // 
            this.Spaceship.BackColor = System.Drawing.Color.Transparent;
            this.Spaceship.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Spaceship.Image = ((System.Drawing.Image)(resources.GetObject("Spaceship.Image")));
            this.Spaceship.Location = new System.Drawing.Point(363, 425);
            this.Spaceship.Name = "Spaceship";
            this.Spaceship.Size = new System.Drawing.Size(114, 93);
            this.Spaceship.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Spaceship.TabIndex = 0;
            this.Spaceship.TabStop = false;
            this.Spaceship.Click += new System.EventHandler(this.Spaceship_Click);
            // 
            // timer
            // 
            this.timer.Interval = 1;
            this.timer.Tick += new System.EventHandler(this.MainGameTimerEvent);
            // 
            // lasershot
            // 
            this.lasershot.BackColor = System.Drawing.Color.Transparent;
            this.lasershot.Image = ((System.Drawing.Image)(resources.GetObject("lasershot.Image")));
            this.lasershot.Location = new System.Drawing.Point(412, 375);
            this.lasershot.Name = "lasershot";
            this.lasershot.Size = new System.Drawing.Size(16, 44);
            this.lasershot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.lasershot.TabIndex = 1;
            this.lasershot.TabStop = false;
            this.lasershot.Visible = false;
            // 
            // AsteroidPicture
            // 
            this.AsteroidPicture.BackColor = System.Drawing.Color.Transparent;
            this.AsteroidPicture.Image = ((System.Drawing.Image)(resources.GetObject("AsteroidPicture.Image")));
            this.AsteroidPicture.Location = new System.Drawing.Point(36, 417);
            this.AsteroidPicture.Name = "AsteroidPicture";
            this.AsteroidPicture.Size = new System.Drawing.Size(102, 87);
            this.AsteroidPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AsteroidPicture.TabIndex = 2;
            this.AsteroidPicture.TabStop = false;
            this.AsteroidPicture.Visible = false;
            // 
            // BarHeart
            // 
            this.BarHeart.BackColor = System.Drawing.Color.Transparent;
            this.BarHeart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BarHeart.Image = global::UserInterfaceAsteroids.Properties.Resources.heart1;
            this.BarHeart.Location = new System.Drawing.Point(12, 12);
            this.BarHeart.Name = "BarHeart";
            this.BarHeart.Size = new System.Drawing.Size(41, 39);
            this.BarHeart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BarHeart.TabIndex = 3;
            this.BarHeart.TabStop = false;
            this.BarHeart.Visible = false;
            // 
            // Score
            // 
            this.Score.BackColor = System.Drawing.SystemColors.MenuText;
            this.Score.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Score.Enabled = false;
            this.Score.Font = new System.Drawing.Font("Showcard Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Score.ForeColor = System.Drawing.Color.Purple;
            this.Score.Location = new System.Drawing.Point(765, 12);
            this.Score.Name = "Score";
            this.Score.ReadOnly = true;
            this.Score.Size = new System.Drawing.Size(278, 30);
            this.Score.TabIndex = 4;
            this.Score.Text = "Your Score: ";
            this.Score.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Score.Visible = false;
            this.Score.WordWrap = false;
            // 
            // Countdown
            // 
            this.Countdown.BackColor = System.Drawing.SystemColors.MenuText;
            this.Countdown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Countdown.Enabled = false;
            this.Countdown.Font = new System.Drawing.Font("Showcard Gothic", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Countdown.ForeColor = System.Drawing.Color.Purple;
            this.Countdown.Location = new System.Drawing.Point(428, 209);
            this.Countdown.Name = "Countdown";
            this.Countdown.ReadOnly = true;
            this.Countdown.Size = new System.Drawing.Size(167, 119);
            this.Countdown.TabIndex = 5;
            this.Countdown.Text = "3";
            this.Countdown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Countdown.Visible = false;
            this.Countdown.WordWrap = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.HotPink;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1084, 721);
            this.Controls.Add(this.Countdown);
            this.Controls.Add(this.Score);
            this.Controls.Add(this.BarHeart);
            this.Controls.Add(this.AsteroidPicture);
            this.Controls.Add(this.lasershot);
            this.Controls.Add(this.Spaceship);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Spaceship)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lasershot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AsteroidPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarHeart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Spaceship;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.PictureBox lasershot;
        private System.Windows.Forms.PictureBox AsteroidPicture;
        private System.Windows.Forms.PictureBox BarHeart;
        private System.Windows.Forms.TextBox Score;
        private System.Windows.Forms.TextBox Countdown;
    }
}

