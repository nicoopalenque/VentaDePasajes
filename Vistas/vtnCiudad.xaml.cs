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
using System.Data;

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para vtnCiudad.xaml
    /// </summary>
    public partial class vtnCiudad : Window
    {
        public vtnCiudad()
        {
            InitializeComponent();

            traerCiudades();
        }

        void traerCiudades()
        {
            lstCiudades.DataContext = TrabajarCiudades.traerCiudades();
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (txtCiudad.Text != string.Empty)
            {
                MessageBoxResult respuesta = MessageBox.Show("¿Desea guardar los datos?", "Registro de Ciudad", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (respuesta == MessageBoxResult.Yes)
                {
                    Ciudad oCiudad = new Ciudad();
                    oCiudad.Ciu_Nombre = txtCiudad.Text;
                    TrabajarCiudades.agregarCiudad(oCiudad);
                    traerCiudades();
                    MessageBox.Show("El datos han sido registrados.", "¡Información!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar el nombre de una ciudad para poder registrarla.");
            }
            txtCiudad.Text = "";
           
        }

        private void CerrarAdmin(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void LogoutADM(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ClickUsuario(object sender, RoutedEventArgs e)
        {
            vtnUsuarios oVtnUsuario = new vtnUsuarios();
            this.Hide();
            oVtnUsuario.Show();
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

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            DataRowView drv = (DataRowView)lstCiudades.SelectedItem;

            if (drv != null)
            {
                MessageBoxResult respuesta = MessageBox.Show("¿Desea realmente eliminar el registro de ciudad?", "Eliminar Ciudad.", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (respuesta == MessageBoxResult.Yes)
                {
                    int codigo = (Int32)drv["Ciu_Codigo"];

                    TrabajarCiudades.eliminarCiudad(codigo);

                    MessageBox.Show("El registro de ciudad ha sido eliminado.", "¡Información!", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                    traerCiudades();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una ciudad.", "¡Advertencia!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void bntEditar_Click(object sender, RoutedEventArgs e)
        {
            DataRowView drv = (DataRowView)lstCiudades.SelectedItem;

            if (drv != null)
            {

                int codCiu = (int)drv["Ciu_Codigo"];
                string capacidad = (string)drv["Ciu_Nombre"];
                txtCiudadEdit.Text = capacidad;
                txtCodigo.Text = Convert.ToString(codCiu);
                grdCiudades.Visibility = Visibility.Hidden;
                grdCiudadEdit.Visibility = Visibility.Visible;

            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro.", "¡Advertencia!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            txtCiudad.Text = string.Empty;
        }

        private void btnAceptared_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult respuesta = MessageBox.Show("¿Desea modificar los datos de ciudad?", "Actualización de Autobus.", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (respuesta == MessageBoxResult.Yes)
            {
                Ciudad oCiudad = new Ciudad();
                oCiudad.Ciu_Codigo = Convert.ToInt32(txtCodigo.Text);
                oCiudad.Ciu_Nombre = txtCiudadEdit.Text;

                TrabajarCiudades.actualizarCiudad(oCiudad);

                MessageBox.Show("El registro ha sido actualizado.", "¡Información!", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                
            }
            else
            {
                MessageBox.Show("Complete todos los campos necesarios.", "¡Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            traerCiudades();
            grdCiudadEdit.Visibility = Visibility.Hidden;
            grdCiudades.Visibility = Visibility.Visible;
            txtCodigo.Text = string.Empty;
            txtCiudadEdit.Text = string.Empty;

        }

        private void btnCancelared_Click(object sender, RoutedEventArgs e)
        {
            grdCiudadEdit.Visibility = Visibility.Hidden;
            grdCiudades.Visibility = Visibility.Visible;
            txtCodigo.Text = string.Empty;
            txtCiudadEdit.Text = string.Empty;
        }

     
    }
}
