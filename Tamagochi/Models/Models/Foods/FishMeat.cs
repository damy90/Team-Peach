﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class FishMeat : Meat, IBuyable
    {
        public int Price
        {
            get { throw new NotImplementedException(); }
        }
    }
}