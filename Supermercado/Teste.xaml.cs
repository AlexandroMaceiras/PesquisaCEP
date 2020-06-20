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
    public partial class Teste : ContentPage
    {
        public Teste()
        {
            InitializeComponent();

            BOTAO.Clicked += BuscarCEP;
        }

        private void BuscarCEP(object sender, EventArgs args)
        {
            string cep = CEP.Text.Trim();
            Endereco end = viaCEPServico.BuscaEnderecoViaCEP(cep);

            string resultado = "";
            resultado += String.Format("CEP2: {0}", end.cep) + "\n";
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
    }
}
