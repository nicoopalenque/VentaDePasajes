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
using System.Data;
using ClasesBase;

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para vtnCliente.xaml
    /// </summary>
    public partial class vtnCliente : Window
    {
       
        public vtnCliente()
        {
            InitializeComponent();
            traerClientes();
        }

        void traerClientes()
        {
            lstCliente.DataContext = TrabajarClientes.traerClientes();
        }

        void clearFormAdd()
        {
            txtDNI.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtEmail.Text = string.Empty;
        }

        void clearFormUpdate()
        {
            txtDNIBuscar.Text = string.Empty;
            txtDNIed.Text = string.Empty;
            txtApellidoed.Text = string.Empty;
            txtNombreed.Text = string.Empty;
            txtTelefonoed.Text = string.Empty;
            txtEmailed.Text = string.Empty;
        }     

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (txtDNI.Text != string.Empty && txtApellido.Text != string.Empty && txtNombre.Text != string.Empty && txtTelefono.Text != string.Empty)
            {
                MessageBoxResult respuesta = MessageBox.Show("¿Desea guardar los datos?", "Alta de Cliente.", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (respuesta == MessageBoxResult.Yes)
                {
                    Cliente oCliente = new Cliente();
                    oCliente.Cli_DNI = Convert.ToInt32(txtDNI.Text);
                    oCliente.Cli_Apellido = txtApellido.Text;
                    oCliente.Cli_Nombre = txtNombre.Text;
                    oCliente.Cli_Telefono = txtTelefono.Text;
                    oCliente.Cli_Email = txtEmail.Text;

                    string dni = txtDNI.Text;

                    if (TrabajarClientes.traerCliente(dni) == null)
                    {
                        TrabajarClientes.agregarCliente(oCliente);

                        MessageBox.Show("El cliente ha sido registrado.", "¡Información!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        MessageBox.Show("DNI: " + oCliente.Cli_DNI + "\nApellido: " + oCliente.Cli_Apellido + "\nNombre: " + oCliente.Cli_Nombre +
                                        "\nTeléfono:" + oCliente.Cli_Telefono + "\nE-Mail: " + oCliente.Cli_Email, "Datos Almacenados", MessageBoxButton.OK, MessageBoxImage.Information);

                        clearFormAdd();
                        grdClienteAlta.Visibility = Visibility.Hidden;
                        grdCliente.Visibility = Visibility.Visible;
                    }
                    else {
                        MessageBox.Show("El DNI ya esta registrado");
                        clearFormAdd();
                    }
                    
                }
            }
            else
            {
                MessageBox.Show("Complete todos los campos necesarios.", "¡Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
             traerClientes();
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            grdClienteEdit.Visibility = Visibility.Collapsed;
            grdCliente.Visibility = Visibility.Collapsed;
            grdClienteAlta.Visibility = Visibility.Visible;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            grdClienteEdit.Visibility = Visibility.Collapsed;
            grdClienteAlta.Visibility = Visibility.Collapsed;
            grdCliente.Visibility = Visibility.Visible;
        }

        private void btnEditUser_Click(object sender, RoutedEventArgs e)
        {
            DataRowView drv = (DataRowView)lstCliente.SelectedItem;

            if (drv != null)
            {
                int dni = (Int32)drv["Cli_DNI"];
                string nombre = (string)drv["Cli_Nombre"];
                string apellido = (string)drv["Cli_Apellido"];
                string telefono = (string)drv["Cli_Telefono"];
                string email = (string)drv["Cli_Email"];

                txtDNIed.Text = Convert.ToString(dni);
                txtNombreed.Text = nombre;
                txtApellidoed.Text = apellido;
                txtTelefonoed.Text = telefono;
                txtEmailed.Text = email;

                grdCliente.Visibility = Visibility.Collapsed;
                grdClienteAlta.Visibility = Visibility.Collapsed;
                grdClienteEdit.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro.", "¡Advertencia!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnModificarUser_Click(object sender, RoutedEventArgs e)
        {
            if (txtApellidoed.Text != string.Empty && txtNombreed.Text != string.Empty && txtTelefonoed.Text != string.Empty)
            {
                MessageBoxResult respuesta = MessageBox.Show("¿Desea modificar los datos?", "Actualización de Cliente.", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (respuesta == MessageBoxResult.Yes)
                {
                    Cliente oCliente = new Cliente();
                    oCliente.Cli_DNI = Convert.ToInt32(txtDNIed.Text);
                    oCliente.Cli_Nombre = txtNombreed.Text;
                    oCliente.Cli_Apellido = txtApellidoed.Text;
                    oCliente.Cli_Telefono = txtTelefonoed.Text;
                    oCliente.Cli_Email = txtEmailed.Text;

                    TrabajarClientes.actualizarCliente(oCliente);

                    MessageBox.Show("El registro ha sido actualizado.", "¡Información!", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                    clearFormUpdate();
                    traerClientes();
                }
            }
            else
            {
                MessageBox.Show("Complete todos los campos necesarios.", "¡Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            DataRowView drv = (DataRowView)lstCliente.SelectedItem;

            if (drv != null)
            {
                MessageBoxResult respuesta = MessageBox.Show("¿Desea realmente eliminar el registro?", "Eliminar Cliente.", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (respuesta == MessageBoxResult.Yes)
                {
                    int dni = (Int32)drv["Cli_DNI"];

                    TrabajarClientes.eliminarCliente(dni);

                    MessageBox.Show("El registro ha sido eliminado.", "¡Información!", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                    traerClientes();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro.", "¡Advertencia!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (txtBusqueda.Text == "")
            {
               MessageBox.Show("Debe ingresar DNI para realizar la busqueda.", "¡Atención!", MessageBoxButton.OK, MessageBoxImage.Warning);
                traerClientes();
            }
            else
            {
                string dni;
                dni = txtBusqueda.Text;

                if ( TrabajarClientes.traerCliente(dni) == null)
                {
                    MessageBox.Show("Sin resultado.\nDNI no registrado.", "¡Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                    traerClientes();
                }
                else
                {
                   lstCliente.DataContext = TrabajarClientes.buscarPorDNI(dni);
               }
            }
            txtBusqueda.Text = "";
        }

        public void btnUpdate_Click(object sender, RoutedEventArgs e) 
        {
            traerClientes();
        }

        private void LogoutOP(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CerrarOperador(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void ClickCliente(object sender, RoutedEventArgs e)
        {
            vtnCliente oVtnCliente = new vtnCliente();
            this.Hide();
            oVtnCliente.Show();
        }

        private void ClickCViaje(object sender, RoutedEventArgs e)
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
