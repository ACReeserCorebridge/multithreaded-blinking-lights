using System;
using System.Collections.Generic;
using System.Text;

namespace MultithreadedBlinkingLights
{
    public static class ElectromagneticUtils
    {
        public static void ResetEMOutput()
        {
            Console.CursorTop = 3;
            Console.CursorLeft = 0;
        }
    }

    public struct CurrentAndWavelength
    {
        public float NormalizedCurrent;
        public string Wavelength;
    }
}
