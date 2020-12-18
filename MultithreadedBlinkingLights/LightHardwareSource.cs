using System;
using System.Collections.Generic;
using System.Text;

namespace MultithreadedBlinkingLights
{
    public class LightHardwareSource: ILightHardwareSource
    {
        public int GetNumberOfAvailableDiodes()
        {
            return CONSTANTS.NUM_AVAIL_DIODES_TEST;
        }

        private string[] _flavoredAmps = new string[CONSTANTS.NUM_AVAIL_DIODES_TEST];
        private bool[] _burnedOutBulbs = new bool[CONSTANTS.NUM_AVAIL_DIODES_TEST] { false, false, false, false, false, false, false, false, false, false, false, false };

        public void IncreaseAmperage(int i, string flavor)
        {
            _flavoredAmps[i] = "█";
        }

        public void ReduceAmperage(int i)
        {
            _flavoredAmps[i] = ".";
        }

        public string[] FlavoredAmperage()
        {
            return _flavoredAmps;
        }

        public bool IsBurnOut(int i)
        {
            return _burnedOutBulbs[i];
        }
    }
}
