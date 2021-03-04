using GFT.TesteTecnico.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFT.TesteTecnico
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<Entrada> ent1 = new List<Entrada>();

            Console.Write("Digite as Trade que serão cadastrada: ");
            var entrada = Console.ReadLine();
            /*
             * Trade1 {Value = 2000000; ClientSector = "Private"} 
             * Trade2 {Value = 400000; ClientSector = "Public"} 
             * Trade3 {Value = 500000; ClientSector = "Public"} 
             * Trade4 {Value = 3000000; ClientSector = "Public"} 
             */

            Console.WriteLine(entrada);
            Console.ReadLine();
        }
    }
}
