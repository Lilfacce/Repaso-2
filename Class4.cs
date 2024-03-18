using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repaso_2
{
    internal class Reporte
    {
        string modelo;
        string marca;
        string nombre;
        DateTime fechaDevo;
        decimal total;

        public string Modelo { get => modelo; set => modelo = value; }
        public string Marca { get => marca; set => marca = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public DateTime FechaDevo { get => fechaDevo; set => fechaDevo = value; }
        public decimal Total { get => total; set => total = value; }
    }
}
