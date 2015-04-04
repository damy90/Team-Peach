using System;
using System.Collections.Generic;

namespace Models
{
    public class Carp : Fish, IHerbivorous
    {
        #region Constants
        private const string CarpPictureDefault = @"...\...\Resourses\Pictures\ParrotPicture_01.jpg";
        private const string CarpPictureEating = @"...\...\Resourses\Pictures\ParrotPicture_02.jpg";
        private const string CarpPictureUnahppy =  @"...\...\Resourses\Pictures\ParrotPicture_03.jpg";
        #endregion
        #region Fileds
        private List<Plant> plantsFoodAllowed = new List<Plant>();
        #endregion

        #region Constructors
        public Carp()
            : base()
        {
            base.Pictures = new string[3] { CarpPictureDefault, CarpPictureEating, CarpPictureUnahppy };
            this.PlantsFoodAllowed = new List<Plant> { new Apple(), new Banana() };
        }

        public Carp(Gender  sex, string name)
            : base(sex, name)
        {
        }

        public Carp(Gender  sex, string name, Condition condition)
            : base(sex, name, condition)
        {
        }
        #endregion

        public List<Plant> PlantsFoodAllowed
        {
            get { return this.plantsFoodAllowed; }
            private set { this.plantsFoodAllowed = value; }
        }
    }
}
