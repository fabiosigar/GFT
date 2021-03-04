using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFT.TesteTecnicoAPI.Models
{
    public class SetorCliente
    {
        public int Id { get; set; }
        public string NomeSetorCliente { get; set; }

        public ICollection<Trade> Trades { get; set; }
    }
}
