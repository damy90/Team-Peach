using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Fish : Animal
    {
        #region Fields
        private List<Food> food;
        #endregion

        #region Constructors
        public Fish(Gender sex, string name)
            : base(sex, name)
        {
        }

        public Fish(Gender sex, string name, Condition condition)
            : base(sex, name, condition)
        {
        }
        #endregion

        public List<Food> Food
        {
            get
            {
                return this.food;
            }
            set
            {
                this.food = value;
            }
        }
    }
}
