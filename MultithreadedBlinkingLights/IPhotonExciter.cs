﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadedBlinkingLights
{
    public interface IPhotonExciter
    {
        Task Emit();
    }
}