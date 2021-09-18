using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using AsteroidsLogic;

namespace UserInterfaceAsteroids
{
    public class GameFormsManger
    {
        private AsteroidsGame Logic = new AsteroidsGame();
        StartWindow startForm = new StartWindow();
        private Form1 gameForm;
        private GameOverForm EndForm;

       public GameFormsManger()
       {
           Run();
       }

       private void Run()
       {
           startForm.ShowDialog();
           do
           {
               gameForm = new Form1(Logic);
                gameForm.ShowDialog();
                if(gameForm.IsClosedByUser)
                {
                    break;
                }
               EndForm = new GameOverForm(Logic);
               EndForm.ShowDialog();
               Logic.Reset();
           }
           while(EndForm.GetPressedKey == Keys.Enter);
       }
    }
}
