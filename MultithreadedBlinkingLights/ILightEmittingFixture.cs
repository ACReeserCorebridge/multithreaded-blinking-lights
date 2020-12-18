using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadedBlinkingLights
{
    public interface ILightEmittingFixture
    {
        Task<CurrentAndWavelength> GetCurrentAndWavelength(int fixtureIndex);
    }
}
