using AlternatingIllumination.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace ProfessionalTestSuite
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task Test()
        {
            var c = new UniversalFlashingCurrentProvider();
            var r = await c.GetUniversalCurrentAsync();
            Assert.IsNotNull(r);
        }
    }
}
