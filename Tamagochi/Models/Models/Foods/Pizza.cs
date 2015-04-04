using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class Pizza : Meat, IBuyable
    {
        const int defaultPrice = 30;
        public int Price
        {
            get { return Pizza.defaultPrice; }
        }
    }
}
