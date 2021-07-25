using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace UserInterfaceAsteroids
{
    public partial class Form1 : Form
    {
        private Point P2 = new Point();
        private PictureBox Laser;
        
        private SoundPlayer LaserSound;
        private List<PictureBox> LasersList;
        private List<Asteroid> AsteroidsList;
        private Point tempPoint = new Point();
        private int tempSHIT = 0;
        
        
        public Form1()
        {
            InitializeComponent();
            
            timer.Start();
            System.Windows.Forms.Cursor.Hide();
            LasersList = new List<PictureBox>();
            LaserSound = new SoundPlayer(@"e:\Users\Dan\Desktop\לימודים\Private programming\WinForm Asteroids\UserInterfaceAsteroids\UserInterfaceAsteroids\Resources\LaserSound.wav");
            LasersList = new List<PictureBox>();
            AsteroidsList = new List<Asteroid>();

        }

        private void MainGameTimerEvent(object sender, EventArgs e)
        {
            Spaceship.Location = P2;
            moveAllLasers();
            moveAllAsteroids();
            if (tempSHIT % 100 == 0)
            {
                Asteroid newAsteroid = new Asteroid(AsteroidPicture.Image);
                AsteroidsList.Add(newAsteroid);
                this.Controls.Add(newAsteroid);

            }

            

            tempSHIT++;
        }

        private void moveAllAsteroids()
        {
            foreach (Asteroid asteroidObject in AsteroidsList)
            {
                tempPoint.X = asteroidObject.Location.X;
                tempPoint.Y = asteroidObject.Location.Y + 2 ;
                asteroidObject.Location = tempPoint;
            }
        }

        private void moveAllLasers()
        {
            foreach(PictureBox Laser in LasersList)
            {
                tempPoint.X = Laser.Location.X;
                tempPoint.Y = Laser.Location.Y - 10;
                Laser.Location = tempPoint;
            }
        }

        private void CreateLaserPictureBox()
        {
            PictureBox Laser = new PictureBox();
            Bitmap tempBitmap = new Bitmap(lasershot.Image);
            Laser.Image = tempBitmap;

            //Point LaserLocation = new Point(Spaceship.Location.X + (Spaceship.Width / 2) -25 , Spaceship.Location.Y-40);
            Laser.Location = new Point(Spaceship.Location.X + (Spaceship.Width / 2) -25 , Spaceship.Location.Y-40);
            Laser.Visible = true;
            Laser.BackColor = Color.Transparent;
            Laser.BackgroundImage = null;
            Laser.SizeMode = PictureBoxSizeMode.StretchImage;
            Laser.Size = new Size(55, 43);
            this.Controls.Add(Laser);
            LasersList.Add(Laser);
            
            
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
            LaserSound.Play();
        }

        private void AsteroidBeenHit(object sender, MouseEventArgs e)
        {

        }


        public class Asteroid : PictureBox
        {

            private Random RandomNum;

            public event Action<Asteroid> HitByLaserInvoker;

            public Asteroid(Image AsteroidImage)
            {
                RandomNum = new Random();
                int RandomX = RandomNum.Next(50, 900);
                //PictureBox asteroid = new PictureBox();
                Bitmap tempBitmap = new Bitmap(AsteroidImage);
                this.Image = tempBitmap;

                this.Location = new Point(RandomX,-100);
              // this.Location = new Point(50,50);
                this.Visible = true;
                this.BackColor = Color.Transparent;
                this.BackgroundImage = null;
                this.SizeMode = PictureBoxSizeMode.StretchImage;
                this.Size = new Size(312, 168);
                //this.Controls.Add(asteroid);

                

                
                
            }

            
        }




    }


    
}
