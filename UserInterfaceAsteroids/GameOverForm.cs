using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AsteroidsLogic;

namespace UserInterfaceAsteroids
{
    public partial class GameOverForm : Form
    {
        private TextBox GameOverTEXT = new CustomTextBox();
        private TextBox ScoreDisplay = new TextBox();
        

        public GameOverForm(AsteroidsGame LogicReference)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            //SetGameOverText();
            ShowScore(LogicReference.GetScore);

        }

        private void SetGameOverText()
        {
            GameOverTEXT.Text = GameOver.Text;
            GameOverTEXT.Font = GameOver.Font;
            GameOverTEXT.Size = GameOver.Size;
            GameOverTEXT.Location = GameOver.Location;
            GameOverTEXT.ForeColor = GameOver.ForeColor;
            GameOverTEXT.Visible = true;
            this.Controls.Add(GameOverTEXT);
        }

        private void ShowScore(int ScoreValue)
        {
            ScoreDisplay.Text = Score.Text;
            ScoreDisplay.Font = Score.Font;
            ScoreDisplay.Size = Score.Size;
            ScoreDisplay.Location = Score.Location;
            ScoreDisplay.ForeColor = Score.ForeColor;
            ScoreDisplay.BackColor = Score.BackColor;
            ScoreDisplay.BorderStyle = Score.BorderStyle;
            ScoreDisplay.Visible = true;
            ScoreDisplay.Enabled = false;
            String YourScore = ("Your Score: " + ScoreValue);
            ScoreDisplay.Text = YourScore;
            this.Controls.Add(ScoreDisplay);
        }

        public partial class CustomTextBox : TextBox
        {
            public CustomTextBox()
            {
                
                this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
                this.BackColor = Color.Transparent;

            }




        }


    }
}
