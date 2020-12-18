using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadedBlinkingLights
{
    public class FixtureProvider : IFixtureProvider
    {
        readonly ILightHardwareSource _hardware;

        public FixtureProvider(
            ILightHardwareSource hardware)
        {
            _hardware = hardware;
        }

        public void Start()
        {
            Parallel.For(0, _hardware.GetNumberOfAvailableDiodes(), async (int i) => await BeginIlluminating(i));
        }

        public async Task BeginIlluminating(int i)
        {
            await Task.Delay(10);
        }
    }
}
