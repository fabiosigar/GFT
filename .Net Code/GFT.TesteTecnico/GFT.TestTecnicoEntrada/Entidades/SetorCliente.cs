using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GFT.TestTecnicoEntrada
{
    public class SetorCliente
    {
        public int Id { get; set; }
        public string NomeSetorCliente { get; set; }

        public SetorCliente()
        {
        }

        public SetorCliente(string nomeSetorCliente)
        {
            this.NomeSetorCliente = nomeSetorCliente;
        }

        public List<SetorCliente> ConsultaSetorCliente()
        {
            var URI = "http://localhost:56823/api/SetorClientes";
            using (var client = new HttpClient())
            {
                using (var response = client.GetAsync(URI).GetAwaiter().GetResult())
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var SetorClienteJsonString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                        return JsonConvert.DeserializeObject<SetorCliente[]>(SetorClienteJsonString).ToList();
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public void InsereSetorCliente(List<SetorCliente> setCliList)
        {
            var URI = "http://localhost:56823/api/SetorClientes";
            using (var client = new HttpClient())
            {
                foreach (var setClI in setCliList)
                {
                    var serializedSetorCliente = JsonConvert.SerializeObject(setClI);
                    var content = new StringContent(serializedSetorCliente, Encoding.UTF8, "application/json");
                    var result = client.PostAsync(URI, content).GetAwaiter().GetResult();
                }
            }
        }
    }
}
