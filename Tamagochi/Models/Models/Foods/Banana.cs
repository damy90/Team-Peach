using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class Banana : Plant, IBuyable
    {
        const int defaultPrice = 10;
        public int Price
        {
            get { return Banana.defaultPrice; }
        }
    }
}
