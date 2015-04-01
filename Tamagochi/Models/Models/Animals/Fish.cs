using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Fish : Animal
    {
        #region Constructors
        public Fish()
            : base()
        {
        }

        public Fish(Gender sex, string name)
            : base(sex, name)
        { 
        }

        public Fish(Gender sex, string name, Condition condition)
            : base(sex, name, condition)
        {
        }
        #endregion
    }
}
