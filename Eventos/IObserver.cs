﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos
{
    public interface IObserver
    {
        void Update(Event subjectEvent);
    }
}
