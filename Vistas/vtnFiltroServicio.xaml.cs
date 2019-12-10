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
    /// Lógica de interacción para vtnFiltroServicio.xaml
    /// </summary>
    public partial class vtnFiltroServicio : Window
    {        
        public vtnFiltroServicio()
        {
            InitializeComponent();
            lstServicios.DataContext = TrabajarServicios.traerServicios();

            cmbOrigen.SelectedIndex = -1;

            cmbDestino.SelectedIndex = -1;
        }

        ObservableCollection<Servicio> miListaServicios;
        CollectionView vista;
        CollectionViewSource cv;


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            miListaServicios = ((ObjectDataProvider)this.Resources["listaServicios"]).Data as ObservableCollection<Servicio>;
            vista = CollectionViewSource.GetDefaultView(miListaServicios) as CollectionView;
            cv = (CollectionViewSource)this.Resources["ColeccionServicios"];
        }

        private void CollectionViewSource_Filter(object sender, FilterEventArgs e)
        {
            //Filtra por origen y destino
            if (cmbOrigen.SelectedIndex != -1 && cmbDestino.SelectedIndex != -1 && dpFecha.SelectedDate == null)
            {
                int origen = (int)cmbOrigen.SelectedValue;
                int desttino = (int)cmbDestino.SelectedValue;

                Servicio oServicio = e.Item as Servicio;

                if (oServicio != null)
                {
                    if (oServicio.Ter_Codigo_Origen.Equals(origen) && oServicio.Ter_Codigo_Destino.Equals(desttino))
                    {
                        e.Accepted = true;
                    }
                    else
                    {
                       
                        e.Accepted = false;
                    }
                }
                else
                {
                  MessageBox.Show("No se encontraron datos.", "¡Información!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }

            //Filtra solo por origen
            if (cmbOrigen.SelectedIndex != -1 && cmbDestino.SelectedIndex == -1 && dpFecha.SelectedDate == null)
            {
                int origen = (int)cmbOrigen.SelectedValue;

                Servicio oServicio = e.Item as Servicio;

                if (oServicio != null)
                {
                    if (oServicio.Ter_Codigo_Origen.Equals(origen))
                    {
                        e.Accepted = true;
                    }
                    else
                    {
                        e.Accepted = false;
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron datos.", "¡Información!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }

            //Filtra solo por destino
            if (cmbDestino.SelectedIndex != -1 && cmbOrigen.SelectedIndex == -1 && dpFecha.SelectedDate == null)
            {
                int desttino = (int)cmbDestino.SelectedValue;

                Servicio oServicio = e.Item as Servicio;

                if (oServicio != null)
                {
                    if (oServicio.Ter_Codigo_Destino.Equals(desttino))
                    {
                        e.Accepted = true;
                    }
                    else
                    {
                        e.Accepted = false;
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron datos.", "¡Información!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }

            //Filtra solo por Fecha
            if (dpFecha.SelectedDate != null && cmbDestino.SelectedIndex == -1 && cmbOrigen.SelectedIndex == -1)
            {
                DateTime dtFiltro = new DateTime(dpFecha.SelectedDate.Value.Year, dpFecha.SelectedDate.Value.Month, dpFecha.SelectedDate.Value.Day, 0, 0, 0);

                Servicio oServicio = e.Item as Servicio;

                if (oServicio != null)
                {
                    DateTime fecha = new DateTime(oServicio.Ser_FechaHora.Year, oServicio.Ser_FechaHora.Month, oServicio.Ser_FechaHora.Day, 0, 0, 0);

                    if (dtFiltro == fecha)
                    {
                        e.Accepted = true;
                    }
                    else
                    {
                        e.Accepted = false;
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron datos.", "¡Información!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }

            //Filtra por orige, destino y fecha
            if (cmbOrigen.SelectedIndex != -1 && cmbDestino.SelectedIndex != -1 && dpFecha.SelectedDate != null)
            {
                int origen = (int)cmbOrigen.SelectedValue;
                int desttino = (int)cmbDestino.SelectedValue;
                DateTime dtFiltro = new DateTime(dpFecha.SelectedDate.Value.Year, dpFecha.SelectedDate.Value.Month, dpFecha.SelectedDate.Value.Day, 0, 0, 0);

                Servicio oServicio = e.Item as Servicio;

                if (oServicio != null)
                {
                    DateTime fecha = new DateTime(oServicio.Ser_FechaHora.Year, oServicio.Ser_FechaHora.Month, oServicio.Ser_FechaHora.Day, 0, 0, 0);
                    if (oServicio.Ter_Codigo_Origen.Equals(origen) && oServicio.Ter_Codigo_Destino.Equals(desttino) && dtFiltro == fecha)
                    {
                        e.Accepted = true;
                    }
                    else
                    {
                        e.Accepted = false;
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron datos.", "¡Información!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }

            //Filtra por origen y fecha
            if (cmbOrigen.SelectedIndex != -1 && dpFecha.SelectedDate != null && cmbDestino.SelectedIndex == -1)
            {
                int origen = (int)cmbOrigen.SelectedValue;
                DateTime dtFiltro = new DateTime(dpFecha.SelectedDate.Value.Year, dpFecha.SelectedDate.Value.Month, dpFecha.SelectedDate.Value.Day, 0, 0, 0);

                Servicio oServicio = e.Item as Servicio;

                if (oServicio != null)
                {
                    DateTime fecha = new DateTime(oServicio.Ser_FechaHora.Year, oServicio.Ser_FechaHora.Month, oServicio.Ser_FechaHora.Day, 0, 0, 0);
                    if (oServicio.Ter_Codigo_Origen.Equals(origen) && dtFiltro == fecha)
                    {
                        e.Accepted = true;
                    }
                    else
                    {
                        e.Accepted = false;
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron datos.", "¡Información!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }

            //Filtra por destino y fecha
            if (cmbDestino.SelectedIndex != -1 && dpFecha.SelectedDate != null && cmbOrigen.SelectedIndex == -1)
            {
                int desttino = (int)cmbDestino.SelectedValue;
                DateTime dtFiltro = new DateTime(dpFecha.SelectedDate.Value.Year, dpFecha.SelectedDate.Value.Month, dpFecha.SelectedDate.Value.Day, 0, 0, 0);

                Servicio oServicio = e.Item as Servicio;

                if (oServicio != null)
                {
                    DateTime fecha = new DateTime(oServicio.Ser_FechaHora.Year, oServicio.Ser_FechaHora.Month, oServicio.Ser_FechaHora.Day, 0, 0, 0);
                    if (oServicio.Ter_Codigo_Destino.Equals(desttino) && dtFiltro == fecha)
                    {
                        e.Accepted = true;
                    }
                    else
                    {
                        e.Accepted = false;
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron datos.", "¡Información!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }

        }

        private void btnFiltrar_Click(object sender, RoutedEventArgs e)
        {
            if (cv != null)
            {
                cv.Filter += new FilterEventHandler(CollectionViewSource_Filter);
            }
            else
            {
                MessageBox.Show("No se encontraron datos.", "¡Información!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }


            cmbOrigen.SelectedIndex = -1;
            cmbDestino.SelectedIndex = -1;
            dpFecha.Text = null;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            cv.Filter += new FilterEventHandler(CollectionViewSource_Filter);
        }
        
    }
}
