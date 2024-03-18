using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repaso_2
{
    internal class Alquiler
    {
        int nit;
        string placa;
        DateTime fechaIg;
        DateTime fechaDev;
        int km;

        public int Nit { get => nit; set => nit = value; }
        public string Placa { get => placa; set => placa = value; }
        public DateTime FechaIg { get => fechaIg; set => fechaIg = value; }
        public DateTime FechaDev { get => fechaDev; set => fechaDev = value; }
        public int Km { get => km; set => km = value; }
    }
}
