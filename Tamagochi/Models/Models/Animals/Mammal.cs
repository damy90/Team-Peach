using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public abstract class Mammal : Animal, IPlayable
    {
        private const int StartPoints = 0;

        private int points;
        public Mammal(Gender sex, string name)
            : base(sex, name)
        {
            this.Points = 0;
        }

        public Mammal(Gender sex, string name, int initialPoints)
            : this(sex, name)
        {
            AddPoints(initialPoints);
        }

        public void Play()
        {
            AddPoints(10);
        }

        public int Points
        {
            get
            {
                return this.points;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Points cannot be negative.");
                }
                this.points = value;
            }
        }

        public void AddPoints(int addPoints)
        {
            //if (addPoints < 0)
            //{
            //    throw new ArgumentException("Cannot add negative points.");
            //}
            this.Points += addPoints;
        }
    }
}
