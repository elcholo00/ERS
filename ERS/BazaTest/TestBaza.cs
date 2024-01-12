using Baza;
using Comon.Model;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazaTest
{
    [TestFixture]
    public class BazaTest
    {
        private BazaImpl baza;

        [SetUp]
        public void setUp()
        {
            var database = new Mock<BazaImpl>();
            baza = database.Object;

        }

        [Test]
        public void TestGenerisiPodatke()
        {

            Audit a1 = new Audit(new DateTime(2022, 10, 10), "prvi", "kk", 10);
            Audit a2 = new Audit(new DateTime(2021, 8, 9), "drugi", "ka", 9);


            baza.InsertAudit(a1);
            baza.InsertAudit(a2);

            //    dataBase.DeleteAudit();


            List<Audit> audits = new List<Audit>();
            audits = baza.GetAudit();
            Assert.That(audits.Count == 2, Is.True, "The result should be true");

        }

        [Test]
        public void TestGeo()
        {
            baza.DeleteAllPrognoza();
            GeoPodrucje g1 = new GeoPodrucje("geo", "123s", 1);
            GeoPodrucje g2 = new GeoPodrucje("go", "123", 2);

            baza.InsertGeoPodrucje(g1);
            baza.InsertGeoPodrucje(g2);

            //dataBase.DeleteAllGeografskaOblast();
            //dataBase.DeleteAllGeografskaOblast();

            List<GeoPodrucje> geos = baza.GetGeografskaOblast();
            Assert.That(geos.Count == 2, Is.True, "The result shold be true");


        }

        [Test]
        public void Potrosnje() { 
        baza.DeleteAllPrognoza();
            Prognoza p1 = new Prognoza(new DateTime(2019, 10, 10), "VOJ", 335, 4, 1, 0);
        Prognoza p2 = new Prognoza(new DateTime(2019, 11, 10), "BGD", 3150,3 , 0, 0);
        Prognoza p3 = new Prognoza(new DateTime(2019, 10, 10), "VOJ", 331,2 , 1, 0);
        baza.InsertPrognoza(p1);
            baza.InsertPrognoza(p2);
            baza.InsertPrognoza(p3);

            List<Prognoza> potrosnje = new List<Prognoza>();
        potrosnje = baza.GetPrognoza();

            Assert.That(potrosnje.Count == 3, Is.True, "Test ubacivanja je uspjesan");

            baza.DeleteAllPrognoza();
            potrosnje = baza.GetPrognoza();

            Assert.That(potrosnje.Count == 0, Is.True, "Test brisanja je uspjesan");
        }
        [Test]
        public void Audit()
        {
            Audit a1 = new Audit(new DateTime(2018, 10, 10), "fajlPrvi", "VOJ", 18);
            Audit a2 = new Audit(new DateTime(2018, 11, 10), "fajlDrugi", "BGD", 17);

            baza.InsertAudit(a1);
            baza.InsertAudit(a2);

            List<Audit> auditi = new List<Audit>();
            auditi = baza.GetAudit();

            Assert.That(auditi.Count == 2, Is.True, "Test ubacivanja audita je uspjesan");

            baza.DeleteAllAudit();
            auditi = baza.GetAudit();
            Assert.That(auditi.Count == 0, Is.True, "Test brisanja audita je uspjesan");

            baza.InsertAudit(a1);
            baza.InsertAudit(a2);
            auditi = baza.GetAudit();

            baza.DeleteAudit(1);
            auditi = baza.GetAudit();
            Assert.That(auditi.Count == 1, Is.True, "Test brisanja audita je uspjesan");

            baza.UpdateAudit(a1,2);
        }
        [Test]
        public void TestirajPodrucje()
        {
            GeoPodrucje p1 = new GeoPodrucje("1805", "VRB", 100);
            GeoPodrucje p2 = new GeoPodrucje("2610", "DBJ", 90);

            baza.InsertGeoPodrucje(p1);
            baza.InsertGeoPodrucje(p2);

            List<GeoPodrucje> podrucja = new List<GeoPodrucje>();
            podrucja = baza.evidencijaGeoPodrucja();

            Assert.That(podrucja.Count == 2, Is.True, "Test ubacivanja je uspjesan");

            baza.DeleteAllGeoPodrucje();
            podrucja = baza.evidencijaGeoPodrucja();
            Assert.That(podrucja.Count == 0, Is.True, "Test brisanja svih podrucja je uspjesan.");

            baza.InsertGeoPodrucje(p1);
            baza.InsertGeoPodrucje(p2);
            podrucja = baza.evidencijaGeoPodrucja();

            baza.DeleteGeoPodrucje(100);
            podrucja = baza.evidencijaGeoPodrucja();
            Assert.That(podrucja.Count == 1, Is.True, "Test brisanja jednog podrucja je uspjesan.");

        }

    }
}
