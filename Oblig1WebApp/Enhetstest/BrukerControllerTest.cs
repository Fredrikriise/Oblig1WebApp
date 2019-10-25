using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcContrib.TestHelper;
using BLL;
using Oblig1WebApp.Controllers;
using DAL;
using Model;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Enhetstest
{
    [TestClass]
    public class BrukerControllerTest
    {
        [TestMethod]
        public void Kontrollpanel_Test_OK()
        {
            // Arrange
            var SessionMock = new TestControllerBuilder();
            var controller = new BrukerController(new DBBLL(new RepositoryStub()));
            SessionMock.InitializeController(controller);

            controller.Session["LoggetInn"] = true;

            // Act 
            var resultat = (ViewResult)controller.Kontrollpanel();

            // Assert
            Assert.AreEqual(resultat.ViewName, "");
        }

        [TestMethod]
        public void Kontrollpanel_Test_Feilet()
        {
            // Arrange
            var SessionMock = new TestControllerBuilder();
            var controller = new BrukerController(new DBBLL(new RepositoryStub()));
            SessionMock.InitializeController(controller);

            controller.Session["LoggetInn"] = false;

            // Act 
            var resultat = (RedirectToRouteResult)controller.Kontrollpanel();

            // Assert
            Assert.AreEqual(resultat.RouteName, "");
            Assert.AreEqual(resultat.RouteValues.Values.First(), "LoggInn");
        }

        [TestMethod]
        public void LoggInn_Test()
        {
            // Arrange 
            var controller = new BrukerController(new DBBLL(new RepositoryStub()));

            // Act
            var resultat = (ViewResult)controller.LoggInn();

            // Assert
            Assert.AreEqual(resultat.ViewName, "");
        }

        [TestMethod]
        public void LoggInn_Test_OK()
        {
            // Arrange 
            var SessionMock = new TestControllerBuilder();
            var controller = new BrukerController(new DBBLL(new RepositoryStub()));
            SessionMock.InitializeController(controller);

            controller.Session["LoggetInn"] = true;

            var innlogget = new adminBruker()
            {
                brukernavn = "Frank",
                passord = "hdfshfud"
            };

            // Act
            var resultat = (ViewResult)controller.LoggInn(innlogget);

            // Assert
            Assert.AreEqual(resultat.ViewName, "Kontrollpanel");
            Assert.AreEqual(true, resultat.ViewData["Innlogget"]);
        }

        [TestMethod]
        public void LoggInn_Test_Feilet()
        {
            // Arrange 
            var SessionMock = new TestControllerBuilder();
            var controller = new BrukerController(new DBBLL(new RepositoryStub()));
            SessionMock.InitializeController(controller);

            controller.Session["LoggetInn"] = false;

            var innlogget = new adminBruker()
            {
                brukernavn = "",
                passord = "hdfshfud"
            };

            // Act
            var resultat = (ViewResult)controller.LoggInn(innlogget);

            // Assert
            Assert.AreEqual(resultat.ViewName, "");
            Assert.AreEqual(false, resultat.ViewData["Innlogget"]);
        }

        [TestMethod]
        public void RegistrerBruker_Test()
        {
            // Arrange 
            var controller = new BrukerController(new DBBLL(new RepositoryStub()));

            // Act
            var resultat = (ViewResult)controller.RegistrerBruker();

            // Assert
            Assert.AreEqual(resultat.ViewName, "");
        }

        // Fikse med session
        [TestMethod]
        public void RegistrerBruker_Test_OK()
        {
            // Arrange
            var SessionMock = new TestControllerBuilder();
            var controller = new BrukerController(new DBBLL(new RepositoryStub()));
            SessionMock.InitializeController(controller);

            var bruker = new adminBruker()
            {
                brukernavn = "Frankerino",
                passord = "hdfshfuger"
            };

            // Act
            var resultat = (ViewResult)controller.RegistrerBruker(bruker);

            // Assert
            Assert.AreEqual(resultat.ViewName, "");
            Assert.AreEqual(true, resultat.ViewData["RegistrertBruker"]);
            Assert.AreEqual(false, resultat.ViewData["Brukernavntatt"]);
        }

        [TestMethod]
        public void RegistrerBruker_Test_Feilet_brukernavn()
        {
            // Arrange
            var SessionMock = new TestControllerBuilder();
            var controller = new BrukerController(new DBBLL(new RepositoryStub()));
            SessionMock.InitializeController(controller);

            var bruker = new adminBruker()
            {
                brukernavn = "",
                passord = "huhuhuhuhu"
            };

            // Act
            var resultat = (ViewResult)controller.RegistrerBruker(bruker);

            // Assert
            Assert.AreEqual(resultat.ViewName, "");
        }

        [TestMethod]
        public void RegistrerBruker_Test_Feilet_passord()
        {
            // Arrange
            var SessionMock = new TestControllerBuilder();
            var controller = new BrukerController(new DBBLL(new RepositoryStub()));
            SessionMock.InitializeController(controller);

            var bruker = new adminBruker()
            {
                brukernavn = "huhuhuhuhu",
                passord = ""
            };

            // Act
            var resultat = (ViewResult)controller.RegistrerBruker(bruker);

            // Assert
            Assert.AreEqual(resultat.ViewName, "");
        }

        [TestMethod]
        public void LoggUt_Test()
        {
            // Arrange
            var SessionMock = new TestControllerBuilder();
            var controller = new BrukerController(new DBBLL(new RepositoryStub()));
            SessionMock.InitializeController(controller);

            controller.Session["LoggetInn"] = false;

            // Act 
            var resultat = (RedirectToRouteResult)controller.LoggUt();

            // Assert
            Assert.AreEqual(resultat.RouteName, "");
            Assert.AreEqual(resultat.RouteValues.Values.First(), "LoggInn");
        }

        [TestMethod]
        public void listBrukere_Test()
        {
            // Arrange
            var controller = new BrukerController(new DBBLL(new RepositoryStub()));
            var forventetResultat = new List<adminBruker>();

            var bruker = new adminBruker()
            {
                brukernavn = "johnny",
                passord = "hfshf"
            };
            forventetResultat.Add(bruker);
            forventetResultat.Add(bruker);
            forventetResultat.Add(bruker);

            // Act
            var resultat = (ViewResult)controller.listBrukere();
            var resultatListe = (List<adminBruker>)resultat.Model;

            // Assert
            Assert.AreEqual(resultat.ViewName, "");

            for (int i = 0; i < resultatListe.Count; i++)
            {
                Assert.AreEqual(forventetResultat[i].brukernavn, resultatListe[i].brukernavn);
                Assert.AreEqual(forventetResultat[i].passord, resultatListe[i].passord);
            }
        }

    }
}
