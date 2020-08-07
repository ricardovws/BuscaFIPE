using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuscaFIPE.Models
{
    public class InfosFipeApiViewModel
    {
        //Veiculos
        public string Veiculo { get; set; }

        public List<SelectListItem> Tipos { get; } = new List<SelectListItem>
        {
            new SelectListItem {Value = "carros", Text = "Carros"},
            new SelectListItem {Value = "motos", Text = "Motos"},
            new SelectListItem {Value = "caminhoes", Text = "Caminhões"},

        };

        //Marcas
        public string  Marca { get; set; }

        public List<SelectListItem> ListaDeMarcasParaFiltrar { get; set; } = new List<SelectListItem>();

        public List<Veiculo> Marcas { get; set; } = new List<Veiculo>();
    }
}
