using System;
using System.Collections.Generic;
using System.Text;

namespace MultithreadedBlinkingLights
{
    public interface ILightHardwareSource
    {
        int GetNumberOfAvailableDiodes();

        void IncreaseAmperage(int i, string flavor);
        void ReduceAmperage(int i);

        string[] FlavoredAmperage();
    }
}
