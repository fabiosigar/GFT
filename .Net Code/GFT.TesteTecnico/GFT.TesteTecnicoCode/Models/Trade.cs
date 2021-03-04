using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using GFT.TesteTecnicoAPI.Models;

namespace GFT.TesteTecnicoAPI.Models
{
    public class Trade
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataTrade { get; set; }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        public int SetorClienteId { get; set; }
        public SetorCliente SetorCliente { get; set; }
        public int PortfolioId { get; set; }
        public Portfolio Portfolio { get; set; }

        public Trade(decimal valor, DateTime dataTrade, int categoriaId, int setorClienteId, int portfolioId)
        {
            this.Valor = valor;
            this.DataTrade = dataTrade;
            this.CategoriaId = categoriaId;
            this.SetorClienteId = setorClienteId;
            this.PortfolioId = portfolioId;
        }
    }
}
