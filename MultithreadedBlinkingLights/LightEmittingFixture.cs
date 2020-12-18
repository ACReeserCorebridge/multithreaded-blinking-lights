using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadedBlinkingLights
{
    /// <summary>
    /// convenience abstraction for things that emit light
    /// </summary>
    public abstract class LightEmittingFixture: ILightEmittingFixture
    {
        protected readonly ILightHardwareSource _hardware;

        public LightEmittingFixture(
            ILightHardwareSource hardware)
        {
            _hardware = hardware;
        }

        public abstract Task<CurrentAndWavelength> GetCurrentAndWavelength(int fixtureIndex);
    }
}
