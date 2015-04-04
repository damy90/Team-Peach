namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.Media;
    //using Food;
    
    public class Parrot : Bird, IHerbivorous, IPlayable, ISoundable
    {
        #region Constants
        private const string ParrotSoundPath = @"...\...\Resourses\Sound\ParrotSound.wav";
        private const string ParrotPictureDefault = @"...\...\Resourses\Pictures\ParrotPicture_01.png";
        private const string ParrotPictureEating = @"...\...\Resourses\Pictures\ParrotPicture_02.png";
        private const string ParrotPictureUnahppy = @"...\...\Resourses\Pictures\ParrotPicture_03.png";
        private const string ParrotPicturePlaying = @"...\...\Resourses\Pictures\ParrotPicture_04.png";
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
            base.Pictures = new string[4]{ParrotPictureDefault, ParrotPictureEating, ParrotPictureUnahppy, ParrotPicturePlaying};
            this.plantFoodAllowed = new List<Plant>{new Apple(), new Banana()};
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
        
        public List<Plant> Food
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
            this.Points += aditionalPoints;
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
            private set { this.points = value; }
        }
    }
}
