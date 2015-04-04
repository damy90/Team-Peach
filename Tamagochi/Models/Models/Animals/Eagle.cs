namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.Media;

    public class Eagle : Bird, ICarnivorous, IPlayable, ISoundable
    {
        #region Constants
        private const string EagleSoundPath = @"...\...\Resourses\Sound\EagleSound.wav";
        private const string EaglePictureDefault = @"...\...\Resourses\Pictures\EaglePicture_01.jpg";
        private const string EaglePictureEating = @"...\...\Resourses\Pictures\EaglePicture_02.jpg";
        private const string EaglePictureUnhappy =  @"...\...\Resourses\Pictures\EaglePicture_03.jpg";
        private const string EaglePicturePlaying = @"...\...\Resourses\Pictures\EaglePicture_04.jpg";
        private const int HappinessIncrement = 20;
        private const int FeedIncrement = 20;
        private const int PlayPointsIncrement = 20;
        #endregion

        #region Fields
        List<Meat> meatFoodAllowed = new List<Meat>();
        int points;
        #endregion

        #region Constructors
        public Eagle()
            : base()
        {
            base.Pictures = new string[4] {EaglePictureDefault, EaglePictureEating, EaglePictureUnhappy, EaglePicturePlaying };
            this.MeatFoodAllowed = new List<Meat> { new Drumstick(), new Pizza(), new Steak() };
        }

        public Eagle(Gender sex, string name)
            : base(sex, name)
        {
        }

        public Eagle(Gender sex, string name, Condition condition)
            : base(sex, name, condition)
        {
        }
        #endregion

        public List<Meat> MeatFoodAllowed
        {
            get
            {
                return this.meatFoodAllowed;
            }
            private set
            {
                if (value != null)
                {
                    this.meatFoodAllowed = value;
                }
                else
                {
                    throw new ArgumentNullException("List of allowed foods cannot be null");
                }
            }
        }

        public void Hunt()
        {
            double incrementMult = new Random().Next(0, 1);
            var modifiedCondition = this.CurrentCondition;
            modifiedCondition.Feed += (int)(incrementMult * FeedIncrement);
            modifiedCondition.Happiness += (int)(incrementMult * HappinessIncrement);
            this.CurrentCondition = modifiedCondition;
        }

        public void Play()
        {
            double incrementMult = new Random().Next(0, 1);
            var modifiedCondition = this.CurrentCondition;            
            modifiedCondition.Happiness += (int)(incrementMult * HappinessIncrement);
            this.CurrentCondition = modifiedCondition;
            this.AddPoints((int)(incrementMult * PlayPointsIncrement));
        }

        public void AddPoints(int aditionalPoints)
        {
            this.Points += aditionalPoints;
        }

        public string SoundPath
        {
            get
            {
                return EagleSoundPath;
            }
        }

        public void MakeSound()
        {
            SoundPlayer playSound = new SoundPlayer(EagleSoundPath);
            playSound.Play();
        }

        public int Points
        {
            get 
            { 
                return this.points; 
            }
            private set
            {
                this.points = value;
            }
        }
    }
}
