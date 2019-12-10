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
    /// Lógica de interacción para vtnTerminal.xaml
    /// </summary>
    public partial class vtnTerminal : Window
    {
        public vtnTerminal()
        {
            InitializeComponent();
            traerTerminales();
        }

        void traerTerminales()
        {
            lstTerminales.DataContext = TrabajarTerminales.traerTerminales();
        }
                

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            grdTerminal.Visibility = Visibility.Collapsed;
            grdAltaTerminal.Visibility = Visibility.Visible;

        }

        private void bntEditar_Click(object sender, RoutedEventArgs e)
        {
            DataRowView drv = (DataRowView)lstTerminales.SelectedItem;

            if (drv != null)
            {
                int codTer = (int)drv["Ter_Codigo"];
                string nombre = (string)drv["Ter_Nombre"];

                txtCodTerminal.Text = Convert.ToString(codTer);
                txtTerminaled.Text = nombre;
                grdTerminal.Visibility = Visibility.Hidden;
                grdEditTerminal.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro.", "¡Advertencia!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            DataRowView drv = (DataRowView)lstTerminales.SelectedItem;

            if (drv != null)
            {
                MessageBoxResult respuesta = MessageBox.Show("¿Desea realmente eliminar el registro?", "Eliminar Terminal.", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (respuesta == MessageBoxResult.Yes)
                {
                    int codigo = (Int32)drv["Ter_Codigo"];

                    TrabajarTerminales.eliminarTerminal(codigo);

                    MessageBox.Show("La terminal ha sido eliminado.", "¡Información!", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                    traerTerminales();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una Terminal.", "¡Advertencia!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (txtTerminal.Text != string.Empty)
            {
                MessageBoxResult respuesta = MessageBox.Show("¿Desea guardar los datos?", "Alta de Terminal.", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (respuesta == MessageBoxResult.Yes)
                {
                    Terminal oTerminal = new Terminal();
                    oTerminal.Ciu_Codigo = (Int32)cmbCiudad.SelectedValue;
                    oTerminal.Ter_Nombre = txtTerminal.Text;


                    TrabajarTerminales.agregarTerminal(oTerminal);

                    MessageBox.Show("La terminal ha sido registrado.", "¡Información!", MessageBoxButton.OK, MessageBoxImage.Exclamation);


                  
                }
            }
            else
            {
                MessageBox.Show("Complete todos los campos necesarios.", "¡Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            traerTerminales();
            grdAltaTerminal.Visibility = Visibility.Hidden;
            grdTerminal.Visibility = Visibility.Visible;
            cmbCiudad.SelectedItem = "";
            txtTerminal.Text = string.Empty;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            grdAltaTerminal.Visibility = Visibility.Collapsed;
            grdTerminal.Visibility = Visibility.Visible;
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

        private void btnCancelared_Click(object sender, RoutedEventArgs e)
        {
            grdEditTerminal.Visibility = Visibility.Collapsed;
            grdTerminal.Visibility = Visibility.Visible;
        }

        private void btnAceptared_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult respuesta = MessageBox.Show("¿Desea modificar los datos?", "Actualización de Terminal.", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (respuesta == MessageBoxResult.Yes)
            {
                Terminal oTerminal = new Terminal();
                oTerminal.Ter_Codigo = Convert.ToInt32(txtCodTerminal.Text);
                oTerminal.Ciu_Codigo = Convert.ToInt32(cmbCiudadEd.SelectedValue);
                oTerminal.Ter_Nombre = txtTerminaled.Text;
               

                TrabajarTerminales.actualizarTerminal(oTerminal);

                MessageBox.Show("El registro ha sido actualizado.", "¡Información!", MessageBoxButton.OK, MessageBoxImage.Exclamation);

               
            }
            else
            {
                MessageBox.Show("Complete todos los campos necesarios.", "¡Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            traerTerminales();
            grdEditTerminal.Visibility = Visibility.Hidden;
            grdTerminal.Visibility = Visibility.Visible;
        }
    }
}
