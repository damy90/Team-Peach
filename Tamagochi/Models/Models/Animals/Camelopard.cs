using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;

namespace Models
{
    public class Camelopard : Mammal, IHerbivorous,ISoundable
    {
        private const string camelopardSoundPath = @"...\...\Resourses\Sound\CamelopardSound.wav";

        private List<Plant> food;

        public Camelopard(Gender sex, string name)
            :base(sex,name)
        {
           // this.Food = new List<Plant>();
        }

        public Camelopard(Gender sex, string name, int initialPoints)
            : base(sex, name, initialPoints)
        {
            // this.Food = new List<Plant>();
        }

        public Camelopard(Gender sex, string name, int initialPoints, List<Plant> initialFood)
            : this(sex, name, initialPoints)
        {
            this.Food = initialFood;
        }

        public List<Plant> Food
        {
            get 
            {
                return new List<Plant>(this.food);
            }
            private set
            {
                if (value.Count == 0)
                {
                    throw new ArgumentNullException("List cannot has 0 arguments");
                }
                this.food = value;
            }
        }

        public void MakeSound()
        {
            SoundPlayer playSound = new SoundPlayer(camelopardSoundPath);
            playSound.Play();
        }
    }
}
