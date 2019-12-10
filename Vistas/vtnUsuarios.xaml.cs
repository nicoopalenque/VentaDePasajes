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
using System.Collections.ObjectModel;

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para vtnUsuarios.xaml
    /// </summary>
    public partial class vtnUsuarios : Window
    {
        public vtnUsuarios()
        {
            InitializeComponent();
        }

        ObservableCollection<Usuario> miListaUsuarios;
        CollectionView vista;
        CollectionViewSource cv;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            miListaUsuarios = ((ObjectDataProvider)this.Resources["listaUsuarios"]).Data as ObservableCollection<Usuario>;
            vista = CollectionViewSource.GetDefaultView(miListaUsuarios) as CollectionView;
            cv = (CollectionViewSource)this.Resources["listaUsuariosOrdenados"];
        }

        void clearAddUser()
        {
            txtID.Text = string.Empty;
            txtAyNAlta.Text = string.Empty;
            txtUsernameAlta.Text = string.Empty;
            txtPasswordAlta.Text = string.Empty;
            cmbRolAlta.SelectedIndex = -1;
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (txtAyNAlta.Text != string.Empty && txtUsernameAlta.Text != string.Empty && txtPasswordAlta.Text != string.Empty)
            {
                MessageBoxResult respuesta = MessageBox.Show("¿Desea guardar los datos?", "Alta de Usuario.", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (respuesta == MessageBoxResult.Yes)
                {
                    Usuario oUsuario = new Usuario();
                    oUsuario.Usu_ApellidoNombre = txtAyNAlta.Text;
                    oUsuario.Usu_NombreUsuario = txtUsernameAlta.Text;
                    oUsuario.Usu_Contraseña = txtPasswordAlta.Text;
                    oUsuario.Rol_Codigo = (string)cmbRolAlta.SelectedValue;
                    
                    oUsuario.Usu_ID = TrabajarUsuarios.agregarUsuario(oUsuario);

                    miListaUsuarios.Add(oUsuario);

                    MessageBox.Show("El Usuario ha sido registrado.", "¡Información!", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                    clearAddUser();

                    grdUsuarioAlta.Visibility = Visibility.Collapsed;
                    grdUsuario.Visibility = Visibility.Visible;
                }
            }
            else
            {
                MessageBox.Show("Complete todos los campos necesarios.", "¡Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (txtAyNEditar.Text != string.Empty && txtUsernameEditar.Text != string.Empty && txtPasswordEditar.Text != string.Empty)
            {
                Usuario oUsuario = new Usuario();

                miListaUsuarios[vista.CurrentPosition].Usu_ID = Convert.ToInt32(txtID.Text);
                miListaUsuarios[vista.CurrentPosition].Usu_NombreUsuario = txtUsernameEditar.Text;
                miListaUsuarios[vista.CurrentPosition].Usu_ApellidoNombre = txtAyNEditar.Text;
                miListaUsuarios[vista.CurrentPosition].Usu_Contraseña = txtPasswordEditar.Text;
                miListaUsuarios[vista.CurrentPosition].Rol_Codigo = (string)cmbRolEditar.SelectedValue;;

                TrabajarUsuarios.actualizarUsuario((Usuario)vista.CurrentItem);
                              
                grdUsuarioEditar.Visibility = Visibility.Collapsed;
                grdUsuario.Visibility = Visibility.Visible;
                
                MessageBox.Show("Los datos del usuario han sido actualizados.", "AVISO", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Complete todos los campos.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void btnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            Usuario oUsuario = vista.CurrentItem as Usuario;
            if (oUsuario != null)
            {
                MessageBoxResult respuesta = MessageBox.Show("¿Desea realmente eliminar al usuario «"+ oUsuario.Usu_ApellidoNombre + "» ?", "Eliminar Usuario.", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (respuesta == MessageBoxResult.Yes)
                {
                    TrabajarUsuarios.eliminarUsuario(oUsuario);
                    miListaUsuarios.Remove(oUsuario);
                    MessageBox.Show("El Usuario ha sido eliminado.", "¡Información!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Algo salió mal.", "¡Error Inesperado!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintDocument(((IDocumentPaginatorSource)DocPrueba).DocumentPaginator, "Impresión Documento Dinámico");
            }
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            grdUsuarioAlta.Visibility = Visibility.Visible;
            grdUsuario.Visibility = Visibility.Collapsed;
        }

        private void btnEditUser_Click(object sender, RoutedEventArgs e)
        {
            grdUsuarioEditar.Visibility = Visibility.Visible;
            grdUsuario.Visibility = Visibility.Collapsed;
            
            txtIDEditar.Text = txtID.Text;
            txtUsernameEditar.Text = txtUsername.Text;
            txtPasswordEditar.Text = txtPassword.Text;
            txtAyNEditar.Text = txtAyN.Text;
            cmbRolEditar.SelectedValue = txtRol.Text;
        }

        private void btnListUsers_Click(object sender, RoutedEventArgs e)
        {
            grdListaUsuarios.Visibility = Visibility.Visible;
            grdUsuario.Visibility = Visibility.Collapsed;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            grdUsuario.Visibility = Visibility.Visible;
            grdUsuarioEditar.Visibility = Visibility.Collapsed;
            grdUsuarioAlta.Visibility = Visibility.Collapsed;
        }

        private void btnFirst_Click(object sender, RoutedEventArgs e)
        {
            vista.MoveCurrentToFirst();
        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            vista.MoveCurrentToPrevious();

            if (vista.IsCurrentBeforeFirst)
            {
                vista.MoveCurrentToLast();
            }
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            vista.MoveCurrentToNext();
            
            if (vista.IsCurrentAfterLast)
            {
                vista.MoveCurrentToFirst();
            }
        }

        private void btnLast_Click(object sender, RoutedEventArgs e)
        {
            vista.MoveCurrentToLast();
        }

        private void btnFiltrar_Click(object sender, RoutedEventArgs e)
        {
            if (cv != null)
            {
                cv.Filter += new FilterEventHandler(CollectionViewSource_Filter);
            }
        }

        private void CollectionViewSource_Filter(object sender, FilterEventArgs e)
        {
            if (txtFiltrar != null)
            {
                string cadena = txtFiltrar.Text;

                Usuario oUsuario = e.Item as Usuario;
                if (oUsuario != null)
                {
                    if (oUsuario.Usu_NombreUsuario.Contains(cadena))
                    {
                        e.Accepted = true;
                        
                    }
                    else
                    {
                        e.Accepted = false;
                    }
                }
                
            }
            
        }

        private void btnVistaPrevia_Click(object sender, RoutedEventArgs e)
        {
            if (cv != null)
            {
                cv.Filter += new FilterEventHandler(CollectionViewSource_Filter);
            }
            grdVistaPrevia.Visibility = Visibility.Visible;
            grdListaUsuarios.Visibility = Visibility.Collapsed;
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            grdListaUsuarios.Visibility = Visibility.Collapsed;
            grdUsuario.Visibility = Visibility.Visible;
        }

        private void btnVolverFiltro_Click(object sender, RoutedEventArgs e)
        {
            grdVistaPrevia.Visibility = Visibility.Collapsed;
            grdListaUsuarios.Visibility = Visibility.Visible;
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

        private void Focus(object sender, RoutedEventArgs e)
        {
            txtFiltrar.Text = string.Empty;
        }
                
    }
}
