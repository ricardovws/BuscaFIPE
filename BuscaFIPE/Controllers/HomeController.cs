using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BuscaFIPE.Models;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BuscaFIPE.Controllers
{
    public class HomeController : Controller
    {
        private readonly FipeAPI _api;

        public HomeController(FipeAPI api)
        {
            _api = api;
        }

        public IActionResult Index()
        {
            var marcas = new InfosFipeApiViewModel();
            var veiculo = new Veiculo();
            
            veiculo.Valor = "...";
            veiculo.Marca = "...";
            veiculo.Modelo = "...";
            veiculo.AnoModelo = "...";
            veiculo.Combustivel = "...";
            veiculo.CodigoFipe = "...";
            veiculo.MesReferencia = "...";

            marcas.VeiculoSelecionado = veiculo;
          
            return View(marcas);
           
        }

        [HttpGet]
        public IActionResult MostraMarcas(string veiculo)
        {
            var listaDeMarcas = GetMarcasAsync(veiculo).Result;
            var listaDeMarcasParaFiltrar = GeraListaDeMarcas(listaDeMarcas);
            return PartialView("_Marcas", listaDeMarcasParaFiltrar);
        }

        [HttpGet]
        public IActionResult MostraModelos(string veiculo, string codigoMarca)
        {
            var listaDeModelos = GetModelosAsync(veiculo, codigoMarca).Result;
            var listaDeModelosParaFiltrar = GeraListaDeModelos(listaDeModelos);
            return PartialView("_Modelos", listaDeModelosParaFiltrar);
        }

        [HttpGet]
        public IActionResult MostraAnos(string veiculo, string codigoMarca, string codigoModelo)
        {
            var listaDeAnos = GetAnosAsync(veiculo, codigoMarca, codigoModelo).Result;
            var listaDeAnosParaFiltrar = GeraListaDeAnos(listaDeAnos);
            return PartialView("_Anos", listaDeAnosParaFiltrar);
        }

        [HttpGet]
        public IActionResult MostraVeiculo(string veiculo, string codigoMarca, string codigoModelo, string codigoAno)
        {
            var veiculoSelecionado = GetVeiculoAsync(veiculo, codigoMarca, codigoModelo, codigoAno).Result;
            var veiculoSelecionadoView = new InfosFipeApiViewModel
            {
                VeiculoSelecionado = veiculoSelecionado
            };
            return PartialView("_Veiculo", veiculoSelecionadoView);
        }

        private async Task<Veiculo> GetVeiculoAsync(string veiculo, string codigoMarca, string codigoModelo, string codigoAno)
        {
            return await _api.GetVeiculoAsync(veiculo, codigoMarca, codigoModelo, codigoAno);
        }

        private async Task<InfosFipeApiViewModel> GetAnosAsync(string veiculo, string codigoMarca, string codigoModelo)
        {
            return await _api.GetAnosAsync(veiculo, codigoMarca, codigoModelo);
        }

        private async Task<InfosFipeApiViewModel> GetModelosAsync(string veiculo, string codigoMarca)
        {
            return await _api.GetModelosAsync(veiculo, codigoMarca);
        }

        private async Task<InfosFipeApiViewModel> GetMarcasAsync(string veiculo)
        {
            return await _api.GetMarcasAsync(veiculo);       
        }

        private InfosFipeApiViewModel GeraListaDeAnos(InfosFipeApiViewModel listaDeAnos)
        {
            foreach (var ano in listaDeAnos.Anos)
            {
                listaDeAnos.ListaDeAnosParaFiltrar.Add
                    (new SelectListItem { Value = $"{ano.CodigoAnoModelo}", Text = $"{ano.AnoModelo}" });
            }
            return listaDeAnos;
        }

        private InfosFipeApiViewModel GeraListaDeModelos(InfosFipeApiViewModel listaDeModelos)
        {
            foreach(var modelo in listaDeModelos.Modelos)
            {
                listaDeModelos.ListaDeModelosParaFiltrar.Add
                    (new SelectListItem { Value = $"{modelo.CodigoModelo}", Text = $"{modelo.Modelo}" });
            }
            return listaDeModelos;
        }

        private InfosFipeApiViewModel GeraListaDeMarcas(InfosFipeApiViewModel listaDeMarcas)
        {
            foreach(var marca in listaDeMarcas.Marcas)
            {
                listaDeMarcas.ListaDeMarcasParaFiltrar.Add
                    (new SelectListItem { Value = $"{marca.CodigoMarca}", Text = $"{marca.Marca}" });
            }
            return listaDeMarcas;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
