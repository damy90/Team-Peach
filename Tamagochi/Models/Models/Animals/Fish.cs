using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public abstract class Fish : Animal, IAnimal
    {
        #region Constructors
        protected Fish()
            : base()
        {
        }

        protected Fish(Gender sex, string name)
            : base(sex, name)
        { 
        }

        protected Fish(Gender sex, string name, Condition condition)
            : base(sex, name, condition)
        {
        }
        #endregion
    }
}
