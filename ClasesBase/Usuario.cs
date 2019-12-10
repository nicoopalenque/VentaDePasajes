using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ClasesBase
{
    public class Usuario: INotifyPropertyChanged
    {
        //Campo
        private int usu_id;
        private string usu_nombreUsuario;
        private string usu_contraseña;
        private string usu_apellidoNombre;
        private string rol_codigo;

        //Propiedad
        public int Usu_ID { get { return usu_id; } set { usu_id = value; Notificar("Usu_ID"); } }
        public string Usu_NombreUsuario { get { return usu_nombreUsuario; } set { usu_nombreUsuario = value; Notificar("Usu_NombreUsuario"); } }
        public string Usu_Contraseña { get { return usu_contraseña; } set { usu_contraseña = value; Notificar("Usu_Contraseña"); } }
        public string Usu_ApellidoNombre { get { return usu_apellidoNombre; } set { usu_apellidoNombre = value; Notificar("Usu_ApellidoNombre"); } }
        public string Rol_Codigo { get { return rol_codigo; } set { rol_codigo = value; Notificar("Rol_Codigo"); } }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void Notificar(string NombrePropiedad)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(NombrePropiedad));
            }
        }
    }
}
