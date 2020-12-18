using System;
using System.Collections.Generic;
using System.Text;

namespace MultithreadedBlinkingLights
{
    public interface IPowerSupply
    {
        void TurnOn();
        void TurnOff();
    }
}
