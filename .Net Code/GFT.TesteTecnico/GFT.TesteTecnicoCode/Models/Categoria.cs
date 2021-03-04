using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFT.TesteTecnicoAPI.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string NomeCategoria { get; set; }

        public ICollection<Trade> Trades { get; set; }
    }
}
