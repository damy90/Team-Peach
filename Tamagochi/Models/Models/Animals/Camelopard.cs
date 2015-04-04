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
        private const string InitialCamelopardPicture = @"..\..\..\Models\Resourses\Pictures\Camelopard\initial.png";
        private const string EatCamelopardPicture = @"..\..\..\Models\Resourses\Pictures\Camelopard\eat.png";
        private const string SadCamelopardPicture = @"..\..\..\Models\\Resourses\Pictures\Camelopard\sad.png";
        private const string PlayCamelopardPicture = @"..\..\..\Models\\Resourses\Pictures\Camelopard\play.png";

        private List<Plant> food;

       public Camelopard(Gender sex, string name)
            : base(sex, name)
        {
           // this.Food = new List<Plant>();
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

       public string[] Pictures { get; private set; }

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
                // TODO: Implement this property getter
                throw new NotImplementedException();
            }
        }

        public void MakeSound()
        {
            SoundPlayer playSound = new SoundPlayer(camelopardSoundPath);
            playSound.Play();
        }
    }
}
