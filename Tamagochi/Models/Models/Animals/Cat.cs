using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Xml.Serialization;

namespace Models
{
    public class Cat : Mammal, ICarnivorous, ISoundable
    {
        private const string catSoundPath = @"..\..\Resourses\Sound\CatSound.wav";
        private string[] pictures;
        [XmlIgnore]
        private List<Meat> food;

        //Needed for serialization
        public Cat()
            : base()
        {
            this.food = new List<Meat>() { new Pizza(), new Steak() };
        }

        public Cat(Gender sex, string name)
            : base(sex, name)
        {
            this.food = new List<Meat>() { new Pizza(), new Steak() };
            this.Pictures = new string[]
            {
                @"..\..\..\Models\Resourses\Pictures\Cat\initial.png",
                @"..\..\..\Models\Resourses\Pictures\Cat\eat.png",
                @"..\..\..\Models\\Resourses\Pictures\Cat\sad.png",
                @"..\..\..\Models\\Resourses\Pictures\Cat\play.png"
            };
        }

        public Cat(Gender sex, string name, Condition initialCondition, int initialPoints, List<Meat> initialFood)
            : base(sex, name, initialCondition, initialPoints)
        {
            this.MeatFoodAllowed = initialFood;
        }

        [XmlIgnore]
        public List<Meat> MeatFoodAllowed
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
                return @"..\..\Resourses\Sound\CatSound.wav";
            }
        }

        public void MakeSound()
        {
            SoundPlayer playSound = new SoundPlayer(this.SoundPath);
            playSound.Play();
        }
    }
}
