using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Xml.Serialization;

namespace Models
{
    public class Cat : Mammal, IAnimal, ICarnivorous, ISoundable
    {
        private const string catSoundPath = @"..\..\..\Models\Resourses\Sound\CatSound.wav";
        private const string InitialCatPicture = @"..\..\..\Models\Resourses\Pictures\Cat\initial.png";
        private const string EatCatPicture = @"..\..\..\Models\Resourses\Pictures\Cat\eat.png";
        private const string SadCatPicture = @"..\..\..\Models\Resourses\Pictures\Cat\sad.png";
        private const string PlayCatPicture = @"..\..\..\Models\Resourses\Pictures\Cat\play.png";
        private List<Meat> InitialAllowedFoods = new List<Meat> { new Drumstick(), new FishMeat(), new Steak(), new Pizza() };

        [XmlIgnore]
        private List<Meat> food;

        //Needed for serialization
        public Cat()
            : base()
        {
            this.food = InitialAllowedFoods;
        }

        internal Cat(Gender sex, string name)
            : base(sex, name)
        {
            this.food = InitialAllowedFoods;
            this.Pictures = new string[]
            {
                Cat.InitialCatPicture,
                Cat.EatCatPicture,
                Cat.SadCatPicture,
                Cat.PlayCatPicture 
            };
        }

        //public Cat(Gender sex, string name, Condition initialCondition, int initialPoints, List<Meat> initialFood)
        //    : base(sex, name, initialCondition, initialPoints)
        //{
        //    this.MeatFoodAllowed = initialFood;
        //}

        public List<Meat> MeatFoodAllowed
        {
            get
            {
                return new List<Meat>(this.food);
            }
            protected set
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
            this.MeatFoodAllowed.Add(aditionalDood);
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
                return catSoundPath;
            }
        }

        public void MakeSound()
        {
            SoundPlayer playSound = new SoundPlayer(this.SoundPath);
            playSound.Play();
        }
    }
}
