using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class FishMeat : Meat, IBuyable
    {
        const int defaultPrice = 25;
        public int Price
        {
            get { return FishMeat.defaultPrice; }
        }
    }
}
