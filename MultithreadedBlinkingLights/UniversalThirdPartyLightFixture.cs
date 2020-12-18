using AlternatingIllumination.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadedBlinkingLights
{
    public class UniversalThirdPartyLightFixture : LightEmittingFixture
    {
        private readonly IUniversalFlashingCurrentProvider _universal;
        public UniversalThirdPartyLightFixture(
            ILightHardwareSource hardware,
            IUniversalFlashingCurrentProvider universal) : base (hardware)
        {
            _universal = universal;
        }

        public override async Task<CurrentAndWavelength> GetCurrentAndWavelength(int fixtureIndex)
        {
            // bug report! users on intranets see Exceptions here
            IProfessionalCurrentAndWavelength result = await _universal.GetUniversalCurrentAsync();
            return new CurrentAndWavelength()
            {
                NormalizedCurrent = result.CurrentTM,
                Wavelength = result.WavelengthTM
            };
        }
    }
}
