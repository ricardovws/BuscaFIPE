using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BuscaFIPE.Models;
using BuscaFIPE.Models.JSON_Classes;

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
            var infos = new InfosFipeApiViewModel
            {
                VeiculoSelecionado = new InfoFipeApiVeiculo()
            };
            
            return View(infos);
        }

        [HttpGet]
        public IActionResult MostraMarcas(string veiculo)
        {
            var listaDeMarcas = _api.GetMarcasAsync(veiculo).Result;
            return PartialView("_Marcas", listaDeMarcas);
        }

        [HttpGet]
        public IActionResult MostraModelos(string veiculo, string codigoMarca)
        {
            var listaDeModelos = _api.GetModelosAsync(veiculo, codigoMarca).Result;
            return PartialView("_Modelos", listaDeModelos);
        }

        [HttpGet]
        public IActionResult MostraAnos(string veiculo, string codigoMarca, string codigoModelo)
        {
            var listaDeAnos = _api.GetAnosAsync(veiculo, codigoMarca, codigoModelo).Result;
            return PartialView("_Anos", listaDeAnos);
        }

        [HttpGet]
        public IActionResult MostraVeiculo(string veiculo, string codigoMarca, string codigoModelo, string codigoAno)
        {
            var veiculoSelecionado = _api.GetVeiculoAsync(veiculo, codigoMarca, codigoModelo, codigoAno).Result;
            return PartialView("_Veiculo", veiculoSelecionado);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
