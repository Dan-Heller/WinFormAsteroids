using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidsLogic
{
    public class AsteroidsGame
    {
        private readonly Random r_RandomNumber;
        private int m_LivesLeft;
        private int m_Score;

        private AsteroidsGame()
        {
            m_LivesLeft = 5;
            m_Score = 0;
            r_RandomNumber = new Random();
        }

    }
}
