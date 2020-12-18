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

        private string[] _amps = new string[CONSTANTS.NUM_AVAIL_DIODES_TEST];
        private ConsoleColor[] _wavelength = new ConsoleColor[CONSTANTS.NUM_AVAIL_DIODES_TEST];
        private bool[] _burnedOutBulbs = new bool[CONSTANTS.NUM_AVAIL_DIODES_TEST];

        public void IncreaseAmperage(int i, string wavelength)
        {
            _amps[i] = "█";
            if (Enum.TryParse<ConsoleColor>(wavelength, true, out ConsoleColor color))
            {
                _wavelength[i] = color;
            }
            else
            {
                _wavelength[i] = ConsoleColor.Red;
            }
        }

        public void ReduceAmperage(int i)
        {
            _amps[i] = ".";
        }

        public string[] CurrentAmperage()
        {
            return _amps;
        }

        public ConsoleColor[] CurrentWavelengths()
        {
            return _wavelength;
        }

        public bool IsBurnOut(int i)
        {
            return _burnedOutBulbs[i];
        }
    }
}
