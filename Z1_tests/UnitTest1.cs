using NUnit.Framework;
using System;
using Z1;

namespace Z1_tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestPorownaniaDwochCzlonkowZespolu_WiekRowny()
        {
            CzlonekZespolu czlonek1 = new CzlonekZespolu(32, "Kaczyñski");
            CzlonekZespolu czlonek2 = new CzlonekZespolu(32, "Kaczor");

            int porownanieWieku = czlonek1.CompareTo(czlonek2);

            Assert.AreEqual(0, porownanieWieku);
        }
        [Test]
        public void TestPorownaniaDwochCzlonkowZespolu_WiekWiekszy()
        {
            CzlonekZespolu czlonek1 = new CzlonekZespolu(34, "Kaczyñski");
            CzlonekZespolu czlonek2 = new CzlonekZespolu(33, "Kaczor");

            int porownanieWieku = czlonek1.CompareTo(czlonek2);

            Assert.AreEqual(1, porownanieWieku);
        }

        [Test]
        public void TestPorownaniaDwochCzlonkowZespolu_WiekMniejszy()
        {
            CzlonekZespolu czlonek1 = new CzlonekZespolu(32, "Kaczyñski");
            CzlonekZespolu czlonek2 = new CzlonekZespolu(33, "Kaczor");

            int porownanieWieku = czlonek1.CompareTo(czlonek2);

            Assert.AreEqual(-1, porownanieWieku);
        }

        [Test]
        public void TestPorownaniaDwochCzlonkowZespolu_RoznyWiek()
        {
            CzlonekZespolu czlonek1 = new CzlonekZespolu(34, "Kaczyñski");
            CzlonekZespolu czlonek2 = new CzlonekZespolu(32, "Kaczor");

            int porownanieWieku = czlonek1.CompareTo(czlonek2);

            Assert.AreNotEqual(0, porownanieWieku);
        }

        [Test]
        public void TestPorownaniaDwochCzlonkowZespoluPoNazwisku_RowneNazwiska()
        {
            CzlonekZespolu czlonek1 = new CzlonekZespolu(33, "Kaczyñski");
            CzlonekZespolu czlonek2 = new CzlonekZespolu(32, "Kaczyñski");
            CzlonekZespoluPoNazwiskuComparer comparer = new CzlonekZespoluPoNazwiskuComparer();

            int porownanieNazwisk = comparer.Compare(czlonek1, czlonek2);

            Assert.AreEqual(0, porownanieNazwisk);
        }

        [Test]
        public void TestPorownaniaDwochCzlonkowZespoluPoNazwisku_PierwszeNazwiskoMniejsze()
        {
            CzlonekZespolu czlonek1 = new CzlonekZespolu(33, "Aaczyñski");
            CzlonekZespolu czlonek2 = new CzlonekZespolu(32, "Kaczyñski");
            CzlonekZespoluPoNazwiskuComparer comparer = new CzlonekZespoluPoNazwiskuComparer();

            int porownanieNazwisk = comparer.Compare(czlonek1, czlonek2);

            Assert.AreEqual(-1, porownanieNazwisk);
        }

        [Test]
        public void TestPorownaniaDwochCzlonkowZespoluPoNazwisku_DrugieNazwiskoMniejsze()
        {
            CzlonekZespolu czlonek1 = new CzlonekZespolu(33, "Caczyñski");
            CzlonekZespolu czlonek2 = new CzlonekZespolu(32, "Baczyñski");
            CzlonekZespoluPoNazwiskuComparer comparer = new CzlonekZespoluPoNazwiskuComparer();

            int porownanieNazwisk = comparer.Compare(czlonek1, czlonek2);

            Assert.AreEqual(1, porownanieNazwisk);
        }

        [Test]
        public void TestPorownaniaDwochCzlonkowZespoluPoNazwisku_RozneNazwiska()
        {
            CzlonekZespolu czlonek1 = new CzlonekZespolu(33, "Œwider");
            CzlonekZespolu czlonek2 = new CzlonekZespolu(32, "Koœmider");
            CzlonekZespoluPoNazwiskuComparer comparer = new CzlonekZespoluPoNazwiskuComparer();

            int porownanieNazwisk = comparer.Compare(czlonek1, czlonek2);

            Assert.AreNotEqual(0, porownanieNazwisk);
        }

        [Test]
        public void TestToString_PoprawnyFormat()
        {
            CzlonekZespolu czlonek1 = new CzlonekZespolu(33, "Œwider");

            string oczekiwany = $"Wiek: 33, nazwisko: Œwider";

            Assert.AreEqual(oczekiwany, czlonek1.ToString());
        }

        [Test]
        public void TestTworzeniaObiektuCzlonkaZespolu_ZNiepoprawnymiDanymi()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => { new CzlonekZespolu(-3, "Koœwider"); });
            Assert.Throws<ArgumentException>(() => { new CzlonekZespolu(1, ""); });

        }
    }
}