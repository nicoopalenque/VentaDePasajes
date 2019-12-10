using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ClasesBase;

namespace Vistas
{
    
    /// <summary>
    /// Lógica de interacción para vtnPrincipal.xaml
    /// </summary>
    public partial class vtnPrincipal : Window
    {
        Usuario oUsuario = new Usuario();

        public vtnPrincipal()
        {
            InitializeComponent();
        }

        private void Load(object sender, EventArgs e)
        {
          
            if (LoginCU.oUsuario.Rol_Codigo == "ADMIN")
            {
                this.grdAdmin.Visibility = System.Windows.Visibility.Visible;
            }
            else if (LoginCU.oUsuario.Rol_Codigo == "OPE")
            {
                this.grdOperador.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void CerrarOperador(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void CerrarAdmin(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void LogoutADM(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LogoutOP(object sender, RoutedEventArgs e)
        {
            this.Close();
            vtnLogin oLogin = new vtnLogin();
            oLogin.Show();
        }

        private void ClickUsuario(object sender, RoutedEventArgs e)
        {
            vtnUsuarios oVtnUsuarios = new vtnUsuarios();
            this.Hide();
            oVtnUsuarios.Show();
        }

        private void ClickAutoBus(object sender, RoutedEventArgs e)
        {
            vtnAutobus oVtnAutobus = new vtnAutobus();
            this.Hide();
            oVtnAutobus.Show();
        }

        private void ClickEmpresa(object sender, RoutedEventArgs e)
        {
            vtnEmpresa oVtnEmpresa = new vtnEmpresa();
            this.Hide();
            oVtnEmpresa.Show();
        }

        private void ClickCiudad(object sender, RoutedEventArgs e)
        {
            vtnCiudad oVtnCiudad = new vtnCiudad();
            this.Hide();
            oVtnCiudad.Show();
        }

        private void ClickTerminal(object sender, RoutedEventArgs e)
        {
            vtnTerminal oVtnTerminal = new vtnTerminal();
            this.Hide();
            oVtnTerminal.Show();
        }

        private void ClickCliente(object sender, RoutedEventArgs e)
        {
            vtnCliente oVtnCliente = new vtnCliente();
            this.Hide();
            oVtnCliente.Show();
        }

        private void ClickViaje(object sender, RoutedEventArgs e)
        {
            vtnViaje oVtnViaje = new vtnViaje();
            this.Hide();
            oVtnViaje.Show();
        }

        private void ClickPasaje(object sender, RoutedEventArgs e)
        {
            vtnPasaje oVtnPasaje = new vtnPasaje();
            this.Hide();
            oVtnPasaje.Show();
        }

       

    }
}
