using System;
using System.Threading.Tasks;

namespace AlternatingIllumination.Interfaces
{
    public interface IProfessionalCurrentAndWavelength
    {
        float CurrentTM { get; set; }
        string WavelengthTM { get; set; }
    }

    public interface IUniversalFlashingCurrentProvider
    {
        Task<IProfessionalCurrentAndWavelength> GetUniversalCurrentAsync();
    }
}
