using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;

namespace Models
{
    public class Camelopard : Mammal, IAnimal, IHerbivorous,ISoundable
    {
        private const string camelopardSoundPath = @"..\..\..\Models\Resourses\Sound\CamelopardSound.wav";
        private const string InitialCamelopardPicture = @"..\..\..\Models\Resourses\Pictures\Camelopard\initial.png";
        private const string EatCamelopardPicture = @"..\..\..\Models\Resourses\Pictures\Camelopard\eat.png";
        private const string SadCamelopardPicture = @"..\..\..\Models\\Resourses\Pictures\Camelopard\sad.png";
        private const string PlayCamelopardPicture = @"..\..\..\Models\\Resourses\Pictures\Camelopard\play.png";
        private List<Plant> InitialAllowedFoods = new List<Plant> { new Apple(), new Banana(), new Pear() };    

        private List<Plant> food;

       public Camelopard(Gender sex, string name)
            : base(sex, name)
        {
            this.PlantsFoodAllowed = InitialAllowedFoods;
            this.Pictures = new string[]
           {
               Camelopard.InitialCamelopardPicture,
               Camelopard.EatCamelopardPicture,
               Camelopard.SadCamelopardPicture,
               Camelopard.PlayCamelopardPicture
           };
        }

        //public Camelopard(Gender sex, string name,Condition initialCondition, int initialPoints, List<Plant> initialFood)
        //    : base(sex, name,initialCondition, initialPoints)
        //{
        //    this.PlantsFoodAllowed = initialFood;
        //}

        public List<Plant> PlantsFoodAllowed
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

        public string SoundPath
        {
            get
            {
                return camelopardSoundPath;
            }
        }

        public void MakeSound()
        {
            SoundPlayer playSound = new SoundPlayer(camelopardSoundPath);
            playSound.Play();
        }
    }
}
