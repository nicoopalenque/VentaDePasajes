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
using System.Data;
namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para vtnViaje.xaml
    /// </summary>
    public partial class vtnViaje : Window
    {
        public vtnViaje()
        {
            
            InitializeComponent();
            lstViajes.DataContext = TrabajarViajes.traerViajes();
            
            cmbEmpresa.SelectedIndex = -1;

            cmbAutobus.SelectedIndex = -1;
        }
        static int pasajes;
        static decimal monto;
        static DateTime servicio;
        List<Pasaje> psj;
        ObservableCollection<Pasaje> miListaViajes;
        CollectionView vista;
        CollectionViewSource cv;

        void cargarHoraServicio(List <Pasaje> p)
        {
            List<int> cont = new List<int>();
            int mayor = 0;

            var pasajes = new List<Pasaje>();

            for (int i = 0; i < p.Count(); i++)
            {
                pasajes.Add(p[i]);
            }

            var pasajesOrderByServicios = pasajes.GroupBy(pasaje => pasaje.Ser_Codigo);

            foreach (var group in pasajesOrderByServicios)
            {
                cont.Add(group.Count());
                if (group.Count() > mayor )
                {
                    mayor = group.Count();
                    foreach (var ser in group)
                    {
                        servicio = ser.Ser_FechaHora;
                    }
                }
            }

            txtHoraServicio.Text = Convert.ToString(servicio);

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            miListaViajes = ((ObjectDataProvider)this.Resources["listaViajes"]).Data as ObservableCollection<Pasaje>;
            vista = CollectionViewSource.GetDefaultView(miListaViajes) as CollectionView;
            cv = (CollectionViewSource)this.Resources["ColectionViajes"];
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

        private void CollectionViewSource_Filter(object sender, FilterEventArgs e)
        {
            //int pasajes = 0;
            //decimal monto = 0;

            if (cmbEmpresa != null)
            {
               //Filtra solo por Empresa
                if (cmbEmpresa.SelectedIndex != -1 && cmbAutobus.SelectedIndex == -1 && dpFechaServicio.SelectedDate == null)
                {
                    int empresa = (int)cmbEmpresa.SelectedValue;
                    Pasaje oPasaje = e.Item as Pasaje;

                    if(oPasaje != null)
                    {
                        if (oPasaje.Emp_Codigo.Equals(empresa))
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

            if (cmbAutobus!=null)
            {
                 //Solo por Autobus
                if (cmbAutobus.SelectedIndex != -1 && cmbEmpresa.SelectedIndex == -1 && dpFechaServicio.SelectedDate == null )
                {
                    Pasaje oPasaje = e.Item as Pasaje;
                    int autobus = (int)cmbAutobus.SelectedValue;
                    if (oPasaje != null)
                    {
                        if (oPasaje.Aut_Codigo.Equals(autobus))
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

            if (dpFechaServicio!=null)
            {
                 //Solo por fecha
            if (dpFechaServicio.SelectedDate != null && cmbAutobus.SelectedIndex == -1 && cmbEmpresa.SelectedIndex == -1) 
            {
                Pasaje oPasaje = e.Item as Pasaje;
                DateTime dtFiltro = new DateTime(dpFechaServicio.SelectedDate.Value.Year, dpFechaServicio.SelectedDate.Value.Month, dpFechaServicio.SelectedDate.Value.Day, 0, 0, 0);
                if (oPasaje != null) {
                     DateTime fecha = new DateTime(oPasaje.Ser_FechaHora.Year, oPasaje.Ser_FechaHora.Month, oPasaje.Ser_FechaHora.Day, 0, 0, 0);
                    if (dtFiltro == fecha )
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
            //filtrar entre fechas
            if (dpFechaInicio != null && dpFechaFin != null)
            {
                if(dpFechaInicio.SelectedDate !=null && dpFechaFin.SelectedDate != null){
                    Pasaje oPasaje = e.Item as Pasaje;
                    DateTime dtInicio = new DateTime(dpFechaInicio.SelectedDate.Value.Year, dpFechaInicio.SelectedDate.Value.Month, dpFechaInicio.SelectedDate.Value.Day, 0,0,0);
                    DateTime dtFinal = new DateTime(dpFechaFin.SelectedDate.Value.Year, dpFechaFin.SelectedDate.Value.Month, dpFechaFin.SelectedDate.Value.Day,0,0,0);
                    if (oPasaje != null) {
                        DateTime fecha = new DateTime(oPasaje.Pas_FechaHora.Year, oPasaje.Pas_FechaHora.Month, oPasaje.Pas_FechaHora.Day, 0,0,0);
                        if (dtInicio <= fecha && dtFinal >= fecha)
                        {
                            e.Accepted = true;
                            monto += oPasaje.Pas_Precio;
                            pasajes++;
                            psj.Add(oPasaje);
                        }
                        else 
                        {
                            e.Accepted = false;
                        }
                    }
                }
                txtCantPasaje.Text = Convert.ToString(pasajes);
                txtMontoTotal.Text = Convert.ToString(monto);
                cargarHoraServicio(psj);
            }

            //solo por cliente
            if(txtDNI!=null)
            {
                if (txtDNI.Text != string.Empty && dpFechaServicio.SelectedDate == null && cmbAutobus.SelectedIndex == -1 && cmbEmpresa.SelectedIndex == -1)
                {
                    Pasaje oPasaje = e.Item as Pasaje;
                    int dni = Convert.ToInt32(txtDNI.Text);
                    if (oPasaje != null)
                    {
                        if (oPasaje.Cli_DNI.Equals(dni))
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
        }

        private void btnFiltrar_Click(object sender, RoutedEventArgs e)
        {
            pasajes = 0;
            monto = 0;
            psj = new List<Pasaje>();
            if (cv != null)
            {
                cv.Filter -= new FilterEventHandler(CollectionViewSource_Filter);
                cv.Filter += new FilterEventHandler(CollectionViewSource_Filter);
            }
            else
            {
                MessageBox.Show("No se encontraron datos.", "¡Información!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            
            cmbEmpresa.SelectedIndex = -1;
            cmbAutobus.SelectedIndex = -1;
            dpFechaInicio.Text = null;
            dpFechaFin.Text = null;
            dpFechaServicio.Text = null;
            txtDNI.Text = null;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();

            if (printDialog.ShowDialog() == true)
            {
               printDialog.PrintDocument(((IDocumentPaginatorSource)DocPrueba).DocumentPaginator, "Impresión Documento Dinámico");
            }
        }

        private void btnVistaPrevia_Click(object sender, RoutedEventArgs e)
        {
            grdViaje.Visibility = Visibility.Hidden;
            grdVistaPrevia.Visibility = Visibility.Visible;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Pasaje oPasaje = (Pasaje)lstViajes.SelectedItem;
            DateTime fechaActual = DateTime.Now;

            if (oPasaje != null)
            {
                if (fechaActual < oPasaje.Ser_FechaHora)
                {
                    MessageBoxResult respuesta = MessageBox.Show("¿Desea cancelar el pasaje?", "Cancelar Pasaje.", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (respuesta == MessageBoxResult.Yes)
                    {
                        TrabajarPasajes.eliminarPasaje(oPasaje.Pas_Codigo);
                        miListaViajes.Remove(oPasaje);
                        MessageBox.Show("El pasaje ha sido cancelado.", "¡Información!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("No es posible cancelar el pasaje.", "¡Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro.", "¡Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }            
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            cv.Filter += new FilterEventHandler(CollectionViewSource_Filter);
        }

        public void btnVolverFiltro(object sender, RoutedEventArgs e)
        {
            grdVistaPrevia.Visibility = Visibility.Collapsed;
            grdViaje.Visibility = Visibility.Visible;
        }
    }
}
