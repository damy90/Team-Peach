﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public interface ISoundable
    {
        string SoundPath{get;}
        void MakeSound();
    }
}
