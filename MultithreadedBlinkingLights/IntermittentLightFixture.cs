using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadedBlinkingLights
{
    public class IntermittentLightFixture : LightEmittingFixture
    {
        public IntermittentLightFixture(
            ILightHardwareSource hardware): base (hardware)
        {
        }

        public override async Task<CurrentAndWavelength> GetCurrentAndWavelength(int fixtureIndex)
        {
            float current = await GetIntermittentCurrent();
            return new CurrentAndWavelength()
            {
                NormalizedCurrent = current,
                Wavelength = "Yellow"
            };
        }

        private async Task<float> GetIntermittentCurrent()
        {
            // i heard it's good to introduce small delays when dealing with time
            // it's best practice in PHP I think
            await Task.Delay(
                (new Random()).Next(10, 200)
                );

            return byte.Parse(DateTime.UtcNow.Millisecond.ToString().FirstOrDefault().ToString()) > 4 ? 1f : 0f;
           
        }
    }
}
