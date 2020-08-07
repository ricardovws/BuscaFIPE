using BuscaFIPE.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BuscaFIPE
{
    public class FipeAPI
    {
        private readonly HttpClient _httpClient;

        public FipeAPI(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<InfosFipeApiViewModel> GetMarcasAsync(string veiculo)
        {
            var resposta = await _httpClient.GetAsync
                ($"{veiculo}/marcas");
            resposta.EnsureSuccessStatusCode();

            return GetListaDeMarcas(
                resposta.Content.
                ReadAsAsync<List<InfoFipeApi>>().Result);

        }

        private InfosFipeApiViewModel GetListaDeMarcas(List<InfoFipeApi> marcas)
        {
            
            var marcasVeiculo = new InfosFipeApiViewModel();
            foreach(var marca in marcas)
            {
                var infoVeiculo = new Veiculo
                {
                    Marca = marca.nome
                };
                marcasVeiculo.Marcas.Add(infoVeiculo);
            }
            return marcasVeiculo;
        }

    }
}
