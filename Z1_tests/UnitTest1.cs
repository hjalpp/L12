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
            CzlonekZespolu czlonek1 = new CzlonekZespolu(32, "Kaczy�ski");
            CzlonekZespolu czlonek2 = new CzlonekZespolu(32, "Kaczor");

            int porownanieWieku = czlonek1.CompareTo(czlonek2);

            Assert.AreEqual(0, porownanieWieku);
        }
        [Test]
        public void TestPorownaniaDwochCzlonkowZespolu_WiekWiekszy()
        {
            CzlonekZespolu czlonek1 = new CzlonekZespolu(34, "Kaczy�ski");
            CzlonekZespolu czlonek2 = new CzlonekZespolu(33, "Kaczor");

            int porownanieWieku = czlonek1.CompareTo(czlonek2);

            Assert.AreEqual(1, porownanieWieku);
        }

        [Test]
        public void TestPorownaniaDwochCzlonkowZespolu_WiekMniejszy()
        {
            CzlonekZespolu czlonek1 = new CzlonekZespolu(32, "Kaczy�ski");
            CzlonekZespolu czlonek2 = new CzlonekZespolu(33, "Kaczor");

            int porownanieWieku = czlonek1.CompareTo(czlonek2);

            Assert.AreEqual(-1, porownanieWieku);
        }

        [Test]
        public void TestPorownaniaDwochCzlonkowZespolu_RoznyWiek()
        {
            CzlonekZespolu czlonek1 = new CzlonekZespolu(34, "Kaczy�ski");
            CzlonekZespolu czlonek2 = new CzlonekZespolu(32, "Kaczor");

            int porownanieWieku = czlonek1.CompareTo(czlonek2);

            Assert.AreNotEqual(0, porownanieWieku);
        }

        [Test]
        public void TestPorownaniaDwochCzlonkowZespoluPoNazwisku_RowneNazwiska()
        {
            CzlonekZespolu czlonek1 = new CzlonekZespolu(33, "Kaczy�ski");
            CzlonekZespolu czlonek2 = new CzlonekZespolu(32, "Kaczy�ski");
            CzlonekZespoluPoNazwiskuComparer comparer = new CzlonekZespoluPoNazwiskuComparer();

            int porownanieNazwisk = comparer.Compare(czlonek1, czlonek2);

            Assert.AreEqual(0, porownanieNazwisk);
        }

        [Test]
        public void TestPorownaniaDwochCzlonkowZespoluPoNazwisku_PierwszeNazwiskoMniejsze()
        {
            CzlonekZespolu czlonek1 = new CzlonekZespolu(33, "Aaczy�ski");
            CzlonekZespolu czlonek2 = new CzlonekZespolu(32, "Kaczy�ski");
            CzlonekZespoluPoNazwiskuComparer comparer = new CzlonekZespoluPoNazwiskuComparer();

            int porownanieNazwisk = comparer.Compare(czlonek1, czlonek2);

            Assert.AreEqual(-1, porownanieNazwisk);
        }

        [Test]
        public void TestPorownaniaDwochCzlonkowZespoluPoNazwisku_DrugieNazwiskoMniejsze()
        {
            CzlonekZespolu czlonek1 = new CzlonekZespolu(33, "Caczy�ski");
            CzlonekZespolu czlonek2 = new CzlonekZespolu(32, "Baczy�ski");
            CzlonekZespoluPoNazwiskuComparer comparer = new CzlonekZespoluPoNazwiskuComparer();

            int porownanieNazwisk = comparer.Compare(czlonek1, czlonek2);

            Assert.AreEqual(1, porownanieNazwisk);
        }

        [Test]
        public void TestPorownaniaDwochCzlonkowZespoluPoNazwisku_RozneNazwiska()
        {
            CzlonekZespolu czlonek1 = new CzlonekZespolu(33, "�wider");
            CzlonekZespolu czlonek2 = new CzlonekZespolu(32, "Ko�mider");
            CzlonekZespoluPoNazwiskuComparer comparer = new CzlonekZespoluPoNazwiskuComparer();

            int porownanieNazwisk = comparer.Compare(czlonek1, czlonek2);

            Assert.AreNotEqual(0, porownanieNazwisk);
        }

        [Test]
        public void TestToString_PoprawnyFormat()
        {
            CzlonekZespolu czlonek1 = new CzlonekZespolu(33, "�wider");

            string oczekiwany = $"Wiek: 33, nazwisko: �wider";

            Assert.AreEqual(oczekiwany, czlonek1.ToString());
        }

        [Test]
        public void TestTworzeniaObiektuCzlonkaZespolu_ZNiepoprawnymiDanymi()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => { new CzlonekZespolu(-3, "Ko�wider"); });
            Assert.Throws<ArgumentException>(() => { new CzlonekZespolu(1, ""); });

        }
    }
}