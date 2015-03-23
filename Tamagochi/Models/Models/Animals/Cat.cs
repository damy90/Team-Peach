using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;

namespace Models
{
    public class Cat : Mammal, ICarnivorous,ISoundable
    {
        private const string catSoundPath = @"...\...\Resourses\Sound\CatSound.wav";

        private List<Meat> food;

        public Cat(Gender sex, string name)
            : base(sex, name)
        {
           // this.Food = new List<Meat>();
        }

        public Cat(Gender sex, string name, int initialPoints,Condition initialCondition, List<Meat> initialFood)
            : base(sex, name,initialCondition, initialPoints)
        {
            this.Food = initialFood;
        }

        public List<Meat> Food
        {
            get 
            {
                return new List<Meat>(this.food);
            }
            set
            {
                if (value.Count == 0)
                {
                    throw new ArgumentNullException("List cannot has 0 arguments");
                }
                this.food = value;
            }
        }

        public void AddFood(Meat aditionalDood)
        {
            this.Food.Add(aditionalDood);
        }


        public void Hunt()
        {
            Random rnd = new Random();
            int huntingPoints = rnd.Next(2, 20);
            AddPoints(huntingPoints);
        }

        public void MakeSound()
        {
            SoundPlayer playSound = new SoundPlayer(catSoundPath);
            playSound.Play();
        }
    }
}
