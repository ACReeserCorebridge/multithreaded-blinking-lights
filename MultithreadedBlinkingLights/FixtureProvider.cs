using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadedBlinkingLights
{
    public class FixtureProvider : IFixtureProvider
    {
        readonly ILightHardwareSource _hardware;
        readonly IServiceProvider _serviceProvider;
        readonly IPowerSupply _powerSupply;

        private List<ILightEmittingFixture> fixtures = new List<ILightEmittingFixture>();

        public FixtureProvider(
            ILightHardwareSource hardware,
            IServiceProvider serviceProvider,
            IPowerSupply powerSupply
            )
        {
            _hardware = hardware;
            _serviceProvider = serviceProvider;
            _powerSupply = powerSupply;
        }

        public void Start()
        {
            int numOfDiodes = _hardware.GetNumberOfAvailableDiodes();
            fixtures = InitializeFixtures(numOfDiodes);
            Parallel.For(0, numOfDiodes, async (int fixtureIndex) => await IlluminateUntilPowerGoesOut(fixtureIndex));
        }

        private List<ILightEmittingFixture> InitializeFixtures(int numOfDiodes)
        {
            var result = new List<ILightEmittingFixture>();
            for (int i = 0; i < numOfDiodes; i++)
            {
                if (i == 0)
                    result.Add(
                        _serviceProvider.GetService(typeof(ConstantlyEmittingLightFixture)) as ConstantlyEmittingLightFixture
                        );
                else
                    result.Add(
                        _serviceProvider.GetService(typeof(IntermittentLightFixture)) as IntermittentLightFixture
                        );
            }
            return result;
        }

        public async Task IlluminateUntilPowerGoesOut(int fixtureIndex)
        {
            ILightEmittingFixture fixture = fixtures[fixtureIndex];

            while (_powerSupply.IsOn && !_hardware.IsBurnOut(fixtureIndex))
            {
                CurrentAndWavelength x = await fixture.GetCurrentAndWavelength(fixtureIndex);
                
                if (x.NormalizedCurrent > 0)
                {
                    _hardware.IncreaseAmperage(fixtureIndex, x.Wavelength);
                }
                else
                {
                    _hardware.ReduceAmperage(fixtureIndex);
                }

                await Task.Delay(CONSTANTS.PERCEPTUAL_PHOTON_THRESHOLD_MS);

            }
        }
    }
}
