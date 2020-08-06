using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BuscaFIPE.Models;
using System.Net.Http;
using BuscaFIPE.Models.Enums;
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
            return View();
        }

        [HttpGet]
        public async Task<InfosFipeApiViewModel> GetMarcas()
        {
            return await _api.GetMarcasAsync();
        }


        public IActionResult Marcas()
        {
            return View(GetMarcas().Result);
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
