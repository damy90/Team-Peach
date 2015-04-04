using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public interface ICarnivorous
    {
        List<Meat> Food { get; }

        void Hunt();
    }
}
