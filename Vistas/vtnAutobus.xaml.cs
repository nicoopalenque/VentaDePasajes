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
    /// Lógica de interacción para vtnAutobus.xaml
    /// </summary>
    public partial class vtnAutobus : Window
    {
        public vtnAutobus()
        {
            InitializeComponent();
            traerAutobuses();
        }


        void traerAutobuses()
        {
            lstAutobuses.DataContext = TrabajarAutobuses.traerAutobus();
        }
                
        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (txtCapacidad.Text != string.Empty && txtMatricula.Text != string.Empty && txtPisos.Text != string.Empty)
            {
                MessageBoxResult respuesta = MessageBox.Show("¿Desea guardar los datos?", "Alta de Autobus.", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (respuesta == MessageBoxResult.Yes)
                {
                    Autobus oAutobus = new Autobus();
                    oAutobus.Emp_Codigo = (Int32)cmbEmpresa.SelectedValue;
                    oAutobus.Aut_Capacidad = Convert.ToInt32(txtCapacidad.Text);
                    oAutobus.Aut_TipoServicio = Convert.ToString(cmbServicio.SelectedValue);
                    oAutobus.Aut_Matricula = txtMatricula.Text;
                    oAutobus.Aut_CantidadPisos = Convert.ToInt32(txtPisos.Text);

                    TrabajarAutobuses.agregarAutobus(oAutobus);

                    MessageBox.Show("El Autobus ha sido registrado.", "¡Información!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                   

                    clearForm();
                }
            }
            else
            {
                MessageBox.Show("Complete todos los campos necesarios.", "¡Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            traerAutobuses();
            grdAltaAutobuses.Visibility = Visibility.Hidden;
            grdAutobuses.Visibility = Visibility.Visible;
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            DataRowView drv = (DataRowView)lstAutobuses.SelectedItem;

            if (drv != null)
            {
                int codAutobus = (int)drv["Aut_Codigo"];
                int capacidad = (int)drv["Aut_Capacidad"];
                string matricula = (string)drv["Aut_Matricula"];
                int pisos = (int)drv["Aut_CantidadPisos"];

                txtIdAutobusEdit.Text = Convert.ToString(codAutobus);
                txtCapacidadEdit.Text = Convert.ToString(capacidad);
                txtMatriculaEdit.Text = matricula;
                txtPisosEdit.Text = Convert.ToString(pisos);


                grdAutobuses.Visibility = Visibility.Hidden;
                grdEditAutobuses.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro.", "¡Advertencia!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnAceptarEdit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult respuesta = MessageBox.Show("¿Desea modificar los datos?", "Actualización de Autobus.", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (respuesta == MessageBoxResult.Yes)
            {
                Autobus oAutobus = new Autobus();
                oAutobus.Aut_Codigo = Convert.ToInt32(txtIdAutobusEdit.Text);
                oAutobus.Emp_Codigo = (Int32)cmbEmpresaEdit.SelectedValue;
                oAutobus.Aut_Capacidad = Convert.ToInt32(txtCapacidadEdit.Text);
                oAutobus.Aut_TipoServicio = Convert.ToString(cmbServicioEdit.SelectedValue);
                oAutobus.Aut_Matricula = txtMatriculaEdit.Text;
                oAutobus.Aut_CantidadPisos = Convert.ToInt32(txtPisosEdit.Text);

                TrabajarAutobuses.actualizarAutobus(oAutobus);

                MessageBox.Show("El registro ha sido actualizado.", "¡Información!", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                clearForm();
            }
            else
            {
                MessageBox.Show("Complete todos los campos necesarios.", "¡Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            traerAutobuses();
            grdEditAutobuses.Visibility = Visibility.Hidden;
            grdAutobuses.Visibility = Visibility.Visible;
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            DataRowView drv = (DataRowView)lstAutobuses.SelectedItem;

            if (drv != null)
            {
                MessageBoxResult respuesta = MessageBox.Show("¿Desea realmente eliminar el registro?", "Eliminar AutoBus.", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (respuesta == MessageBoxResult.Yes)
                {
                    int codigo = (Int32)drv["Aut_Codigo"];

                    TrabajarAutobuses.eliminarAutobus(codigo);

                    MessageBox.Show("El autobus ha sido eliminado.", "¡Información!", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                    traerAutobuses();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un autobus.", "¡Advertencia!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        void clearForm()
        {
            txtCapacidad.Text = string.Empty;
            txtMatricula.Text = string.Empty;
            txtPisos.Text = string.Empty;
            cmbEmpresa.SelectedItem = "";
            cmbServicio.SelectedItem = "";
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            grdAutobuses.Visibility = Visibility.Hidden;
            grdAltaAutobuses.Visibility = Visibility.Visible;
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

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            grdAltaAutobuses.Visibility = Visibility.Hidden;
            grdAutobuses.Visibility = Visibility.Visible;
        }

        private void btnCancelarEdit_Click(object sender, RoutedEventArgs e)
        {
            grdEditAutobuses.Visibility = Visibility.Hidden;
            grdAutobuses.Visibility = Visibility.Visible;
        }
        
    }
}
