namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.Media;

    public class Eagle : Bird, ICarnivorous, IPlayable, ISoundable
    {
        #region Constants
        private const string EagleSoundPath = @"...\...\Resourses\Sound\EagleSound.wav";
        private const int HappinessIncrement = 20;
        private const int FeedIncrement = 20;
        #endregion

        #region Constructors
        public Eagle(Gender sex, string name)
            : base(sex, name)
        {
        }

        public Eagle(Gender sex, string name, Condition condition)
            : base(sex, name, condition)
        {
        }
        #endregion

        public List<Meat> Food
        {
            get { throw new NotImplementedException(); }
        }

        public void Hunt()
        {
            this.CurrentCondition.ChangeFeed(FeedIncrement);
        }

        public void Play()
        {
            this.CurrentCondition.ChangeHappiness(HappinessIncrement);
        }

        public void AddPoints(int aditionalPoints)
        {
            throw new NotImplementedException();
        }

        public void MakeSound()
        {
            SoundPlayer playSound = new SoundPlayer(EagleSoundPath);
            playSound.Play();
        }
    }
}
