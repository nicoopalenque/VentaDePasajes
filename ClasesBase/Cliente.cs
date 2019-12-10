using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Espacio de nombre para interface IDataErrorInfo
using System.ComponentModel;

namespace ClasesBase
{
    public class Cliente : IDataErrorInfo
    {
        private int cli_dni;
        private string cli_apellido;
        private string cli_nombre;
        private string cli_telefono;
        private string cli_email;

        public int Cli_DNI { get { return cli_dni; } set { cli_dni = value; } }
        public string Cli_Apellido { get { return cli_apellido; } set { cli_apellido = value; } }
        public string Cli_Nombre { get { return cli_nombre; } set { cli_nombre = value; } }
        public string Cli_Telefono { get { return cli_telefono; } set { cli_telefono = value; } }
        public string Cli_Email { get { return cli_email; } set { cli_email = value; } }



        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get
            {
                string mensaje = string.Empty;

                if (columnName == "Cli_DNI")
                {
                    if (Cli_DNI == null)
                    {
                        mensaje = "El DNI es obligatorio";
                    }
                }

                if (columnName == "Cli_Nombre")
                {
                    if (string.IsNullOrEmpty(Cli_Nombre))
                    {
                        mensaje = "El Nombre es obligatorio";
                    }
                }

                if (columnName == "Cli_Apellido")
                {
                    if (string.IsNullOrEmpty(Cli_Apellido))
                    {
                        mensaje = "El Apellido es obligatorio";
                    }
                }

                if (columnName == "Cli_Telefono")
                {
                    if (string.IsNullOrEmpty(Cli_Telefono))
                    {
                        mensaje = "El Teléfono es obligatorio";
                    }
                }

                return mensaje;
            }
        }

    }
}
