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
            var marcas = new TipoDeVeiculo();
            return View(marcas);
        }

        public IActionResult Marcas(string marca)
        {
            return View(GetMarcas().Result);
        }

        [HttpGet]
        public async Task<InfosFipeApiViewModel> GetMarcas()
        {
            return await _api.GetMarcasAsync();
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
