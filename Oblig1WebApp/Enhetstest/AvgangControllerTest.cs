using BLL;
using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using MvcContrib.TestHelper;
using Oblig1WebApp.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Enhetstest
{
    [TestClass]
    public class AvgangControllerTest
    {
        [TestMethod]
        public void hentAlleAvganger_Test_OK()
        {
            // Arrange
            var controller = new AvgangController(new DBBLL(new RepositoryStub()));
            var avgangListe = new List<Avgang>();
            var innJsAvgang = new Avgang()
            {
                id = 1,
                _forsteAvgang = "Langhus",
                _sisteAvgang = "Holmlia"
            };
            avgangListe.Add(innJsAvgang);

            // Act
            var resultat = (string)controller.hentAlleAvganger();
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(avgangListe);
            // Assert
            Assert.AreEqual(json, resultat);
        }

        [TestMethod]
        public void hentAvgangInfo_Test_OK()
        {
            var controller = new AvgangController(new DBBLL(new RepositoryStub()));
            var innJsAvgang = new Avgang()
            {
                id = 1,
                _forsteAvgang = "Langhus",
                _sisteAvgang = "Holmlia"
            };

            // Act
            var resultat = (string)controller.hentAvgangInfo(1);
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(innJsAvgang);

            // Assert
            Assert.AreEqual(json, resultat);
        }

        [TestMethod]
        public void hentAvgangInfo_Test_Feilet()
        {
            // Arrange
            var controller = new AvgangController(new DBBLL(new RepositoryStub()));
            var innJsAvgang = new Avgang()
            {
                id = 1,
                _forsteAvgang = "Langhus",
                _sisteAvgang = "Holmlia"
            };
            
            // Act
            var resultat = (string)controller.hentAvgangInfo(0);

            // Assert
            Assert.AreNotEqual(innJsAvgang.id, resultat);
        }

        [TestMethod]
        public void registrerAvgang_Test_OK()
        {

            var controller = new AvgangController(new DBBLL(new RepositoryStub()));

            var innJsAvgang = new Avgang()
            {
                id = 1,
                _forsteAvgang = "Langhus",
                _sisteAvgang = "Holmlia"
            };

            // Act
            var resultat = (string)controller.registerAvgang(innJsAvgang);
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize("OK");

            // Assert
            Assert.AreEqual(json, resultat);

        }

        [TestMethod]
        public void hentAlleVisAvganger_Test_OK()
        {
            // Arrange
            var SessionMock = new TestControllerBuilder();
            var controller = new AvgangController(new DBBLL(new RepositoryStub()));
            SessionMock.InitializeController(controller);

            controller.Session["fraLokasjon"] = "Langhus";
            controller.Session["tilLokasjon"] = "Holmlia";

            var avgangListe = new List<visAvgang>();
            var innJsAvgang = new visAvgang()
            {
                id = 1,
                forsteAvgang = "Langhus",
                sisteAvgang = "Holmlia",
                reiseTid = "15 minutter",
                spor = "Spor 1",
                togNummer = "L22",
                sone = 1,
                pris = 35
            };
            avgangListe.Add(innJsAvgang);

            // Act
            var resultat = (string)controller.hentAlleVisAvganger();
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(avgangListe);

            // Assert
            Assert.AreEqual(json, resultat);
        }

        [TestMethod]
        public void hentVisAvgangInfo_Test_OK()
        {
            var controller = new AvgangController(new DBBLL(new RepositoryStub()));
            var innJsAvgang = new visAvgang()
            {
                id = 1,
                forsteAvgang = "Langhus",
                sisteAvgang = "Holmlia",
                reiseTid = "15 minutter",
                spor = "Spor 1",
                togNummer = "L22",
                sone = 1,
                pris = 35
            };

            // Act
            var resultat = (string)controller.hentVisAvgangInfo(1);
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(innJsAvgang);

            // Assert
            Assert.AreEqual(json, resultat);
        }

        [TestMethod]
        public void hentVisAvgangInfo_Test_Feilet()
        {
            // Arrange
            var controller = new AvgangController(new DBBLL(new RepositoryStub()));
            var innJsAvgang = new visAvgang()
            {
                id = 1,
                forsteAvgang = "Langhus",
                sisteAvgang = "Holmlia"
            };

            // Act
            var resultat = (string)controller.hentVisAvgangInfo(0);

            // Assert
            Assert.AreNotEqual(innJsAvgang.id, resultat);
        }

        [TestMethod]
        public void registrerVisAvgang_Test_OK()
        {
            var controller = new AvgangController(new DBBLL(new RepositoryStub()));

            var innJsAvgang = new visAvgang()
            {
                id = 1,
                forsteAvgang = "Langhus",
                sisteAvgang = "Holmlia",
                reiseTid = "15 minutter",
                spor = "Spor 1",
                togNummer = "L22",
                sone = 1,
                pris = 35
            };

            // Act
            var resultat = (string)controller.registerVisAvgang(innJsAvgang);
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize("OK");

            // Assert
            Assert.AreEqual(json, resultat);

        }

        [TestMethod]
        public void hentAlleavgangstider_Test_OK()
        {
            // Arrange
            var controller = new AvgangController(new DBBLL(new RepositoryStub()));
            var avgangListe = new List<alleavgangstid>();
            var innJsAvgang = new alleavgangstid()
            {
                id = 1,
                avgangstid = "14:00",
                avgangstidRetur = "15:15"
            };
            avgangListe.Add(innJsAvgang);

            // Act
            var resultat = (string)controller.hentAlleavgangstider();
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(avgangListe);

            // Assert
            Assert.AreEqual(json, resultat);
        }

        [TestMethod]
        public void hentAlleavgangstid_Test_OK()
        {
            var controller = new AvgangController(new DBBLL(new RepositoryStub()));
            var innJsAvgang = new alleavgangstid()
            {
                id = 1,
                avgangstid = "14:00",
                avgangstidRetur = "15:15"
            };

            // Act
            var resultat = (string)controller.hentAlleavgangstid(1);
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(innJsAvgang);

            // Assert
            Assert.AreEqual(json, resultat);
        }

        [TestMethod]
        public void hentAlleavgangstid_Test_Feilet()
        {
            // Arrange
            var controller = new AvgangController(new DBBLL(new RepositoryStub()));
            var innJsAvgang = new alleavgangstid()
            {
                id = 1,
                avgangstid = "14:00",
                avgangstidRetur = "15:15"
            };

            // Act
            var resultat = (string)controller.hentAlleavgangstid(0);

            // Assert
            Assert.AreNotEqual(innJsAvgang.id, resultat);
        }

        [TestMethod]
        public void registrerAlleavgangstid_Test_OK()
        {
            // Arrange
            var controller = new AvgangController(new DBBLL(new RepositoryStub()));

            var innJsAvgang = new alleavgangstid()
            {
                id = 1,
                avgangstid = "14:00",
                avgangstidRetur = "15:15"
            };

            // Act
            var resultat = (string)controller.registrerAlleavgangstid(innJsAvgang);
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize("OK");

            // Assert
            Assert.AreEqual(json, resultat);
        }
    }
}
