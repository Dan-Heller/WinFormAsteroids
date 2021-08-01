
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
            ((System.ComponentModel.ISupportInitialize)(this.Spaceship)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lasershot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AsteroidPicture)).BeginInit();
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
            this.AsteroidPicture.Location = new System.Drawing.Point(92, 12);
            this.AsteroidPicture.Name = "AsteroidPicture";
            this.AsteroidPicture.Size = new System.Drawing.Size(126, 116);
            this.AsteroidPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AsteroidPicture.TabIndex = 2;
            this.AsteroidPicture.TabStop = false;
            this.AsteroidPicture.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.HotPink;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(900, 619);
            this.Controls.Add(this.AsteroidPicture);
            this.Controls.Add(this.lasershot);
            this.Controls.Add(this.Spaceship);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveEvent);
            ((System.ComponentModel.ISupportInitialize)(this.Spaceship)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lasershot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AsteroidPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Spaceship;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.PictureBox lasershot;
        private System.Windows.Forms.PictureBox AsteroidPicture;
    }
}

