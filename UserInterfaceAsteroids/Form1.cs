using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterfaceAsteroids
{
    public partial class Form1 : Form
    {
        private Point P2 = new Point();
        private PictureBox Laser;

        public Form1()
        {
            InitializeComponent();
            //P2  = Point.Empty;
            timer.Start();
        }

        private void MainGameTimerEvent(object sender, EventArgs e)
        {
            Spaceship.Location = P2;
        }

        private void CreateLaserPictureBox()
        {
            Laser = new PictureBox()
                        {
                            Name = "Laser",
                            Size = new Size(100, 100),
                            Location = new Point(Spaceship.Location.X + (Spaceship.Width / 2), Spaceship.Location.Y),
                            Image = Image.FromFile(@"e:\\Users\\Dan\\Desktop\\לימודים\\Private programming\\WinForm Asteroids\\UserInterfaceAsteroids\\UserInterfaceAsteroids\\Resources\\Laser.jpg", true),
                            BackColor = Color.Transparent
                        };
            this.Controls.Add(Laser);
        }



        private void MouseMoveEvent(object sender, MouseEventArgs e)
        {
            Point mouseLocation = MousePosition;
            P2 =  PointToClient(mouseLocation);
            P2.X -= (Spaceship.Width)/2;
            P2.Y -= (Spaceship.Height) / 2;
        }

        private void Spaceship_Click(object sender, EventArgs e)
        {
            CreateLaserPictureBox();
        }
    }
}
