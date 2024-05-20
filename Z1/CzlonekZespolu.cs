using System;
using System.Collections.Generic;
using System.Text;

namespace Z1
{
    public class CzlonekZespolu : IComparable<CzlonekZespolu>
    {
        private int wiek;
        private string nazwisko;

        public string Nazwisko {get => nazwisko;}
        public CzlonekZespolu(int wiek, string nazwisko)
        {
            if(wiek < 0)
            {
                throw new ArgumentOutOfRangeException("nie istnieje ujemny wiek");
            }
            if(nazwisko.Length == 0)
            {
                throw new ArgumentException("Nazwisko nie może być puste");
            }
            this.wiek = wiek;
            this.nazwisko = nazwisko;
        }

        public int CompareTo(CzlonekZespolu other)
        {
            if (other == null) return 1;
            if (this.wiek > other.wiek) return 1;
            if (this.wiek < other.wiek) return -1;
            return 0;
        }
        public override string ToString()
        {
            return $"Wiek: {wiek}, nazwisko: {nazwisko}";
        }
    }
}
