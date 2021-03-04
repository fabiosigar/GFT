using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GFT.TestTecnicoEntrada
{
    public class Entrada : ITrade
    {
        public string TradeNum { get; set; }
        public double Value { get; }
        public string ClientSector { get; }

        public Entrada(string tradeNum, double value, string clientSector)
        {
            this.TradeNum = tradeNum;
            this.Value = value;
            this.ClientSector = clientSector;
        }
    }
}