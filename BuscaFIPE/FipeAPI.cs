using BuscaFIPE.Models;
using BuscaFIPE.Models.JSON_Classes;
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

            return GetListaDeMarcas(resposta.Content.
                ReadAsAsync<List<InfoFipeApi>>().Result);

        }

        public async Task<InfosFipeApiViewModel> GetModelosAsync(string veiculo, string codigoMarca)
        {
            var resposta = await _httpClient.GetAsync
                ($"{veiculo}/marcas/{codigoMarca}/modelos");
            resposta.EnsureSuccessStatusCode();

            var teste_0 = resposta.Content.
                ReadAsAsync<InfoFipeApiModelosAnos>();
            var teste_1 = GetListaDeModelos(teste_0.Result);

            return teste_1;

        }

        public async Task<InfosFipeApiViewModel> GetAnosAsync(string veiculo, string codigoMarca, string codigoModelo)
        {
            var resposta = await _httpClient.GetAsync
                ($"{veiculo}/marcas/{codigoMarca}/modelos/{codigoModelo}/anos");
            resposta.EnsureSuccessStatusCode();

            var teste_0 = resposta.Content.ReadAsAsync<List<InfoFipeApi>>();
            var teste_1 = GetListaDeAnos(teste_0.Result);

            return teste_1;
        }

        public async Task<Veiculo> GetVeiculoAsync(string veiculo, string codigoMarca, string codigoModelo, string codigoAno)
        {
            var resposta = await _httpClient.GetAsync
                ($"{veiculo}/marcas/{codigoMarca}/modelos/{codigoModelo}/anos/{codigoAno}");
            resposta.EnsureSuccessStatusCode();

            var teste_0 = resposta.Content.ReadAsAsync<InfoFipeApiVeiculo>();
            var teste_1 = GetVeiculoSelecionado(teste_0.Result);

            return teste_1;
        }

        private Veiculo GetVeiculoSelecionado(InfoFipeApiVeiculo veiculoSelecionado)
        {
            var veiculo = new Veiculo
            {
                Valor = veiculoSelecionado.Valor,
                Marca = veiculoSelecionado.Marca,
                Modelo = veiculoSelecionado.Modelo,
                AnoModelo = veiculoSelecionado.AnoModelo,
                Combustivel = veiculoSelecionado.Combustivel,
                CodigoFipe = veiculoSelecionado.CodigoFipe,
                MesReferencia = veiculoSelecionado.MesReferencia
            };

            return veiculo;
        }

        private InfosFipeApiViewModel GetListaDeAnos(List<InfoFipeApi> anos)
        {

            var anosVeiculo = new InfosFipeApiViewModel();
            foreach (var ano in anos)
            {
                var infoVeiculo = new Veiculo
                {
                    AnoModelo = ano.nome,
                    CodigoAnoModelo = ano.codigo
                };
                anosVeiculo.Anos.Add(infoVeiculo);
            }
            return anosVeiculo;
        }


        private InfosFipeApiViewModel GetListaDeModelos(InfoFipeApiModelosAnos modelos)
        {

            var modelosVeiculo = new InfosFipeApiViewModel();
            foreach (var modelo in modelos.modelos)
            {
                var infoVeiculo = new Veiculo
                {
                    Modelo = modelo.nome,
                    CodigoModelo = modelo.codigo
                };
                modelosVeiculo.Modelos.Add(infoVeiculo);
            }
            return modelosVeiculo;
        }


        private InfosFipeApiViewModel GetListaDeMarcas(List<InfoFipeApi> marcas)
        {
            
            var marcasVeiculo = new InfosFipeApiViewModel();
            foreach(var marca in marcas)
            {
                var infoVeiculo = new Veiculo
                {
                    Marca = marca.nome,
                    CodigoMarca = marca.codigo
                };
                marcasVeiculo.Marcas.Add(infoVeiculo);
            }
            return marcasVeiculo;
        }

    }
}
