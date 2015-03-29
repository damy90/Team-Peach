namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.Media;
    
    public class Parrot : Bird, IHerbivorous, IPlayable, ISoundable
    {
        #region Constants
        private const string ParrotSoundPath = @"...\...\Resourses\Sound\ParrotSound.wav";
        private const int HappinessIncrement = 20;
        private const int PlayPointsIncrement = 20;
        #endregion

        #region Fields
        private List<Plant> plantFoodAllowed = new List<Plant>();
        private int points;
        #endregion

        #region Constructors
        public Parrot()
            : base()
        {
        }

        public Parrot(Gender sex, string name)
            : base(sex, name)
        {
        }

        public Parrot(Gender sex, string name, Condition condition)
            : base(sex, name, condition)
        {
        }
        #endregion
        
        public List<Plant> PlantFoodAllowed
        {
            get
            {
                return this.plantFoodAllowed;
            }
            private set
            {
                if (value != null)
                {
                    this.plantFoodAllowed = value;
                }
                else
                {
                    throw new ArgumentNullException("List of allowed foods cannot be null");
                }
            }
        }


        public void Play()
        {
            this.CurrentCondition.ChangeHappiness(HappinessIncrement);
        }

        public void AddPoints(int aditionalPoints)
        {
            throw new NotImplementedException();
        }

        public string SoundPath
        {
            get
            {
                return this.SoundPath;
            }
        }

        public void MakeSound()
        {
            SoundPlayer playSound = new SoundPlayer(SoundPath);
            playSound.Play();
        }

        public int Points
        {
            get { return this.points; }
            set { this.points = value; }
        }
    }
}
