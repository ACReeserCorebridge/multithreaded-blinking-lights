using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadedBlinkingLights
{
    public class UniversalThirdPartyLightFixture : LightEmittingFixture
    {
        public UniversalThirdPartyLightFixture(
            ILightHardwareSource hardware): base (hardware)
        {
        }

        public override Task<CurrentAndWavelength> GetCurrentAndWavelength(int fixtureIndex)
        {
            return Task.FromResult(
                new CurrentAndWavelength()
                {
                    NormalizedCurrent = 1,
                    Wavelength = "Green"
                }
            );
        }
    }
}
