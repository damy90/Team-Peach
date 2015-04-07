using System;
using System.Collections.Generic;

namespace Models
{
    public class Carp : Fish, IAnimal, IHerbivorous
    {
        #region Constants
        private const string CarpPictureDefault = @"..\..\..\Models\Resourses\Pictures\Carp\Picture_01.jpg";
        private const string CarpPictureEating = @"..\..\..\Models\Resourses\Pictures\Carp\Picture_02.jpg";
        private const string CarpPictureUnahppy = @"..\..\..\Models\Resourses\Pictures\Carp\Picture_03.jpg";
        #endregion
        #region Fileds
        private List<Plant> plantsFoodAllowed = new List<Plant>();
        #endregion

        #region Constructors
        internal Carp()
            : base()
        {
            base.Pictures = new string[3] { CarpPictureDefault, CarpPictureEating, CarpPictureUnahppy };
            this.PlantsFoodAllowed = new List<Plant> { new Apple(), new Banana() };
        }

        internal Carp(Gender  sex, string name)
            : base(sex, name)
        {
        }

        internal Carp(Gender  sex, string name, Condition condition)
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
