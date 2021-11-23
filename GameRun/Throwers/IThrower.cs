﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRun.Throwers
{
    public interface IThrower
    {
        bool IsEnable { get; set; }
        int GetResult();
    }
}
