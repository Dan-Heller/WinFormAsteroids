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
using AsteroidsLogic;


namespace UserInterfaceAsteroids
{
    public partial class Form1 : Form
    {
        private Point P2 = new Point();
        private PictureBox Laser;
        private AsteroidsGame Logic;


        private SoundPlayer LaserSound;
        private List<PictureBox> LasersList;
        private List<Asteroid> AsteroidsList;
        private List<PictureBox> HeartsBarList;
        private Point tempPoint = new Point();
        private int intervalsCounter = 0;
        private int YAngleAdder = 0;
        
        
        public Form1(AsteroidsGame LogicReference)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            timer.Start();
            System.Windows.Forms.Cursor.Hide();
            HeartsBarList = new List<PictureBox>();
            InitializeHearts();
            LasersList = new List<PictureBox>();
            LaserSound = new SoundPlayer(@"e:\Users\Dan\Desktop\לימודים\Private programming\WinForm Asteroids\UserInterfaceAsteroids\UserInterfaceAsteroids\Resources\LaserSound.wav");

            Logic = LogicReference;
            

            // LasersList = new List<PictureBox>();
            AsteroidsList = new List<Asteroid>();

            ///https:///stackoverflow.com/questions/10449090/how-to-make-image-move-smoothly-with-c-sharp
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

        }

        


        private void MainGameTimerEvent(object sender, EventArgs e)
        {
            Point mouseLocation = MousePosition;
            P2 = PointToClient(mouseLocation);
            P2.X -= (Spaceship.Width) / 2;
            
            P2.Y -= (Spaceship.Height) / 2;

            Spaceship.Location = P2;
            moveAllLasers();
            moveAllAsteroids(YAngleAdder);
            CheckLaserAsteroidIntersect();

            if(intervalsCounter % 5000 == 0) //asteroids speed adder
            {
                YAngleAdder+=2;
            }


            if (intervalsCounter % 20 == 0) //asteroids adder
            {
                Asteroid newAsteroid = new Asteroid(AsteroidPicture.Image);
                AsteroidsList.Add(newAsteroid);
                this.Controls.Add(newAsteroid);
                //newAsteroid.Parent = Spaceship;
                //newAsteroid.BringToFront();
            }


            CheckSpaceshipAsteroidsIntersect();

            if(CheckIfGameOver())
            {
                this.Close();
            }
            //foreach(Asteroid asteroidObject in AsteroidsList)
            //{
            //    if(Spaceship.Bounds.IntersectsWith(asteroidObject.Bounds))
            //    {
            //        Spaceship.Paint += new PaintEventHandler(frmGame_Paint);
            //        break;
            //        //timer.Stop();

            //    }
            //}

            //Spaceship.BringToFront();


            intervalsCounter++;
        }

        bool CheckIfGameOver()
        {
            return (Logic.GetLives == 0);
        }

        private void moveAllAsteroids(int YAngleAdder)
        {
            foreach (Asteroid asteroidObject in AsteroidsList)
            {
                tempPoint.X = asteroidObject.Location.X + asteroidObject.GetXangle ;
                tempPoint.Y = asteroidObject.Location.Y + asteroidObject.GetYangle + YAngleAdder;
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
            Laser.Location = new Point(Spaceship.Location.X + (Spaceship.Width / 2) -7 , Spaceship.Location.Y-40);
            Laser.Visible = true;
            Laser.BackColor = Color.Transparent;
            Laser.BackgroundImage = null;
            Laser.SizeMode = PictureBoxSizeMode.StretchImage;
            Laser.Size = new Size(14, 44);
            this.Controls.Add(Laser);
            LasersList.Add(Laser);
            
            
        }

        private void InitializeHearts()
        {
            for(int i = 0; i < 5; i++)
            {
                PictureBox BarHeart = createBarHeart();
                BarHeart.Location = new Point(12 + (this.BarHeart.Size.Width * (i)), 12);
            }
        }

        private PictureBox createBarHeart()
        {
            PictureBox barHeartPictureBox = new PictureBox();
            Bitmap tempBitmap = new Bitmap(BarHeart.Image);
            barHeartPictureBox.Image = tempBitmap;

            barHeartPictureBox.Visible = true;
            barHeartPictureBox.BackColor = Color.Transparent;
            barHeartPictureBox.BackgroundImage = null;
            barHeartPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            barHeartPictureBox.Size = BarHeart.Size;
            
            this.Controls.Add(barHeartPictureBox);
            HeartsBarList.Add(barHeartPictureBox);

            return barHeartPictureBox;
        }

        private void CheckSpaceshipAsteroidsIntersect()
        {
         
                foreach (Asteroid asteroidObject in AsteroidsList)
                {
                    if (Spaceship.Bounds.IntersectsWith(asteroidObject.Bounds))
                    {
                        AsteroidsList.Remove(asteroidObject);
                        asteroidObject.Visible = false;
                        HeartLost();
                        
                        if(Logic.GetLives == 0)
                        {
                            timer.Stop();
                            return;
                        }
                        return;
                    }
                }
            

        }

        private void HeartLost()
        {
            Logic.GetLives--;
            HeartsBarList[HeartsBarList.Count - 1].Visible = false;
            HeartsBarList.RemoveAt(HeartsBarList.Count-1);
            
        }

        private void CheckLaserAsteroidIntersect()
        {

            foreach (PictureBox Laser in LasersList)
            {
                foreach (Asteroid asteroidObject in AsteroidsList)
                {
                    if(Laser.Bounds.IntersectsWith(asteroidObject.Bounds))
                    {
                        AsteroidsList.Remove(asteroidObject);  //is it the right the to get rid of them?
                        asteroidObject.Visible = false;
                        LasersList.Remove(Laser);
                        Laser.Visible = false;
                        Logic.GetScore++;
                        return;
                    }
                }
            }

        }

        // https:///stackoverflow.com/questions/19910172/how-to-make-picturebox-transparent
        private void frmGame_Paint(object sender, PaintEventArgs e)
        {
            DoubleBuffered = true;
            for (int i = 0; i < Controls.Count; i++)
                if (Controls[i].GetType() == typeof(PictureBox))
                {
                    var p = Controls[i] as PictureBox;
                    p.Visible = false;
                    e.Graphics.DrawImage(p.Image, p.Left, p.Top, p.Width, p.Height);
                }
        }





        //private void MouseMoveEvent(object sender, MouseEventArgs e)
        //{
        //    Point mouseLocation = MousePosition;
        //    P2 =  PointToClient(mouseLocation);
        //    P2.X -= (Spaceship.Width)/2;
        //    P2.Y -= (Spaceship.Height) / 2;
        //}

        private void Spaceship_Click(object sender, EventArgs e)
        {
            CreateLaserPictureBox();
            LaserSound.Play();
        }

       


        public class Asteroid : PictureBox
        {

            private Random RandomNum;
            private  int Xangle;
            private  int Yangle;

            public event Action<Asteroid> HitByLaserInvoker;

            public Asteroid(Image AsteroidImage)
            {
                RandomNum = new Random();
                int RandomX = RandomNum.Next(200, 800);
                //PictureBox asteroid = new PictureBox();
                Bitmap tempBitmap = new Bitmap(AsteroidImage);
                this.Image = tempBitmap;

                this.Location = new Point(RandomX,-100);
              // this.Location = new Point(50,50);
                this.Visible = true;
                this.BackColor = Color.Transparent;
                this.BackgroundImage = null;
                this.SizeMode = PictureBoxSizeMode.StretchImage;
                this.Size = new Size(102,87);
               // this.Controls.Add(this);

               Xangle = RandomNum.Next(-3,3);
               Yangle = 3;
               
               
            }

            public int GetXangle
            {
                get
                {
                    return this.Xangle;
                }
            }
            public int GetYangle
            {
                get
                {
                    return  this.Yangle;
                }
            }

            
        }




    }


    
}
