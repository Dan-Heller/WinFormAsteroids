﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidsLogic
{
    public class AsteroidsGame
    {
        //private readonly Random r_RandomNumber;
        private int m_LivesLeft;
        private int m_Score;

        public AsteroidsGame()
        {
            m_LivesLeft = 5;
            m_Score = 0;
            //r_RandomNumber = new Random();
        }

        public void Reset()
        {
            m_LivesLeft = 5;
            m_Score = 0;
        }

        public int GetLives
        {
            get
            {
                return this.m_LivesLeft;
            }
            set
            {
                this.m_LivesLeft = value;
            }
        }

        public int GetScore
        {
            get
            {
                return this.m_Score;
            }
            set
            {
                this.m_Score = value;
            }
        }

    }
}
