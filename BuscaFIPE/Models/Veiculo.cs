using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuscaFIPE.Models
{
    public class Veiculo
    {
        public string Tipo { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int AnoModelo { get; set; }
        public string Combustivel { get; set; }
        public string CodigoFipe { get; set; }
        public string MesReferencia { get; set; }
    }
}
