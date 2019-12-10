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
    /// Lógica de interacción para vtnEmpresa.xaml
    /// </summary>
    public partial class vtnEmpresa : Window
    {
        public vtnEmpresa()
        {
            InitializeComponent();
            traerEmpresas();
        }

        void traerEmpresas()
        {
            lstEmpresas.DataContext = TrabajarEmpresas.traerEmpresas();
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

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            grdEmpresa.Visibility = Visibility.Hidden;
            grdAltaEmpresa.Visibility = Visibility.Visible;
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            DataRowView drv = (DataRowView)lstEmpresas.SelectedItem;

            if (drv != null)
            {
                MessageBoxResult respuesta = MessageBox.Show("¿Desea realmente eliminar el registro?", "Eliminar Empresa.", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (respuesta == MessageBoxResult.Yes)
                {
                    int codigo = (Int32)drv["Emp_Codigo"];

                    TrabajarEmpresas.eliminarEmpresa(codigo);

                    MessageBox.Show("La empresa ha sido eliminada.", "¡Información!", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                    traerEmpresas();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Empresa.", "¡Advertencia!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void bntEditar_Click(object sender, RoutedEventArgs e)
        {
            DataRowView drv = (DataRowView)lstEmpresas.SelectedItem;

            if (drv != null)
            {
                int codEmpresa = (int)drv["Emp_Codigo"];
                string nombre = (string)drv["Emp_Nombre"];
                string direccion = (string)drv["Emp_Direccion"];
                string telefono = (string)drv["Emp_Telefono"];
                string email = (string)drv["Emp_Email"];

                txtCodEmpresaed.Text = Convert.ToString(codEmpresa); 
                txtNombreed.Text = nombre;
                txtDireccioned.Text = direccion;
                txtTelefonoed.Text = telefono;
                txtEmailed.Text = email;
                grdEmpresa.Visibility = Visibility.Hidden;
                grdEditEmpresa.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro.", "¡Advertencia!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            grdAltaEmpresa.Visibility = Visibility.Hidden;
            grdEmpresa.Visibility = Visibility.Visible;
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (txtNombre.Text != string.Empty && txtDireccion.Text != string.Empty && txtTelefono.Text != string.Empty && txtEmail.Text != string.Empty)
            {
                MessageBoxResult respuesta = MessageBox.Show("¿Desea guardar los datos?", "Alta de Empresa.", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (respuesta == MessageBoxResult.Yes)
                {
                    Empresa oEmpresa = new Empresa();
                    Autobus oAutobus = new Autobus();
                    oEmpresa.Emp_Nombre = txtNombre.Text;
                    oEmpresa.Emp_Direccion = txtDireccion.Text;
                    oEmpresa.Emp_Telefono = txtTelefono.Text;
                    oEmpresa.Emp_Email = txtEmail.Text;


                    TrabajarEmpresas.agregarEmpresa(oEmpresa);

                    MessageBox.Show("La Empresa ha sido registrada.", "¡Información!", MessageBoxButton.OK, MessageBoxImage.Exclamation);


                    
                }
            }
            else
            {
                MessageBox.Show("Complete todos los campos necesarios.", "¡Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            traerEmpresas();
            grdAltaEmpresa.Visibility = Visibility.Hidden;
            grdEmpresa.Visibility = Visibility.Visible;
            txtNombre.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtEmail.Text = string.Empty;
        }

        private void btnCancelaed_Click(object sender, RoutedEventArgs e)
        {
            grdEditEmpresa.Visibility = Visibility.Hidden;
            grdEmpresa.Visibility = Visibility.Visible;
        }

        private void btnAceptared_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult respuesta = MessageBox.Show("¿Desea modificar los datos?", "Actualización de Empresa.", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (respuesta == MessageBoxResult.Yes)
            {
                Empresa oEmpresa = new Empresa();
                oEmpresa.Emp_Codigo = Convert.ToInt32(txtCodEmpresaed.Text);
                oEmpresa.Emp_Nombre = txtNombreed.Text;
                oEmpresa.Emp_Direccion = txtDireccioned.Text;
                oEmpresa.Emp_Telefono = txtTelefonoed.Text;
                oEmpresa.Emp_Email = txtEmailed.Text;

                TrabajarEmpresas.actualizarEmpresa(oEmpresa);

                MessageBox.Show("El registro ha sido actualizado.", "¡Información!", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                
            }
            else
            {
                MessageBox.Show("Complete todos los campos necesarios.", "¡Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            traerEmpresas();
            grdEditEmpresa.Visibility = Visibility.Hidden;
            grdEmpresa.Visibility = Visibility.Visible;
        }

    }
}
