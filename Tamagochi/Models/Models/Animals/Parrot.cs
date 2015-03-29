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
        #endregion

        #region Fields
        private IList<Plant> plantFoodAllowed = new List<Plant>();
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
            get { throw new NotImplementedException(); }
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
    }
}
