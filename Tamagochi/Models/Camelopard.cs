using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class Camelopard : Mammal, IHerbivorous
    {

        public List<Plant> Food
        {
            get { throw new NotImplementedException(); }
        }
    }
}
