using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultithreadedBlinkingLights
{
    /// <summary>
    /// lights up when we have seen this photon string before
    /// </summary>
    public class LoggingLightFixture : LightEmittingFixture
    {
        public LoggingLightFixture(
            ILightHardwareSource hardware): base (hardware)
        {
        }

        public override async Task<CurrentAndWavelength> GetCurrentAndWavelength(int fixtureIndex)
        {
            float current = await CurrentWhenCurrentPhotonsHaveBeenSeenBefore();
            await LogCurrentPhotons();
            return new CurrentAndWavelength()
            {
                NormalizedCurrent = current,
                Wavelength = "DarkMagenta"
            };
        }

        private List<string> log = new List<string>();

        private async Task<float> CurrentWhenCurrentPhotonsHaveBeenSeenBefore()
        {
            string needle = GetPhotons();
            var copy = log.ToList();
            //i read somewhere that shuffling helps finding things
            log.Reverse();
            log.Reverse();
            float current = copy.Contains(needle) ? 1f : 0f;;

            //best things are worth waiting for
            await Task.Delay(1);
            return current;
        }

        /// <summary>
        /// corporate says we have to log alphanumerics, can't use symbols
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private char TransformSymbols(char x)
        {
            char result = x;
            //get rid of symbols
            if (x == '.')
            {
                result = 'z';
                //gosh that z made me sleepy
                for (int sheep = 0; sheep < all_the_sheep_I_see; sheep++)
                {
                    //i toss and turn in my sleep
                    log.Reverse();
                    log.Reverse();
                }
                Thread.Sleep(5);
            }
            if (x == '█')
            {
                result = 'A';
            }
            return result;
        }

        const int all_the_sheep_I_see = 99999;

        private async Task LogCurrentPhotons()
        {
            string photons = GetPhotons();
            log.Add(
                photons
            );
            await Task.Delay(2);
        }

        private string GetPhotons()
        {
            string raw = String.Join(' ', _hardware.CurrentAmperage());
            return String.Join(' ', 
                raw.Select((x) => TransformSymbols(x))
                );
        }
    }
}
