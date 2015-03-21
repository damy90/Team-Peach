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

        public Cat()
        {

        }

        public Cat(List<Meat> initialFood)
            :this()
        {
            this.Food = initialFood;
        }

        public List<Meat> Food
        {
            get 
            {
                return this.food;
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
            throw new NotImplementedException();
        }

        public void MakeSound()
        {
            SoundPlayer playSound = new SoundPlayer(catSoundPath);
            playSound.Play();
        }
    }
}
