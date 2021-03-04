using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GFT.TestTecnicoEntrada
{
    public class Trade
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataTrade { get; set; }
        public int CategoriaId { get; set; }
        public int SetorClienteId { get; set; }
        public int PortfolioId { get; set; }

        public Trade()
        {

        }

        public Trade(decimal valor, DateTime dataTrade, int categoriaId, int setorClienteId, int portfolioId)
        {
            this.Valor = valor;
            this.DataTrade = dataTrade;
            this.CategoriaId = categoriaId;
            this.SetorClienteId = setorClienteId;
            this.PortfolioId = portfolioId;
        }

        public async void InsereTrade(List<Trade> tradeList)
        {
            var URI = "http://localhost:56823/api/Trades";
            using (var client = new HttpClient())
            {
                foreach (var trade in tradeList)
                {
                    var serializedTrade = JsonConvert.SerializeObject(trade);
                    var content = new StringContent(serializedTrade, Encoding.UTF8, "application/json");
                    var result = await client.PostAsync(URI, content);
                }
            }    
        }
    }
}
