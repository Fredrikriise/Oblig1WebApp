using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oblig1WebApp.BLL;
using Oblig1WebApp.Controllers;
using Oblig1WebApp.DAL;
using Oblig1WebApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Enhetstest
{
    [TestClass]
    public class BestillingControllerTest
    {
        // Bestilling

        [TestMethod]
        public void Bestilling_Test()
        {
            // Arrange 
            var controller = new BestillingController(new DBBLL(new RepositoryStub()));

            // Act
            var resultat = (ViewResult)controller.Bestilling();

            // Assert
            Assert.AreEqual(resultat.ViewName, "");
        }

        [TestMethod]
        public void listBestillinger_Test()
        {
            // Arrange
            var controller = new BestillingController(new DBBLL(new RepositoryStub()));
            var forventetResultat = new List<Bestilling>();

            var innBestilling = new Bestilling()
            {
                id = 1,
                fraLokasjon = "Langhus",
                tilLokasjon = "Holmlia",
                billettType = "En vei",
                utreiseDato = null,
                avgangstid = "14:00",
                returDato = null,
                avgangstidRetur = "15:15",
                voksen = 1,
                barn0_5 = 0,
                student = 0,
                honnoer = 0,
                vernepliktig = 0,
                barn6_17 = 0,
                barnevogn = 0,
                sykkel = 0,
                hundover_40cm = 0,
                kjaeledyrunder_40cm = 0
            };
            forventetResultat.Add(innBestilling);
            forventetResultat.Add(innBestilling);
            forventetResultat.Add(innBestilling);

            // Act 
            var resultat = (ViewResult)controller.listBestillinger();
            var resultatListe = (List<Bestilling>)resultat.Model;

            // Assert 
            Assert.AreEqual(resultat.ViewName, "");

            for (int i = 0; i < resultatListe.Count; i++)
            {
                Assert.AreEqual(forventetResultat[i].id, resultatListe[i].id);
                Assert.AreEqual(forventetResultat[i].fraLokasjon, resultatListe[i].fraLokasjon);
                Assert.AreEqual(forventetResultat[i].tilLokasjon, resultatListe[i].tilLokasjon);
                Assert.AreEqual(forventetResultat[i].billettType, resultatListe[i].billettType);
                Assert.AreEqual(forventetResultat[i].utreiseDato, resultatListe[i].utreiseDato);
                Assert.AreEqual(forventetResultat[i].avgangstid, resultatListe[i].avgangstid);
                Assert.AreEqual(forventetResultat[i].returDato, resultatListe[i].returDato);
                Assert.AreEqual(forventetResultat[i].avgangstidRetur, resultatListe[i].avgangstidRetur);
                Assert.AreEqual(forventetResultat[i].voksen, resultatListe[i].voksen);
                Assert.AreEqual(forventetResultat[i].barn0_5, resultatListe[i].barn0_5);
                Assert.AreEqual(forventetResultat[i].student, resultatListe[i].student);
                Assert.AreEqual(forventetResultat[i].honnoer, resultatListe[i].honnoer);
                Assert.AreEqual(forventetResultat[i].vernepliktig, resultatListe[i].vernepliktig);
                Assert.AreEqual(forventetResultat[i].barn6_17, resultatListe[i].barn6_17);
                Assert.AreEqual(forventetResultat[i].barnevogn, resultatListe[i].barnevogn);
                Assert.AreEqual(forventetResultat[i].sykkel, resultatListe[i].sykkel);
                Assert.AreEqual(forventetResultat[i].hundover_40cm, resultatListe[i].hundover_40cm);
                Assert.AreEqual(forventetResultat[i].kjaeledyrunder_40cm, resultatListe[i].kjaeledyrunder_40cm);
            }
        }

        [TestMethod]
        public void regBestilling_Test_OK()
        {
            // Arrange
            var controller = new BestillingController(new DBBLL(new RepositoryStub()));

            var innBestilling = new Bestilling()
            {
                id = 1,
                fraLokasjon = "Langhus",
                tilLokasjon = "Holmlia",
                billettType = "En vei",
                utreiseDato = null,
                avgangstid = "14:00",
                returDato = null,
                avgangstidRetur = "15:15",
                voksen = 1,
                barn0_5 = 0,
                student = 0,
                honnoer = 0,
                vernepliktig = 0,
                barn6_17 = 0,
                barnevogn = 0,
                sykkel = 0,
                hundover_40cm = 0,
                kjaeledyrunder_40cm = 0
            };

            // Act
            var resultat = (RedirectToRouteResult)controller.regBestilling(innBestilling);

            // Assert
            Assert.AreEqual(resultat.RouteName, "");
            Assert.AreEqual(resultat.RouteValues.Values.First(), "visAvganger");
        }

        [TestMethod]
        public void regBestilling_Test_Feilet()
        {
            // Arrange
            var controller = new BestillingController(new DBBLL(new RepositoryStub()));
            var innBestilling = new Bestilling();
            controller.ViewData.ModelState.AddModelError("fraLokasjon", "Du er nødt til å velge hvor du ønsker å reise fra");
            controller.ViewData.ModelState.AddModelError("tilLokasjon", "Du er nødt til å velge hvor du ønsker å reise til");
            controller.ViewData.ModelState.AddModelError("utreisedato", "Du er nødt til å velge hvilke dato du ønsker å reise");
            controller.ViewData.ModelState.AddModelError("returdato", "Du er nødt til å velge hvilken dato du ønsker å returnere");
            controller.ViewData.ModelState.AddModelError("reisende", "Du er nødt til å velge reisende");

            // Act
            var resultat = (ViewResult)controller.regBestilling(innBestilling);

            // Assert
            Assert.IsTrue(resultat.ViewData.ModelState.Count == 5);
            Assert.AreEqual(resultat.ViewName, "");
        }

        [TestMethod]
        public void regBestilling3_Test_OK()
        {

        }

        [TestMethod]
        public void regBestilling3_Test_Feilet()
        {

        }

        [TestMethod]
        public void hentBestilling_Test_OK()
        {
            // Arrange
            var controller = new BestillingController(new DBBLL(new RepositoryStub()));

            var forventetResultat = new Bestilling()
            {
                id = 1,
                fraLokasjon = "Langhus",
                tilLokasjon = "Holmlia",
                billettType = "En vei",
                utreiseDato = null,
                avgangstid = "14:00",
                returDato = null,
                avgangstidRetur = "15:15",
                voksen = 1,
                barn0_5 = 0,
                student = 0,
                honnoer = 0,
                vernepliktig = 0,
                barn6_17 = 0,
                barnevogn = 0,
                sykkel = 0,
                hundover_40cm = 0,
                kjaeledyrunder_40cm = 0
            };

            // Act
            var resultat = (ViewResult)controller.hentBestilling(1);
            var resultatListe = (Bestilling)resultat.Model;

            // Assert
            Assert.AreEqual(resultat.ViewName, "");
            Assert.AreEqual(forventetResultat.id, resultatListe.id);
            Assert.AreEqual(forventetResultat.fraLokasjon, resultatListe.fraLokasjon);
            Assert.AreEqual(forventetResultat.tilLokasjon, resultatListe.tilLokasjon);
            Assert.AreEqual(forventetResultat.billettType, resultatListe.billettType);
            Assert.AreEqual(forventetResultat.utreiseDato, resultatListe.utreiseDato);
            Assert.AreEqual(forventetResultat.avgangstid, resultatListe.avgangstid);
            Assert.AreEqual(forventetResultat.returDato, resultatListe.returDato);
            Assert.AreEqual(forventetResultat.avgangstidRetur, resultatListe.avgangstidRetur);
            Assert.AreEqual(forventetResultat.voksen, resultatListe.voksen);
            Assert.AreEqual(forventetResultat.barn0_5, resultatListe.barn0_5);
            Assert.AreEqual(forventetResultat.student, resultatListe.student);
            Assert.AreEqual(forventetResultat.honnoer, resultatListe.honnoer);
            Assert.AreEqual(forventetResultat.vernepliktig, resultatListe.vernepliktig);
            Assert.AreEqual(forventetResultat.barn6_17, resultatListe.barn6_17);
            Assert.AreEqual(forventetResultat.barnevogn, resultatListe.barnevogn);
            Assert.AreEqual(forventetResultat.sykkel, resultatListe.sykkel);
            Assert.AreEqual(forventetResultat.hundover_40cm, resultatListe.hundover_40cm);
            Assert.AreEqual(forventetResultat.kjaeledyrunder_40cm, resultatListe.kjaeledyrunder_40cm);
        }

        [TestMethod]
        public void hentBestilling_Test_Feilet()
        {
            // Arrange
            var controller = new BestillingController(new DBBLL(new RepositoryStub()));

            var forventetResultat = new Bestilling()
            {
                id = 0
            };

            // Act
            var resultat = (ViewResult)controller.hentBestilling(0);
            var resultatListe = (Bestilling)resultat.Model;

            // Assert
            Assert.AreEqual(resultat.ViewName, "");
            Assert.AreEqual(forventetResultat.id, resultatListe.id);
        }

        [TestMethod]
        public void regBestilling2_test_OK()
        {

        }

        [TestMethod]
        public void regBestilling2_test_Feilet()
        {

        }

        // Avgang

        [TestMethod]
        public void listAvganger_Test()
        {
            // Arrange
            var controller = new BestillingController(new DBBLL(new RepositoryStub()));
            var forventetResultat = new List<Avgang>();

            var innAvgang = new Avgang()
            {
                id = 1,
                _forsteAvgang = "Langhus",
                _sisteAvgang = "Holmlia"
            };
            forventetResultat.Add(innAvgang);
            forventetResultat.Add(innAvgang);
            forventetResultat.Add(innAvgang);

            // Act
            var resultat = (ViewResult)controller.listAvganger();
            var resultatListe = (List<Avgang>)resultat.Model;

            // Assert
            Assert.AreEqual(resultat.ViewName, "");

            for (int i = 0; i < resultatListe.Count; i++)
            {
                Assert.AreEqual(forventetResultat[i].id, resultatListe[i].id);
                Assert.AreEqual(forventetResultat[i]._forsteAvgang, resultatListe[i]._forsteAvgang);
                Assert.AreEqual(forventetResultat[i]._sisteAvgang, resultatListe[i]._sisteAvgang);
            }
        }

        [TestMethod]
        public void endreAvgang_Test()
        {
            // Arrange
            var controller = new BestillingController(new DBBLL(new RepositoryStub()));

            // Act
            var resultat = (ViewResult)controller.endreAvgang(1);

            // Assert
            Assert.AreEqual(resultat.ViewName, "");
        }

        [TestMethod]
        public void endreAvgang_Test_Ikke_Funnet_Ved_View()
        {
            // Arrange
            var controller = new BestillingController(new DBBLL(new RepositoryStub()));

            // Act
            var resultat = (ViewResult)controller.endreAvgang(0);
            var endreResultat = (Avgang)resultat.Model;

            // Assert
            Assert.AreEqual(resultat.ViewName, "");
            Assert.AreEqual(endreResultat.id, 0);
        }

        [TestMethod]
        public void endreAvgang_Test_Ikke_Funnet_Post()
        {
            // Arrange
            var controller = new BestillingController(new DBBLL(new RepositoryStub()));
            var innAvgang = new Avgang()
            {
                id = 0,
                _forsteAvgang = "Langhus",
                _sisteAvgang = "Holmlia"
            };

            // Act
            var resultat = (ViewResult)controller.endreAvgang(innAvgang);

            // Assert
            Assert.AreEqual(resultat.ViewName, "");
        }

        [TestMethod]
        public void endreAvgang_Test_Funnet()
        {
            // Arrange
            var controller = new BestillingController(new DBBLL(new RepositoryStub()));
            var innAvgang = new Avgang()
            {
                id = 1,
                _forsteAvgang = "Langhus",
                _sisteAvgang = "Holmlia"
            };

            // Act
            var resultat = (RedirectToRouteResult)controller.endreAvgang(innAvgang);

            // Assert
            Assert.AreEqual(resultat.RouteName, "");
            Assert.AreEqual(resultat.RouteValues.Values.First(), "listAvganger");
        }

        [TestMethod]
        public void slettAvgang_Test()
        {
            // Arrange
            var controller = new BestillingController(new DBBLL(new RepositoryStub()));

            // Act
            var actionResult = (ViewResult)controller.slettAvgang(1);
            var resultat = (Avgang)actionResult.Model;

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }

        [TestMethod]
        public void slettAvgang_Test_Funnet_Post()
        {
            // Arrange
            var controller = new BestillingController(new DBBLL(new RepositoryStub()));
            var innAvgang = new Avgang()
            {
                _forsteAvgang = "Langhus",
                _sisteAvgang = "Holmlia"
            };

            // Act
            var resultat = (RedirectToRouteResult)controller.slettAvgang(1, innAvgang);

            // Assert
            Assert.AreEqual(resultat.RouteName, "");
            Assert.AreEqual(resultat.RouteValues.Values.First(), "listAvganger");
        }

        [TestMethod]
        public void slettAvgang_Test_Ikke_Funnet_Post()
        {
            // Arrange
            var controller = new BestillingController(new DBBLL(new RepositoryStub()));
            var innAvgang = new Avgang()
            {
                _forsteAvgang = "Langhus",
                _sisteAvgang = "Holmlia"
            };

            // Act
            var resultat = (ViewResult)controller.slettAvgang(0, innAvgang);

            // Assert
            Assert.AreEqual(resultat.ViewName, "");
        }

        [TestMethod]
        public void regAvgang_Test()
        {
            // Arrange
            var controller = new BestillingController(new DBBLL(new RepositoryStub()));

            // Act
            var resultat = (ViewResult)controller.regAvgang();

            // Assert
            Assert.AreEqual(resultat.ViewName, "");
        }

        [TestMethod]
        public void regAvgang_Test__OK()
        {
            // Arrange
            var controller = new BestillingController(new DBBLL(new RepositoryStub()));

            var innAvgang = new Avgang()
            {
                id = 1,
                _forsteAvgang = "Langhus",
                _sisteAvgang = "Holmlia"
            };

            // Act
            var resultat = (RedirectToRouteResult)controller.regAvgang(innAvgang);

            // Assert
            Assert.AreEqual(resultat.RouteName, "");
            Assert.AreEqual(resultat.RouteValues.Values.First(), "listAvganger");
        }

        [TestMethod]
        public void regAvgang_Test_Feilet()
        {
            // Arrange
            var controller = new BestillingController(new DBBLL(new RepositoryStub()));

            var innAvgang = new Avgang()
            {
                id = 1,
                _forsteAvgang = "",
                _sisteAvgang = "Holmlia"
            };

            // Act
            var resultat = (ViewResult)controller.regAvgang(innAvgang);

            // Assert
            Assert.AreEqual(resultat.ViewName, "");
        }


        // VisAvgang

        [TestMethod]
        public void visAvganger_Test()
        {
            // Arrange
            var controller = new BestillingController(new DBBLL(new RepositoryStub()));

            // Act
            var resultat = (ViewResult)controller.visAvganger();

            // Assert
            Assert.AreEqual(resultat.ViewName, "");
        }

        [TestMethod]
        public void listVisAvganger_Test()
        {
            // Arrange
            var controller = new BestillingController(new DBBLL(new RepositoryStub()));
            var forventetResultat = new List<visAvgang>();

            var innAvgang = new visAvgang()
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
            forventetResultat.Add(innAvgang);
            forventetResultat.Add(innAvgang);
            forventetResultat.Add(innAvgang);

            // Act
            var resultat = (ViewResult)controller.listVisAvganger();
            var resultatListe = (List<visAvgang>)resultat.Model;

            // Assert
            Assert.AreEqual(resultat.ViewName, "");

            for (int i = 0; i < resultatListe.Count; i++)
            {
                Assert.AreEqual(forventetResultat[i].id, resultatListe[i].id);
                Assert.AreEqual(forventetResultat[i].forsteAvgang, resultatListe[i].forsteAvgang);
                Assert.AreEqual(forventetResultat[i].sisteAvgang, resultatListe[i].sisteAvgang);
                Assert.AreEqual(forventetResultat[i].reiseTid, resultatListe[i].reiseTid);
                Assert.AreEqual(forventetResultat[i].spor, resultatListe[i].spor);
                Assert.AreEqual(forventetResultat[i].togNummer, resultatListe[i].togNummer);
                Assert.AreEqual(forventetResultat[i].sone, resultatListe[i].sone);
                Assert.AreEqual(forventetResultat[i].pris, resultatListe[i].pris);
            }
        }

        [TestMethod]
        public void endreVisAvgang_Test()
        {
            // Arrange
            var controller = new BestillingController(new DBBLL(new RepositoryStub()));

            // Act
            var resultat = (ViewResult)controller.endreVisAvgang(1);

            // Assert
            Assert.AreEqual(resultat.ViewName, "");
        }

        [TestMethod]
        public void endreVisAvgang_Test_Ikke_Funnet_Ved_View()
        {
            // Arrange
            var controller = new BestillingController(new DBBLL(new RepositoryStub()));

            // Act
            var resultat = (ViewResult)controller.endreVisAvgang(0);
            var endreResultat = (visAvgang)resultat.Model;

            // Assert
            Assert.AreEqual(resultat.ViewName, "");
            Assert.AreEqual(endreResultat.id, 0);
        }

        [TestMethod]
        public void endreVisAvgang_Test_Ikke_Funnet_Post()
        {
            // Arrange
            var controller = new BestillingController(new DBBLL(new RepositoryStub()));
            var innAvgang = new visAvgang()
            {
                id = 0,
                forsteAvgang = "Langhus",
                sisteAvgang = "Holmlia",
                reiseTid = "15 minutter",
                spor = "Spor 1",
                togNummer = "L22",
                sone = 1,
                pris = 35
            };

            // Act
            var resultat = (ViewResult)controller.endreVisAvgang(innAvgang);

            // Assert
            Assert.AreEqual(resultat.ViewName, "");
        }

        [TestMethod]
        public void endreVisAvgang_Funnet()
        {
            // Arrange
            var controller = new BestillingController(new DBBLL(new RepositoryStub()));
            var innAvgang = new visAvgang()
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
            var resultat = (RedirectToRouteResult)controller.endreVisAvgang(innAvgang);

            // Assert
            Assert.AreEqual(resultat.RouteName, "");
            Assert.AreEqual(resultat.RouteValues.Values.First(), "listVisAvganger");
        }

        [TestMethod]
        public void slettVisAvgang_Test()
        {
            // Arrange
            var controller = new BestillingController(new DBBLL(new RepositoryStub()));

            // Act
            var actionResult = (ViewResult)controller.slettVisAvgang(1);
            var resultat = (visAvgang)actionResult.Model;

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }

        [TestMethod]
        public void slettVisAvgang_Test_Funnet_Post()
        {
            // Arrange
            var controller = new BestillingController(new DBBLL(new RepositoryStub()));

            var innVisAvgang = new visAvgang()
            {
                forsteAvgang = "Langhus",
                sisteAvgang = "Holmlia",
                reiseTid = "15 minutter",
                spor = "Spor 1",
                togNummer = "L22",
                sone = 1,
                pris = 35
            };

            // Act
            var resultat = (RedirectToRouteResult)controller.slettVisAvgang(1, innVisAvgang);

            // Assert
            Assert.AreEqual(resultat.RouteName, "");
            Assert.AreEqual(resultat.RouteValues.Values.First(), "listVisAvganger");
        }

        [TestMethod]
        public void slettVisAvgang_Test_Ikke_Funnet_Post()
        {
            // Arrange
            var controller = new BestillingController(new DBBLL(new RepositoryStub()));

            var innVisAvgang = new visAvgang()
            {
                forsteAvgang = "Langhus",
                sisteAvgang = "Holmlia",
                reiseTid = "15 minutter",
                spor = "Spor 1",
                togNummer = "L22",
                sone = 1,
                pris = 35
            };

            // Act
            var resultat = (ViewResult)controller.slettVisAvgang(0, innVisAvgang);

            // Assert
            Assert.AreEqual(resultat.ViewName, "");
        }

        [TestMethod]
        public void registrerVisAvgang_Test()
        {
            // Arrange
            var controller = new BestillingController(new DBBLL(new RepositoryStub()));

            // Act
            var resultat = (ViewResult)controller.registrerVisAvgang();

            // Assert
            Assert.AreEqual(resultat.ViewName, "");
        }

        [TestMethod]
        public void registrerVisAvgang_Test__OK()
        {
            // Arrange
            var controller = new BestillingController(new DBBLL(new RepositoryStub()));

            var innAvgang = new visAvgang()
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
            var resultat = (RedirectToRouteResult)controller.registrerVisAvgang(innAvgang);

            // Assert
            Assert.AreEqual(resultat.RouteName, "");
            Assert.AreEqual(resultat.RouteValues.Values.First(), "listVisAvganger");
        }

        [TestMethod]
        public void registrerVisAvgang_Test_Feilet()
        {
            // Arrange
            var controller = new BestillingController(new DBBLL(new RepositoryStub()));

            var innAvgang = new visAvgang()
            {
                id = 1,
                forsteAvgang = "",
                sisteAvgang = "Holmlia",
                reiseTid = "15 minutter",
                spor = "Spor 1",
                togNummer = "L22",
                sone = 1,
                pris = 35
            };

            // Act
            var resultat = (ViewResult)controller.registrerVisAvgang(innAvgang);

            // Assert
            Assert.AreEqual(resultat.ViewName, "");
        }

        // alleavgangstider

        [TestMethod]
        public void visAlleavgangstider_Test()
        {
            // Arrange
            var controller = new BestillingController(new DBBLL(new RepositoryStub()));

            // Act
            var resultat = (ViewResult)controller.visAlleavgangstider();

            // Assert
            Assert.AreEqual(resultat.ViewName, "");
        }

        [TestMethod]
        public void listAlleavgangstider_Test()
        {
            // Arrange
            var controller = new BestillingController(new DBBLL(new RepositoryStub()));
            var forventetResultat = new List<alleavgangstid>();

            var innAvgang = new alleavgangstid()
            {
                id = 1,
                avgangstid = "14:00",
                avgangstidRetur = "15:15"
            };
            forventetResultat.Add(innAvgang);
            forventetResultat.Add(innAvgang);
            forventetResultat.Add(innAvgang);

            // Act
            var resultat = (ViewResult)controller.listAlleavgangstider();
            var resultatListe = (List<alleavgangstid>)resultat.Model;

            // Assert
            Assert.AreEqual(resultat.ViewName, "");

            for (int i = 0; i < resultatListe.Count; i++)
            {
                Assert.AreEqual(forventetResultat[i].id, resultatListe[i].id);
                Assert.AreEqual(forventetResultat[i].avgangstid, resultatListe[i].avgangstid);
                Assert.AreEqual(forventetResultat[i].avgangstidRetur, resultatListe[i].avgangstidRetur);
            }
        }

        [TestMethod]
        public void endreAlleavgangstider_Test()
        {
            // Arrange
            var controller = new BestillingController(new DBBLL(new RepositoryStub()));

            // Act
            var resultat = (ViewResult)controller.endreAlleavgangstider(1);

            // Assert
            Assert.AreEqual(resultat.ViewName, "");
        }

        [TestMethod]
        public void endreAlleavgangstider_Test_Ikke_Funnet_Ved_View()
        {
            // Arrange
            var controller = new BestillingController(new DBBLL(new RepositoryStub()));

            // Act
            var resultat = (ViewResult)controller.endreAlleavgangstider(0);
            var endreResultat = (alleavgangstid)resultat.Model;

            // Assert
            Assert.AreEqual(resultat.ViewName, "");
            Assert.AreEqual(endreResultat.id, 0);
        }

        [TestMethod]
        public void endreAlleavgangstider_Test_Ikke_Funnet_Post()
        {
            // Arrange
            var controller = new BestillingController(new DBBLL(new RepositoryStub()));
            var innAvgang = new alleavgangstid()
            {
                id = 0,
                avgangstid = "14:00",
                avgangstidRetur = "15:15"
            };

            // Act
            var resultat = (ViewResult)controller.endreAlleavgangstider(innAvgang);

            // Assert
            Assert.AreEqual(resultat.ViewName, "");
        }

        [TestMethod]
        public void endreAllevisavganger_Funnet()
        {
            // Arrange
            var controller = new BestillingController(new DBBLL(new RepositoryStub()));
            var innAvgang = new alleavgangstid()
            {
                id = 1,
                avgangstid = "14:00",
                avgangstidRetur = "15:15"
            };

            // Act
            var resultat = (RedirectToRouteResult)controller.endreAlleavgangstider(innAvgang);

            // Assert
            Assert.AreEqual(resultat.RouteName, "");
            Assert.AreEqual(resultat.RouteValues.Values.First(), "listAlleavgangstider");
        }

        [TestMethod]
        public void slettAllevisavganger_Test()
        {
            // Arrange
            var controller = new BestillingController(new DBBLL(new RepositoryStub()));

            // Act
            var actionResult = (ViewResult)controller.slettalleavgangstid(1);
            var resultat = (alleavgangstid)actionResult.Model;

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }

        [TestMethod]
        public void slettAllevisavganger_Test_Funnet_Post()
        {
            // Arrange
            var controller = new BestillingController(new DBBLL(new RepositoryStub()));
            var innAvgangstid = new alleavgangstid()
            {
                avgangstid = "14:00",
                avgangstidRetur = "15:15"
            };

            // Act
            var resultat = (RedirectToRouteResult)controller.slettalleavgangstid(1, innAvgangstid);

            // Assert
            Assert.AreEqual(resultat.RouteName, "");
            Assert.AreEqual(resultat.RouteValues.Values.First(), "/Bestilling/listAlleavgangstider");
        }

        [TestMethod]
        public void slettAlleavganger_Test_Ikke_Funnet_Post()
        {
            // Arrange
            var controller = new BestillingController(new DBBLL(new RepositoryStub()));
            var innAvgangstid = new alleavgangstid()
            {
                avgangstid = "14:00",
                avgangstidRetur = "15:15"
            };

            // Act
            var resultat = (ViewResult)controller.slettalleavgangstid(0, innAvgangstid);

            // Assert
            Assert.AreEqual(resultat.ViewName, "");
        }

        [TestMethod]
        public void registreralleavgangstid_Test()
        {
            // Arrange
            var controller = new BestillingController(new DBBLL(new RepositoryStub()));

            // Act
            var resultat = (ViewResult)controller.registreralleavgangstid();

            // Assert
            Assert.AreEqual(resultat.ViewName, "");
        }

        [TestMethod]
        public void registreralleavgangstid_Test__OK()
        {
            // Arrange
            var controller = new BestillingController(new DBBLL(new RepositoryStub()));

            var innAvgangstid = new alleavgangstid()
            {
                id = 1,
                avgangstid = "14:00",
                avgangstidRetur = "15:15"
            };

            // Act
            var resultat = (RedirectToRouteResult)controller.registreralleavgangstid(innAvgangstid);

            // Assert
            Assert.AreEqual(resultat.RouteName, "");
            Assert.AreEqual(resultat.RouteValues.Values.First(), "listAlleavgangstider");
        }

        [TestMethod]
        public void registreralleavgangstid_Test_Feilet()
        {
            // Arrange
            var controller = new BestillingController(new DBBLL(new RepositoryStub()));

            var innAvgangstid = new alleavgangstid()
            {
                id = 0,
                avgangstid = "14:00",
                avgangstidRetur = "15:15"
            };

            // Act
            var resultat = (ViewResult)controller.registreralleavgangstid(innAvgangstid);

            // Assert
            Assert.AreEqual(resultat.ViewName, "");
        }

        // Betaling

        [TestMethod]
        public void Betaling_Test()
        {
            // Arrange
            var controller = new BestillingController(new DBBLL(new RepositoryStub()));

            // Act
            var resultat = (ViewResult)controller.Betaling();

            // Assert
            Assert.AreEqual(resultat.ViewName, "");
        }

        [TestMethod]
        public void listBetaling_Test()
        {
            // Arrange
            var controller = new BestillingController(new DBBLL(new RepositoryStub()));
            var forventetResultat = new List<Betaling>();

            var innBetaling = new Betaling()
            {
                id = 1,
                fornavn = "Frank",
                etternavn = "Loke",
                email = "floke@hotmail.com",
                kortnummer = "764637872354",
                utløpsDato = "05/33",
                CVC = "654"
            };
            forventetResultat.Add(innBetaling);
            forventetResultat.Add(innBetaling);
            forventetResultat.Add(innBetaling);

            // Act
            var resultat = (ViewResult)controller.listBetaling();
            var resultatListe = (List<Betaling>)resultat.Model;

            // Assert
            Assert.AreEqual(resultat.ViewName, "");

            for (int i = 0; i < resultatListe.Count; i++)
            {
                Assert.AreEqual(forventetResultat[i].id, resultatListe[i].id);
                Assert.AreEqual(forventetResultat[i].fornavn, resultatListe[i].fornavn);
                Assert.AreEqual(forventetResultat[i].etternavn, resultatListe[i].etternavn);
                Assert.AreEqual(forventetResultat[i].email, resultatListe[i].email);
                Assert.AreEqual(forventetResultat[i].kortnummer, resultatListe[i].kortnummer);
                Assert.AreEqual(forventetResultat[i].utløpsDato, resultatListe[i].utløpsDato);
                Assert.AreEqual(forventetResultat[i].CVC, resultatListe[i].CVC);
            }
        }

    }
}
