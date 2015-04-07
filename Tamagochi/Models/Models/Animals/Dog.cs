using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;


namespace Models
{
    public class Dog : Mammal, IAnimal, ICarnivorous, ISoundable, IPlayable
    {
        private const string DogSoundPath = @"..\..\..\Models\Resourses\Sound\DogSound.wav";
        private const string InitialDogPicture = @"..\..\..\Models\Resourses\Pictures\Dog\initial.png";
        private const string EatDogPicture = @"..\..\..\Models\Resourses\Pictures\Dog\eat.png";
        private const string SadDogPicture = @"..\..\..\Models\Resourses\Pictures\Dog\sad.png";
        private const string PlayDogPicture = @"..\..\..\Models\Resourses\Pictures\Dog\play.png";
        private const string SleapyDogPicture = @"..\..\..\Models\Resourses\Pictures\Dog\sleep.png";
        private List<Meat> InitialAllowedFoods = new List<Meat> { new Drumstick(), new FishMeat(), new Steak(), new Pizza() };



        private List<Meat> food;

        internal Dog(Gender sex, string name)
            : base(sex, name)
        {
           this.MeatFoodAllowed = InitialAllowedFoods;
           this.Pictures = new string[]
            {
                Dog.InitialDogPicture,
                Dog.EatDogPicture,
                Dog.SadDogPicture,
                Dog.PlayDogPicture,
                Dog.SleapyDogPicture

            };
            
        }

        //public Dog(Gender sex, string name,Condition initialCondition,int initialPoints, List<Meat> initialFood)
        //    : base(sex, name,initialCondition, initialPoints)
        //{
        //    this.MeatFoodAllowed = initialFood;
        //}

        public List<Meat> MeatFoodAllowed
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
                return DogSoundPath;
            }
        }

        public void MakeSound()
        {
            SoundPlayer playSound = new SoundPlayer(DogSoundPath);
            playSound.Play();
        }
    }
}
