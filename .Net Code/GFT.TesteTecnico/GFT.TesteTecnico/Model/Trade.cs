using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFT.TesteTecnico.Model
{
    public class Trade
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataTrade { get; set; }

        public int CategoriaId { get; set; }
        public int SetorClienteId { get; set; }
        public int PortfolioId { get; set; }
    }
}
