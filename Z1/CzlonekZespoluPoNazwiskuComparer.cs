using System;
using System.Collections.Generic;
using System.Text;

namespace Z1
{
    public class CzlonekZespoluPoNazwiskuComparer : IComparer<CzlonekZespolu>
    {
        public int Compare(CzlonekZespolu czlonek1, CzlonekZespolu czlonek2)
        {
            if (czlonek1 == null || czlonek2 == null) return 0;
            return czlonek1.Nazwisko.CompareTo(czlonek2.Nazwisko);
        }
    }
}
