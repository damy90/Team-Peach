using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public interface IPlayable
    {
        int Points { get; }

        void Play();
        void AddPoints(int aditionalPoints);
    }
}
