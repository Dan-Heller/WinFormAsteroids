using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
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
           gameForm = new Form1(Logic);
           
            Run();
       }

       private void Run()
       {
           startForm.ShowDialog();
           gameForm.ShowDialog();

           EndForm = new GameOverForm(Logic);
           EndForm.ShowDialog();
       }

    }
}
