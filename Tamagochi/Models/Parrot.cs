using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class Parrot : Bird, IHerbivorous
    {
        public List<Plant> Food
        {
            get { throw new NotImplementedException(); }
        }
    }
}
