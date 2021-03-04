using GFT.TestTecnicoEntrada;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFT.TestTecnicoEntrada
{
    public class BLL_TesteTecnico
    {
        private Trade _trade = new Trade();
        private Categoria _categoria = new Categoria();
        private SetorCliente _setorCliente = new SetorCliente();
        private Portfolio _portfolio = new Portfolio();

        public void populaBase()
        {
            var cats = _categoria.ConsultaCategoria();
            if (!(cats.Count > 0))
                PopulaCategoria();

            var setClis = _setorCliente.ConsultaSetorCliente();
            if (!(setClis.Count > 0))
                PopulaSetorCliente();

            var ports = _portfolio.ConsultaPortfolio();
            if (!(ports.Count > 0))
                PopulaPortfolio();
        }

        public string Retorno(List<Entrada> entList)
        {
            try
            {
                var categoriasList = _categoria.ConsultaCategoria();
                var setorClienteList = _setorCliente.ConsultaSetorCliente();
                var portfolioList = _portfolio.ConsultaPortfolio();

                List<Trade> tradeList = this.VerificarCategoria(entList, categoriasList, setorClienteList, portfolioList);
                _trade.InsereTrade(tradeList);

                var format = string.Empty;
                foreach (var item in tradeList)
                {
                    var cat = _categoria.ConsultaCategoriaPorId(item.CategoriaId);
                    format += String.Concat("\"", cat.NomeCategoria, "\",");
                }
                return format;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Concat("Algo deu errado. MensagemErro: ", ex.Message));
            }
        }

        public List<Trade> VerificarCategoria(List<Entrada> entradaList, List<Categoria> categoriasList, List<SetorCliente> setorClienteList, List<Portfolio> portfolioList)
        {
            
            List<Trade> tradeListBll = new List<Trade>();

            foreach (var entrada in entradaList)
            {
                int catId = 0;
                int setCliId = 0;
                int portId = 0;
                if (entrada.Value < 1000000)
                {
                    catId = RetornarCatId(categoriasList, "Lowrisk");
                }
                else if (entrada.Value > 1000000)
                {
                    switch (entrada.ClientSector.ToUpper())
                    {
                        case "PUBLIC":
                            catId = RetornarCatId(categoriasList, "Mediumrisk");
                            break;
                        case "PRIVATE":
                            catId = RetornarCatId(categoriasList, "Highrisk");
                            break;
                    }
                }
                else
                {
                    var Texto = "Somente para constar que se o valor vier um milhão exato, isso não é nem maior nem menor que um milhão, entao algo poderia ser feito aqui.";
                }
                setCliId = RetornarSetCliId(setorClienteList, entrada);
                portId = RetoranrPortId(portfolioList, "Teste");

                tradeListBll.Add(new Trade(Convert.ToDecimal(entrada.Value), DateTime.Now, catId, setCliId, portId));
            }

            return tradeListBll;
        }

        private static int RetoranrPortId(List<Portfolio> portfolioList, string portNome)
        {
            return portfolioList.Where(x => x.NomePortfolio.Conter(portNome, StringComparison.OrdinalIgnoreCase)).Select(x => x.Id).FirstOrDefault();
        }

        private static int RetornarSetCliId(List<SetorCliente> setorClienteList, Entrada entrada)
        {
            return setorClienteList.Where(x => x.NomeSetorCliente.Conter(entrada.ClientSector, StringComparison.OrdinalIgnoreCase)).Select(x => x.Id).FirstOrDefault();
        }

        private static int RetornarCatId(List<Categoria> categoriasList, string catNome)
        {
            return categoriasList.Where(x => x.NomeCategoria.Conter(catNome, StringComparison.OrdinalIgnoreCase)).Select(x => x.Id).FirstOrDefault();
        }

        private void PopulaPortfolio()
        {
            List<Portfolio> portPop = new List<Portfolio>();
            portPop.Add(new Portfolio("Teste"));
            _portfolio.InserePortfolio(portPop);
        }

        private void PopulaSetorCliente()
        {
            List<SetorCliente> setCliPop = new List<SetorCliente>();
            setCliPop.Add(new SetorCliente("Public"));
            setCliPop.Add(new SetorCliente("Private"));
            _setorCliente.InsereSetorCliente(setCliPop);
        }

        private void PopulaCategoria()
        {
            List<Categoria> catPop = new List<Categoria>();
            catPop.Add(new Categoria("LowRisk"));
            catPop.Add(new Categoria("MediumRisk"));
            catPop.Add(new Categoria("HighRisk"));
            _categoria.InsereCategoria(catPop);
        }
    }
}
