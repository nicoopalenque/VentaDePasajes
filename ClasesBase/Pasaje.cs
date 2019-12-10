using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class Pasaje
    {
        private int pas_codigo;
        private int cli_dni;
        private int ser_codigo;
        private int pas_asiento;
        private decimal pas_precio;
        private DateTime pas_fechahora;
        private string cli_nombre;
        private string cli_apellido;
        private DateTime ser_fechahora;
        private string ciu_origen;
        private string ciu_destino;
        private int aut_codigo;
        private string aut_matricula;
        private string aut_servicio;
        private string emp_nombre;
        private int emp_codigo;

        public int Pas_Codigo { get { return pas_codigo; } set { pas_codigo = value; } }
        public int Cli_DNI { get { return cli_dni; } set { cli_dni = value; } }
        public int Ser_Codigo { get { return ser_codigo; } set { ser_codigo = value; } }
        public int Pas_Asiento { get { return pas_asiento; } set { pas_asiento = value; } }
        public decimal Pas_Precio { get { return pas_precio; } set { pas_precio = value; } }
        public DateTime Pas_FechaHora { get { return pas_fechahora; } set { pas_fechahora = value; } }
        public string Cli_Nombre { get { return cli_nombre; } set { cli_nombre = value; } }
        public string Cli_Apellido { get { return cli_apellido; } set { cli_apellido = value; } }
        public DateTime Ser_FechaHora { get { return ser_fechahora; } set { ser_fechahora = value; } }
        public string Ciu_Origen { get { return ciu_origen; } set { ciu_origen = value; } }
        public string Ciu_Destino { get { return ciu_destino; } set { ciu_destino = value; } }
        public string Aut_Matricula { get { return aut_matricula; } set { aut_matricula = value; } }
        public string Aut_Servicio { get { return aut_servicio; } set { aut_servicio = value; } }
        public string Emp_Nombre { get { return emp_nombre; } set { emp_nombre = value; } }
        public int Emp_Codigo { get { return emp_codigo; } set { emp_codigo = value; } }
        public int Aut_Codigo { get { return aut_codigo; } set { aut_codigo = value; } }

    }
}
