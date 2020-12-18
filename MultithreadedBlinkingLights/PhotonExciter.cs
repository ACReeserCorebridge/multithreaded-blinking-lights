using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadedBlinkingLights
{
    public class PhotonExciter : IPhotonExciter
    {
        ILightHardwareSource _hardware;

        public PhotonExciter(ILightHardwareSource hardware)
        {
            _hardware = hardware;
        }

        public async Task Emit()
        {
            ElectromagneticUtils.ResetEMOutput();

            string[] amps = _hardware.CurrentAmperage();
            ConsoleColor[] wavelength = _hardware.CurrentWavelengths();
            for (int i = 0; i < amps.Length; i++)
            {
                if (i > 0)
                    Console.Write('|');
                Console.ForegroundColor = wavelength[i];
                Console.Write(amps[i]);
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.Write("\r\n");

            await Task.Delay(1);
        }
    }
}
