using System;
using System.Collections.Generic;

namespace Models
{
    class Piranha : Fish, ICarnivorous
    {
        #region Constants
        private const string PiranhaPictureDefault = @"...\...\Resourses\Pictures\PiranhaPicture_01.jpg";
        private const string PiranhaPictureUnahppy = @"...\...\Resourses\Pictures\PiranhaPicture_02.jpg";
        private const string PiranhaPictureEating =  @"...\...\Resourses\Pictures\PiranhaPicture_03.jpg";
	    #endregion

        #region Constructors
        public Piranha()
            : base()
        {
            base.Pictures = new string[3] { PiranhaPictureDefault, PiranhaPictureUnahppy, PiranhaPictureEating};
        }

        public Piranha(Gender  sex, string name)
            : base(sex, name)
        {
        }

        public Piranha(Gender sex, string name, Condition condition)
            : base(sex, name, condition)
        {
        }
        #endregion
        public List<Meat> MeatFoodAllowed
        {
            get { throw new NotImplementedException(); }
        }

        public void Hunt()
        {
            throw new NotImplementedException();
        }
    }
}
