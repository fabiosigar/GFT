using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace GFT.TestTecnicoEntrada
{
    public partial class FormTecnico : Form
    {
        private BLL_TesteTecnico _regra = new BLL_TesteTecnico();

        public FormTecnico()
        {
            InitializeComponent();
        }

        private void FormTecnico_Load(object sender, EventArgs e)
        {
            MessageBox.Show(string.Concat("Criando o banco e carregando dados na base...", Environment.NewLine, "Clique ok e espere o formulario aparecer!"));
            _regra.populaBase();
        }

        private void bntEnviarEntrada_Click(object sender, EventArgs e)
        {
            tboxSaida.Text = string.Empty;
            var texto = tboxEntrada.Text;
            tboxSaida.Text = tboxEntrada.Text;
            if (!(texto.Trim() == string.Empty))
            {

                List<Entrada> entList = new List<Entrada>();

                string[] separatingString = { "}" };
                string[] tradesList = texto.Split(separatingString, System.StringSplitOptions.RemoveEmptyEntries);

                if (tradesList.Length > 1)
                {
                    for (int i = 0; i < tradesList.Length - 1; i++)
                    {
                        //Substring Valor
                        var inicioValor = tradesList[i].IndexOf('=') + 1;
                        var qtdValor = (tradesList[i].IndexOf(';')) - inicioValor;

                        //Substring SetorCliente
                        var inicioSetCli = tradesList[i].IndexOf(';') + 1;
                        var qtdSetCli = (tradesList[i].Length) - inicioSetCli;

                        //Segunda Etapa da Substring SetorCliente
                        var setCliInter = tradesList[i].Substring(inicioSetCli, qtdSetCli).Trim();
                        var inicioSetCliInter = setCliInter.IndexOf('=') + 1;
                        var qtdSetCliInter = setCliInter.Length - inicioSetCliInter;

                        //Adiciona ma lista da entidade Entrada
                        entList.Add(new Entrada((i + 1).ToString()
                                                , Convert.ToInt64(tradesList[i].Substring(inicioValor, qtdValor).Trim())
                                                , setCliInter.Substring(inicioSetCliInter, qtdSetCliInter).Replace("\"", "").Trim()));

                    }

                    var ret = _regra.Retorno(entList);
                    ret = ret.Substring(0,ret.Length-1);
                    tboxSaida.Text += string.Concat(Environment.NewLine, Environment.NewLine, "{", ret, "}");
                }
                else
                {
                    MessageBox.Show("Digite o texto com a estrutura correta.");
                }
            }
            else
            {
                MessageBox.Show("Digite o texto desejado.");
            }

            tboxEntrada.Text = string.Empty;
        }
    }
}
