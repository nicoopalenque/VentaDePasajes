using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class Servicio
    {

        private int ser_codigo;
        private int aut_codigo;
        private DateTime ser_FechaHora;
        private int ter_CodigoOrigen;
        private int ter_CodigoDestino;
        private string ser_estado;

        private string origen;
        private string destino;
        private string nombreEmpresa;
        private string telefonoEmpresa;
        private string direccionEmpresa;
        private string emailEmpresa;
        private int autobusCapacidad;
        private string autobusMatricula;
        private int autobusPisos;
        private string autobusTipoServicio;


        public int Ser_Codigo { get { return ser_codigo; } set { ser_codigo = value; } }
        public int Aut_Codigo { get { return aut_codigo; } set { aut_codigo = value; } }
        public DateTime Ser_FechaHora { get { return ser_FechaHora; } set { ser_FechaHora = value; } }
        public int Ter_Codigo_Origen { get { return ter_CodigoOrigen; } set { ter_CodigoOrigen = value; } }
        public int Ter_Codigo_Destino { get { return ter_CodigoDestino; } set { ter_CodigoDestino = value; } }
        public string Ser_Estado { get { return ser_estado; } set { ser_estado = value; } } //Activo, Cancelado

        public string Ter_Origen { get { return origen; } set { origen = value; } } 
        public string Ter_Destino { get { return destino; } set { destino = value; } } 
        public string Emp_Nombre { get { return nombreEmpresa; } set { nombreEmpresa = value; } } 
        public string Emp_Telefono { get { return telefonoEmpresa; } set { telefonoEmpresa = value; } } 
        public string Emp_Direccion { get { return direccionEmpresa; } set { direccionEmpresa = value; } } 
        public string Emp_Email { get { return emailEmpresa; } set { emailEmpresa = value; } } 
        public int Aut_Capacidad { get { return autobusCapacidad; } set { autobusCapacidad = value; } } 
        public string Aut_Matricula { get { return autobusMatricula; } set { autobusMatricula = value; } } 
        public int Aut_Pisos { get { return autobusPisos; } set { autobusPisos = value; } } 
        public string Aut_TipoServicio { get { return autobusTipoServicio; } set { autobusTipoServicio = value; } }

        //public Empresa Emp_Nombre { get; set; }
        //public Empresa Emp_Telefono { get; set; }
        //public Empresa Emp_Direccion { get; set; }
        //public Empresa Emp_Email { get; set; }
        //public Autobus Aut_Capacidad { get; set; }
        //public Autobus Aut_Matricula { get; set; }
        //public Autobus Aut_CantidadPisos { get; set; }
        //public Autobus Aut_TipoServicio { get; set; }

    }
}
