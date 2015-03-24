using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public abstract class Bird : Animal
    {
        public Bird(Gender sex, string name)
            : base(sex, name)
        {
        }

        public Bird(Gender sex, string name, Condition condition)
            : base(sex, name, condition)
        {
        }

        public int Points
        {
            get { throw new NotImplementedException(); }
        }

        public void AddPoints()
        {
            throw new NotImplementedException();
        }
    }
}
