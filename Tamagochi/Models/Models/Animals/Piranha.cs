using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models.Animals
{
    class Piranha : Fish, ICarnivorous
    {
        #region Constructors
        public Piranha()
            : base()
        {
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
