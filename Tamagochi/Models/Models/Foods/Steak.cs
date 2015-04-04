using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class Steak : Meat, IBuyable
    {
        private const int defaultPrice = 50;
        public int Price
        {
            get { return Steak.defaultPrice; }
        }
    }
}
