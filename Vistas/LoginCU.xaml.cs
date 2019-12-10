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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClasesBase;
namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para LoginCU.xaml
    /// </summary>
    public partial class LoginCU : UserControl

    {
        public static Usuario oUsuario;

        public LoginCU()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, RoutedEventArgs e)
        {  
            LoginCU login = new LoginCU();

            if (txtUsuario.Text == string.Empty || txtContraseña.Password == string.Empty)
            {
                MessageBox.Show("Ingrese Usuario y/o Contraseña.", "Datos Incompletos", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                string u = txtUsuario.Text;
                string p = txtContraseña.Password;

                oUsuario = TrabajarUsuarios.validarUsuario(u, p);
                if (oUsuario != null)
                {
                    vtnLogin oLogin = new vtnLogin();                    
                    oLogin.Hide();
                    
                    vtnPrincipal oPrincipal = new vtnPrincipal();

                    oPrincipal.Show();

                    
                }
                else
                {
                    MessageBox.Show("Usuario y/o contraseña incorrecto/s", "¡ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            txtUsuario.Clear();
            txtContraseña.Clear();
        }
    }
}
