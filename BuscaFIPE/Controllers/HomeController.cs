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
            return View(marcas);
        }

        private async Task<InfosFipeApiViewModel> GetMarcas(string veiculo)
        {
            return await _api.GetMarcasAsync(veiculo);       
        }

        [HttpGet]
        public IActionResult MostraMarcas(string veiculo)
        {

            var listaDeMarcas = GetMarcas(veiculo).Result;
            var listaDeMarcasParaFiltrar = GeraListaDeMarcas(listaDeMarcas);
            return PartialView("_Marcas", listaDeMarcasParaFiltrar);
        }

        private InfosFipeApiViewModel GeraListaDeMarcas(InfosFipeApiViewModel listaDeMarcas)
        {
            foreach(var marca in listaDeMarcas.Marcas)
            {
                string nomeMarca = marca.Marca;
                listaDeMarcas.ListaDeMarcasParaFiltrar.Add
                    (new SelectListItem { Value = $"{nomeMarca}", Text = $"{nomeMarca}" });
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
