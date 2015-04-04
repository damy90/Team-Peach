using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class Pear : Plant, IBuyable
    {
        const int defaultPrice = 20;
        public int Price
        {
            get { return Pear.defaultPrice; }
        }
    }
}
