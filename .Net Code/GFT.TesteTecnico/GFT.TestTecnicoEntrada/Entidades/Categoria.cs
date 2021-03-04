using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GFT.TestTecnicoEntrada
{
    public class Categoria
    {
        public int Id { get; set; }
        public string NomeCategoria { get; set; }

        public Categoria()
        {

        }

        public Categoria(string nomeCategoria)
        {
            this.NomeCategoria = nomeCategoria;
        }

        public List<Categoria> ConsultaCategoria()
        {
            var URI = "http://localhost:56823/api/Categorias";
            using (var client = new HttpClient())
            {
                using (var response = client.GetAsync(URI).GetAwaiter().GetResult())
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var CategoriaJsonString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                        return JsonConvert.DeserializeObject<Categoria[]>(CategoriaJsonString).ToList();

                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public Categoria ConsultaCategoriaPorId(int catId)
        {
            var URI = String.Concat("http://localhost:56823/api/Categorias","/", catId);
            using (var client = new HttpClient())
            {
                using (var response = client.GetAsync(URI).GetAwaiter().GetResult())
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var CategoriaJsonString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                        return JsonConvert.DeserializeObject<Categoria>(CategoriaJsonString);
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public void InsereCategoria(List<Categoria> catList)
        {
            var URI = "http://localhost:56823/api/Categorias";
            using (var client = new HttpClient())
            {
                foreach (var cat in catList)
                {
                    var serializedCategoria = JsonConvert.SerializeObject(cat);
                    var content = new StringContent(serializedCategoria, Encoding.UTF8, "application/json");
                    var result = client.PostAsync(URI, content).GetAwaiter().GetResult();
                }
            }
        }
    }
}
