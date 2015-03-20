using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public struct Condition
    {
        public int Happiness { get; set; }
        public int Feed { get; set; }
        public int Cleanliness { get; set; }
        public int Energy { get; set; }

        public Condition(int initialValue)
            : this()
        {
            Happiness = initialValue;
            Feed = initialValue;
            Cleanliness = initialValue;
            Energy = initialValue;
        }
    }
}
