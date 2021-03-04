using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFT.TestTecnicoEntrada
{
    public static class Utilitarios
    {
        public static bool Conter(this string thisObj, string value, StringComparison compareType)
        {
            return thisObj.IndexOf(value, StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
}
