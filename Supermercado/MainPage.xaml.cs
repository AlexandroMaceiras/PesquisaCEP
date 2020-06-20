using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Supermercado.Servico.Modelo;
using Supermercado.Servico;

namespace Supermercado
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BOTAO.Clicked += BuscarCEP;
        }

        private void BuscarCEP(object sender, EventArgs args)
        {
            string cep = CEP.Text.Trim();

            if (isValidCEP(cep))
            {
                try
                {

                    Endereco end = viaCEPServico.BuscaEnderecoViaCEP(cep);

                    if (end != null)
                    {

                        string resultado = "";
                        resultado += String.Format("CEP: {0}", end.cep) + "\n";
                        resultado += String.Format("Logradouro: {0}", end.logradouro) + "\n";
                        resultado += String.Format("Complemento: {0}", end.complemento) + "\n";
                        resultado += String.Format("Bairro: {0}", end.bairro) + "\n";
                        resultado += String.Format("Localidade: {0}", end.localidade) + "\n";
                        resultado += String.Format("UF: {0}", end.uf) + "\n";
                        resultado += String.Format("Unidade: {0}", end.unidade) + "\n";
                        resultado += String.Format("IBGE: {0}", end.ibge) + "\n";
                        resultado += String.Format("GIA: {0}", end.gia) + "\n";

                        RESULTADO.Text = resultado;
                    }
                    else
                    {
                        DisplayAlert("ERRO", "O endereço não foi encontrado para o CEP " + cep, "[OK]");
                    }
                }
                catch (Exception ex)
                {
                    DisplayAlert("Erro Crítico", ex.Message, "[OK]");
                }
            }
        }

        private bool isValidCEP(string cep)
        {
            bool valido = true;
            int NovoCEP = 0;

            //Os DisplayAlerts aparecem em sequência inversa. O último aparece primeiro. Isto é da natureza dele, 
            //não existe forma de mudar. Existe muitas outras formas de apresentar mensagens este é só feito para um alerta único
            //então o mais recente aparece antes do anterior pois ele é o úmtimo a ser processado como um ALERTA mais urgente.
            //Quando o foco volta para o usuário eles vão aparecendo inversos como que o último tenha sido escrito sobre os outros.

            if (!int.TryParse(cep, out NovoCEP))
            {
                DisplayAlert("ERRO", "CEP inválido! \nCEP deve ter só números.", "[OK]", "[VOLTAR]");
                valido = false;
            }

            if (cep.Length != 8)
            {
                var mais = "";
                if (valido == false)
                    mais = "[MAIS]";
                else
                    mais = "[OK]";

                DisplayAlert("ERRO", "CEP inválido! \nO CEP deve ter 8 caracteres.", mais,"[VOLTAR]");
                valido = false;
            }

            return valido;
        }
    }
}
