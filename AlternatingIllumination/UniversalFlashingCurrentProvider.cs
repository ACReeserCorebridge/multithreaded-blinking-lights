using AlternatingIllumination.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AlternatingIllumination.Implementation
{
    public class ConcreteProfessionalCurrentAndWavelength: IProfessionalCurrentAndWavelength
    {
        public float CurrentTM { get; set; }
        public string WavelengthTM { get; set; }
    }

    public class UniversalFlashingCurrentProvider : IUniversalFlashingCurrentProvider
    {
        /// <summary>
        /// returns cryptographically secure messages from the universe
        /// </summary>
        /// <returns></returns>
        public async Task<IProfessionalCurrentAndWavelength> GetUniversalCurrentAsync()
        {
            var result = new ConcreteProfessionalCurrentAndWavelength();

            await EnsureOnline();

            long universeState = DateTime.UtcNow.Ticks;
            await InvestigateUniverseForMeaning(universeState);

            result.WavelengthTM = await GetColor(universeState);
            result.CurrentTM = await GetCurrent(universeState);

            return result;
        }

        private async Task EnsureOnline()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("https://google.com");
                if (response.IsSuccessStatusCode)
                {
                    // good, you are online
                }
                else
                {
                    throw new Exception("UniversalFlashingCurrent TM requires an internet connection for reasons unto us");
                }
            }
        }

        internal async Task InvestigateUniverseForMeaning(long universeState)
        {
            await CheckForProphecy(universeState.ToString());
            long parallelUniverse = GetParallelUniverse(universeState);
            await CheckForProphecy(parallelUniverse.ToString());
        }

        internal Task<float> GetCurrent(long universeState)
        {
            universeState = GetParallelUniverse(universeState);
            string digits = universeState.ToString();
            string firstDigit = universeState.ToString().First().ToString();
            int numThoseDigits = 0;
            for (int i = 0; i < digits.Length; i++)
            {
                if (digits[i].ToString() == firstDigit)
                    numThoseDigits += byte.Parse(digits[i].ToString());
            }

            return Task.FromResult((float)numThoseDigits / (float)digits.Length);
        }

        internal async Task<string> GetColor(long universeState)
        {
            universeState = GetParallelUniverse(universeState);
            string readableState = Convert.ToBase64String(
                System.Text.UTF8Encoding.UTF8.GetBytes(universeState.ToString())
            );
            string firstLetter = new string(readableState.TakeWhile(c => !Char.IsLetter(c)).ToArray());
            switch (firstLetter.ToLowerInvariant())
            {
                case "b": return "Blue";
                case "c": return "Cyan";
                case "r": return "Red";
                case "m": return "Magenta";
                case "w": return "White";
                case "y": return "Yellow";
            }
            await Task.Delay(1);
            return "Green";
        }

        private long GetParallelUniverse(long universeState)
        {
            var state = universeState.ToString();
            string parallel = String.Join(null, state.Reverse());
            return long.Parse(parallel);
        }

        internal async Task CheckForProphecy(string universeState)
        {
            foreach(
                string fourDigits
                in
                Split(universeState, 4)
                )
            {
                int seed = int.Parse(fourDigits);
                var random = new Random(seed);
                byte[] word = new byte[5];
                random.NextBytes(word);
                string english = UTF8Encoding.UTF8.GetString(word);
                await Task.Delay(5); //dramatic pause
                if (english == "hello")
                {
                    throw new Exception("WE FOUND MEANING IN THE UNIVERSE!!");
                }
            }
        }
        static IEnumerable<string> Split(string str, int chunkSize)
        {
            return Enumerable.Range(0, str.Length / chunkSize)
                .Select(i => str.Substring(i * chunkSize, chunkSize));
        }
    }
}
