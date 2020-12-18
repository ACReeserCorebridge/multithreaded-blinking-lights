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

            Console.WriteLine(
                String.Join('|', _hardware.FlavoredAmperage())
            );

            await Task.Delay(1);
        }
    }
}
