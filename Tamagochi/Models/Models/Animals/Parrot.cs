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
        private List<Meat> food;
        #endregion

        #region Constructors
        public Parrot(Gender sex, string name)
            : base(sex, name)
        {
        }

        public Parrot(Gender sex, string name, Condition condition)
            : base(sex, name, condition)
        {
        }
        #endregion
        
        public List<Plant> Food
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
                // TODO: Implement this property getter
                throw new NotImplementedException();
            }
        }

        public void MakeSound()
        {
            SoundPlayer playSound = new SoundPlayer(ParrotSoundPath);
            playSound.Play();
        }
    }
}
