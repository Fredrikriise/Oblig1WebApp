using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oblig1WebApp.BLL;
using Oblig1WebApp.Controllers;
using Oblig1WebApp.DAL;

namespace Enhetstest
{
    [TestClass]
    public class AvgangControllerTest
    {
        [TestMethod]
        public void hentAlleAvgangerTest_OK()
        {
            // Arrange
            var controller = new AvgangController(new DBBLL(new RepositoryStub()));


        }
    }
}
