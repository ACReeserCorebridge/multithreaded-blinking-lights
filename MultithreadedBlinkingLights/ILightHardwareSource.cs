using System;
using System.Collections.Generic;
using System.Text;

namespace MultithreadedBlinkingLights
{
    public interface ILightHardwareSource
    {
        int GetNumberOfAvailableDiodes();
        bool IsBurnOut(int i);

        void IncreaseAmperage(int i, string flavor);
        void ReduceAmperage(int i);

        string[] FlavoredAmperage();
    }
}
