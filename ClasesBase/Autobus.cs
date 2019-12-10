using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class Autobus
    {
        public int Aut_Codigo { get; set; }
        public int Aut_Capacidad { get; set; }
        public string Aut_TipoServicio { get; set; } //"Cama", "Semicama"
        public string Aut_Matricula { get; set; }
        public int Aut_CantidadPisos { get; set; }
        public int Emp_Codigo { get; set; }
    }
}
