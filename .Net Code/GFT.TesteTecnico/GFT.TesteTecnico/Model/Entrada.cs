using GFT.TesteTecnico.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFT.TesteTecnico.Model
{
    public class Entrada : ITrade
    {
        public double Value => 0;
        public string ClientSector => string.Empty;
    }
}
