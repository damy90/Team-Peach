using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class Dog : Mammal, ICarnivorous
    {
        public List<Meat> Food
        {
            get { throw new NotImplementedException(); }
        }

        public void Hunt()
        {
            throw new NotImplementedException();
        }
    }
}
