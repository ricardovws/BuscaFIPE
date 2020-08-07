using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuscaFIPE.Models
{
    public class TipoDeVeiculo
    {        
        public string Veiculo { get; set; }

        public List<SelectListItem> Tipos { get; } = new List<SelectListItem>
        {
            new SelectListItem {Value = "carros", Text = "Carros"},
            new SelectListItem {Value = "motos", Text = "Motos"},
            new SelectListItem {Value = "caminhoes", Text = "Caminhões"},

        };
    }
}
