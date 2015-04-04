using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;


namespace Models
{
    public class Dog : Mammal, ICarnivorous, ISoundable, IPlayable
    {
        private const string dogSoundPath = @"...\...\Resourses\Sound\DogSound.wav";
        private const List<Meat> DefaultFoods = new List<Meat> { new Steak() };

        private List<Meat> food;

        public Dog(Gender sex, string name)
            : base(sex, name)
        {
            this.Food = DefaultFoods;
        }

        public Dog(Gender sex, string name,Condition initialCondition,int initialPoints, List<Meat> initialFood)
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
            private set
            {
                if (value.Count == 0)
                {
                    throw new ArgumentNullException("List cannot has 0 arguments.");
                }
                this.food = value;
            }
        }

        public void Hunt()
        {
            int huntingPoints = this.random.Next(2, 20);
            AddPoints(huntingPoints);
        }

        public string SoundPath
        {
            get
            {
                // TODO: Implement this property getter
                throw new NotImplementedException();
            }
        }

        public void MakeSound()
        {
            SoundPlayer playSound = new SoundPlayer(dogSoundPath);
            playSound.Play();
        }
    }
}
