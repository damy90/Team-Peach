using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public abstract class Bird : Animal
    {
        #region Constructors
        internal Bird()
            : base()
        {
        }

        internal Bird(Gender sex, string name)
            : base(sex, name)
        {
        }

        internal Bird(Gender sex, string name, Condition condition)
            : base(sex, name, condition)
        {
        }
        #endregion

        public void AddPoints()
        {
            throw new NotImplementedException();
        }
    }
}
