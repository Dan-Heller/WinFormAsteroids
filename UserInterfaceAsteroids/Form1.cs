using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AsteroidsLogic;
using UserInterfaceAsteroids.Properties;



namespace UserInterfaceAsteroids
{
    public partial class Form1 : Form
    {
        private Point clientPoint = new Point();
        private AsteroidsGame Logic;
        private TextBox ScoreDisplay;
        private String ScoreString;
        private SoundPlayer LaserSound;
        private SoundPlayer CrashSound;
        private List<PictureBox> LasersList;
        private List<Asteroid> AsteroidsList;
        private List<PictureBox> HeartsBarList;
        private List<PictureBox> CollectableHeartsList;
        private Point tempPoint = new Point();
        private int intervalsCounter = 0;
        private int YAngleAdder = 0;
        private bool UserClosed = false;
        private bool GameOn = false;
        private int lastScoreCheckPoint = 0;
        private Point CursorLocation;

        private Random RandomNum = new Random();
        
        

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
            LaserSound = new SoundPlayer(@"Sounds\LaserSound.wav");
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            Logic = LogicReference;
            CollectableHeartsList = new List<PictureBox>();
            InitializeScoreDisplay();
            AsteroidsList = new List<Asteroid>();
            
            ///https:///stackoverflow.com/questions/10449090/how-to-make-image-move-smoothly-with-c-sharp
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            this.Controls.Add(Countdown);
        }

        private void MainGameTimerEvent(object sender, EventArgs e)
        {
            if (intervalsCounter <= 180)
            {
                CountdownAnimation();
                intervalsCounter++;
                return;
            }

            UpdateScore();
            UpdateSpaceshipPositionByCursorLoactaion();
            moveAllLasers();
            moveAllAsteroids(YAngleAdder);
            CheckLaserAsteroidIntersect();
            CheckSpaceshipAndHeartIntersect();
            CheckSpaceshipAsteroidsIntersect();

            if (intervalsCounter % 250 == 0 && CollectableHeartsList.Count <= 3 && Logic.GetLives < 6)//conditions for new heart creation
            {
                AddCollectableHeart();
            }

            if (Logic.GetScore % 10 == 0 && Logic.GetScore != lastScoreCheckPoint)//asteroids speed adder
            {
                YAngleAdder += 1;
                lastScoreCheckPoint = Logic.GetScore;
            }

            if (intervalsCounter % 20 == 0) //asteroids adder
            {
                CreateNewAsteroid(AsteroidPicture.Image);
            }

            if (CheckIfGameOver())
            {
                this.Close();
            }

            intervalsCounter++;
        }

        private void UpdateSpaceshipPositionByCursorLoactaion()
        {
            CursorLocation = MousePosition;
            clientPoint = PointToClient(CursorLocation);
            clientPoint.X -= (Spaceship.Width) / 2;
            clientPoint.Y -= (Spaceship.Height) / 2;
            Spaceship.Location = clientPoint;
        }

        private void CreateNewAsteroid(Image image)
        {
            Asteroid newAsteroid = new Asteroid(AsteroidPicture.Image);
            AsteroidsList.Add(newAsteroid);
            this.Controls.Add(newAsteroid);
            newAsteroid.AsteroidPassedTheSpaceshipInvoker += new Action<Asteroid>(AsteroidPassedScreen);
        }

        private void CountdownAnimation()
        {
            Countdown.Visible = true;
            if(intervalsCounter >= 0 && intervalsCounter < 60)
            {
                Countdown.Text = "3";
            }
            else if (intervalsCounter >= 0 && intervalsCounter < 120)
            {
                Countdown.Text = "2";
            }
            else if (intervalsCounter >= 0 && intervalsCounter < 180)
            {
                Countdown.Text = "1";
            }
            else
            {
                Countdown.Visible = false;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!CheckIfGameOver()) 
            {
                UserClosed = true;
            }
        }

        public bool IsClosedByUser
        {
            get
            {
                return UserClosed;
            }
        }

        private void InitializeScoreDisplay()
        {
            ScoreDisplay = new TextBox();
            ScoreString = ("Your Score: " + Logic.GetScore);
            ScoreDisplay.Text = ScoreString;
            ScoreDisplay.Font = Score.Font;
            ScoreDisplay.Size = Score.Size;
            ScoreDisplay.Location = Score.Location;
            ScoreDisplay.ForeColor = Score.ForeColor;
            ScoreDisplay.Visible = true;
            ScoreDisplay.Enabled = false;
            ScoreDisplay.BackColor = Score.BackColor;
            ScoreDisplay.BorderStyle = BorderStyle.None;
            this.Controls.Add(ScoreDisplay);
        }

        private void UpdateScore()
        {
            ScoreString = ("Your Score: " + Logic.GetScore);
            ScoreDisplay.Text = ScoreString;
        }

        bool CheckIfGameOver()
        {
            return (Logic.GetLives == 0);
        }

        private void AddCollectableHeart()
        {
            PictureBox newCollectableHeart = createPictureBox(collectableHeart, CollectableHeartsList);
            Point point = new Point();
            point.X = RandomNum.Next(100, this.Height - 100);
            point.Y = RandomNum.Next(100, this.Width - 100);
            newCollectableHeart.Location = point;
        }

        private void moveAllAsteroids(int YAngleAdder)
        {
            for (int i = 0; i < AsteroidsList.Count; i++)
            {
                tempPoint.X = AsteroidsList[i].Location.X + AsteroidsList[i].GetXangle;
                tempPoint.Y = AsteroidsList[i].Location.Y + AsteroidsList[i].GetYangle + YAngleAdder;
                AsteroidsList[i].Location = tempPoint;
                AsteroidsList[i].AsteriodMoved(this.Height); //will check if asteroid passed the screen for deletion.
            }
        }

        private void moveAllLasers()
        {
            foreach(PictureBox Laser in LasersList)
            {
                tempPoint.X = Laser.Location.X;
                tempPoint.Y = Laser.Location.Y - 10;
                Laser.Location = tempPoint;
                if (checkedIfLaserPassed(Laser))//if passed screen remove from list
                {
                    LasersList.Remove(Laser);
                    Laser.Visible = false;
                    return; //i must return although not all moved (cant remove from list otherwise)
                }
            }
        }

        private PictureBox createPictureBox(PictureBox picture, List<PictureBox> list)
        {
            PictureBox newPictureBox = new PictureBox();
            Bitmap tempBitmap = new Bitmap(picture.Image);
            newPictureBox.Image = tempBitmap;
            newPictureBox.Visible = true;
            newPictureBox.BackColor = Color.Transparent;
            newPictureBox.BackgroundImage = null;
            newPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            newPictureBox.Size = picture.Size;
            this.Controls.Add(newPictureBox);
            list.Add(newPictureBox);
            return newPictureBox;
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

        private void CheckLaserAsteroidIntersect()
        {

            foreach (PictureBox Laser in LasersList)
            {
                foreach (Asteroid asteroidObject in AsteroidsList)
                {
                    if (Laser.Bounds.IntersectsWith(asteroidObject.Bounds))
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

        private void CheckSpaceshipAndHeartIntersect()
        {
            foreach (PictureBox heart in CollectableHeartsList)
            {
                if (Spaceship.Bounds.IntersectsWith(heart.Bounds))
                {
                    CollectableHeartsList.Remove(heart);
                    heart.Visible = false;
                    AddBarHeart();
                    Logic.GetLives++;
                    return;
                }
            }
        }

        private void InitializeHearts()
        {
            for (int i = 0; i < 5; i++)
            {
                PictureBox BarHeart = createPictureBox(this.BarHeart, HeartsBarList);
                BarHeart.Location = new Point(12 + (this.BarHeart.Size.Width * (i)), 12);
            }
        }

        private void AddBarHeart()
        {
            PictureBox BarHeart = createPictureBox(this.BarHeart, HeartsBarList);
            BarHeart.Location = new Point(HeartsBarList[HeartsBarList.Count-2].Location.X+BarHeart.Width, HeartsBarList[HeartsBarList.Count-2].Location.Y);
        }

        private void HeartLost()
        {
            Logic.GetLives--;
            HeartsBarList[HeartsBarList.Count - 1].Visible = false;
            HeartsBarList.RemoveAt(HeartsBarList.Count-1);
        }

        private void AsteroidPassedScreen(Asteroid asteroid)
        {
            AsteroidsList.Remove(asteroid);
            asteroid.Visible = false;
        }

        private bool checkedIfLaserPassed(PictureBox laser)
        {
            return (laser.Location.Y < -100);
        }

        private void Spaceship_Click(object sender, EventArgs e)
        {
            PictureBox laserPictureBox = createPictureBox(lasershot, LasersList);
            laserPictureBox.Location = new Point(Spaceship.Location.X + (Spaceship.Width / 2) - 7, Spaceship.Location.Y - 40);
            LaserSound.Play();
        }



        public class Asteroid : PictureBox
        {

            private Random RandomNum;
            private  int Xangle;
            private  int Yangle;
            public event Action<Asteroid> AsteroidPassedTheSpaceshipInvoker;

            public Asteroid(Image AsteroidImage)
            {
                RandomNum = new Random();
                int RandomX = RandomNum.Next(200, 800);
                Bitmap tempBitmap = new Bitmap(AsteroidImage);
                this.Image = tempBitmap;

                this.Location = new Point(RandomX,-100);
                this.Visible = true;
                this.BackColor = Color.Transparent;
                this.BackgroundImage = null;
                this.SizeMode = PictureBoxSizeMode.StretchImage;
                this.Size = new Size(102,87);
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

            public bool AsteriodMoved(int ScreenHeight)
            {
                if(this.Location.Y > ScreenHeight + 200)
                {
                    AsteroidPassedScreen();
                    return true;
                }
                return false;
            }

            protected virtual void AsteroidPassedScreen()
            {
                if (AsteroidPassedTheSpaceshipInvoker != null)
                {
                    AsteroidPassedTheSpaceshipInvoker.Invoke(this);
                }
            }
        }
    }
}