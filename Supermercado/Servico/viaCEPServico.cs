using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using Supermercado.Servico.Modelo;
using Newtonsoft.Json;

namespace Supermercado.Servico
{
    public class viaCEPServico
    {
        private static string EnderecoURL = "http://viacep.com.br/ws/{0}/json";

        //WebClient wc;

        public static Endereco BuscaEnderecoViaCEP(string cep)
        {
            string NovoEnderecoURL = string.Format(EnderecoURL, cep);


            WebClient wc = new WebClient();

            string Conteudo = wc.DownloadString(NovoEnderecoURL);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(Conteudo);

            if (end.cep == null) return null;

            return JsonConvert.DeserializeObject<Endereco>(Conteudo);

            return end;
        }
    }
}
