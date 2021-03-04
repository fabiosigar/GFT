using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GFT.TestTecnicoEntrada
{
    public class Portfolio
    {
        public int Id { get; set; }
        public string NomePortfolio { get; set; }

        public Portfolio()
        {
        }

        public Portfolio(string nomePort)
        {
            this.NomePortfolio = nomePort;
        }

        public List<Portfolio> ConsultaPortfolio()
        {
            var URI = "http://localhost:56823/api/Portfolios";
            using (var client = new HttpClient())
            {
                using (var response = client.GetAsync(URI).GetAwaiter().GetResult())
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var PortfolioJsonString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                        return JsonConvert.DeserializeObject<Portfolio[]>(PortfolioJsonString).ToList();
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public void InserePortfolio(List<Portfolio> portList)
        {
            var URI = "http://localhost:56823/api/Portfolios";
            using (var client = new HttpClient())
            {
                foreach (var port in portList)
                {
                    var serializedProduto = JsonConvert.SerializeObject(port);
                    var content = new StringContent(serializedProduto, Encoding.UTF8, "application/json");
                    var result = client.PostAsync(URI, content).GetAwaiter().GetResult();
                }
            }
        }
    }
}
