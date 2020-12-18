using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadedBlinkingLights
{
    /// <summary>
    /// convenience abstraction for things that emit light
    /// </summary>
    public class LightEmittingFixture: ILightEmittingFixture
    {
        readonly ILightHardwareSource _hardware;

        public LightEmittingFixture(
            ILightHardwareSource hardware)
        {
            _hardware = hardware;
        }

        public Task<CurrentAndWavelength> GetCurrentAndWavelength(int fixtureIndex)
        {
            return Task.FromResult(
                new CurrentAndWavelength()
                {
                    NormalizedCurrent = 1,
                    Wavelength = ""
                }
            );
        }
    }
}
