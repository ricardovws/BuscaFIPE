using BuscaFIPE.Models;
using BuscaFIPE.Models.JSON_Classes;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            
            return GetListaDeModelos(resposta.Content.
                ReadAsAsync<InfoFipeApiModelosAnos>().Result);

        }

        public async Task<InfosFipeApiViewModel> GetAnosAsync(string veiculo, string codigoMarca, string codigoModelo)
        {
            var resposta = await _httpClient.GetAsync
                ($"{veiculo}/marcas/{codigoMarca}/modelos/{codigoModelo}/anos");
            resposta.EnsureSuccessStatusCode();

            return GetListaDeAnos(resposta.Content.
                ReadAsAsync<List<InfoFipeApi>>().Result);
        }

        public async Task<InfosFipeApiViewModel> GetVeiculoAsync(string veiculo, string codigoMarca, string codigoModelo, string codigoAno)
        {
            var resposta = await _httpClient.GetAsync
                ($"{veiculo}/marcas/{codigoMarca}/modelos/{codigoModelo}/anos/{codigoAno}");
            resposta.EnsureSuccessStatusCode();

            return new InfosFipeApiViewModel
            {
                VeiculoSelecionado = resposta.Content.
                    ReadAsAsync<InfoFipeApiVeiculo>().Result
            };

        }

        private InfosFipeApiViewModel GetListaDeMarcas(List<InfoFipeApi> marcas)
        {

            var marcasVeiculo = new InfosFipeApiViewModel();

            AdicionaOpcaoNaLista(marcasVeiculo.ListaDeMarcasParaFiltrar);

            foreach (var marca in marcas)
            {
                marcasVeiculo.ListaDeMarcasParaFiltrar.Add
                    (new SelectListItem { Value = $"{marca.codigo}", Text = $"{marca.nome}" });
            }

            return marcasVeiculo;
        }

        private InfosFipeApiViewModel GetListaDeModelos(InfoFipeApiModelosAnos modelos)
        {

            var modelosVeiculo = new InfosFipeApiViewModel();

            AdicionaOpcaoNaLista(modelosVeiculo.ListaDeModelosParaFiltrar);

            foreach (var modelo in modelos.modelos)
            {
                modelosVeiculo.ListaDeModelosParaFiltrar.Add
                    (new SelectListItem { Value = $"{modelo.codigo}", Text = $"{modelo.nome}" });
            }

            return modelosVeiculo;
        }

        private InfosFipeApiViewModel GetListaDeAnos(List<InfoFipeApi> anos)
        {

            var anosVeiculo = new InfosFipeApiViewModel();

            AdicionaOpcaoNaLista(anosVeiculo.ListaDeAnosParaFiltrar);

            foreach (var ano in anos)
            {
                anosVeiculo.ListaDeAnosParaFiltrar.Add
                    (new SelectListItem { Value = $"{ano.codigo}", Text = $"{ano.nome}" });
            }

            return anosVeiculo;
        }

        private void AdicionaOpcaoNaLista(List<SelectListItem> lista)
        {
            lista.Add(new SelectListItem { Value = "", Text = "Selecione uma opção" });
        }

    }
}
