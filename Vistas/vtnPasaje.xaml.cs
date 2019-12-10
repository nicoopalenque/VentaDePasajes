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
    /// Lógica de interacción para vtnPasaje.xaml
    /// </summary>
    public partial class vtnPasaje : Window
    {
        public static string id;
        public static string dniCli;
        public static string nombre;
        public static string apellido;
        public static string empresa;
        public static string fechaHoraServicio;
        public static string butaca;
        public static string precio;
        public static string origen;
        public static string destino;
        public static DateTime fechaHoraVenta;
        public static string tipo;

        public vtnPasaje()
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
            cv = (CollectionViewSource)this.Resources["ColectionServicios"];
        }

        void cargarAsientos(Servicio servicio)
        {
            int ocupados = 0;
            int libres = 0;
            int disponibles=0;
            ObservableCollection<Pasaje> ListaPasajes = TrabajarPasajes.traerPasajes(servicio.Ser_Codigo);

            foreach (var control in grdAsientos.Children)
            {
                if (control.GetType().ToString() == "System.Windows.Controls.Button")
                {
                    ((Button)control).SetValue(Border.BackgroundProperty, (Brushes.Green));
                    ((Button)control).ToolTip = "Asiento Disponible";
                    disponibles++;
                }
            }

            foreach (Pasaje item in ListaPasajes)
            {
                string nombreBoton = "btn" + item.Pas_Asiento.ToString();
                foreach (var control in grdAsientos.Children)
                {
                    if (control.GetType().ToString() == "System.Windows.Controls.Button")
                    {
                        if (((Button)control).Name == nombreBoton)
                        {
                            ((Button)control).SetValue(Border.BackgroundProperty, (Brushes.Red));
                            ((Button)control).MouseEnter += new MouseEventHandler(btn_MouseEnter);
                            ocupados++;
                        }
                    }
                }
            }
            libres = disponibles - ocupados;

            txtOcupados.Text = Convert.ToString(ocupados);
            txtLibres.Text = Convert.ToString(libres);
        }

        private void btn_MouseEnter(object sender, MouseEventArgs e)
        {
            Button pasaje = (Button)e.OriginalSource;
            int numButaca = Convert.ToInt32((string)pasaje.Content);
            Cliente oCliente = TrabajarClientes.traerPasajeCliente(numButaca);
            if (oCliente != null)
            {
                pasaje.ToolTip = "DNI: " + oCliente.Cli_DNI + "\nApellido: " + oCliente.Cli_Apellido + "\nNombre: " + oCliente.Cli_Nombre;
            }
        }

        private void btnSeleccionar_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)e.OriginalSource;
            string numButaca = (string)btn.Name;

            foreach (var control in grdAsientos.Children)
            {
                if (control.GetType().ToString() == "System.Windows.Controls.Button")
                {
                    if (((Button)control).Name == numButaca && ((Button)control).Background == Brushes.Green)
                    {
                        ((Button)control).Background = Brushes.CornflowerBlue;
                        ((Button)control).ToolTip = "Asiento Seleccionado";
                        butaca = (string)((Button)control).Content;
                    }
                    else if (((Button)control).Name == numButaca && ((Button)control).Background == Brushes.CornflowerBlue)
                    {
                        ((Button)control).Background = Brushes.Green;
                        ((Button)control).ToolTip = "Asiento Disponible";
                    }
                    else if (((Button)control).Name == numButaca && ((Button)control).Background == Brushes.Red)
                    {
                        MessageBox.Show("Asiento No Disponible.", "¡Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }
        
        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            Servicio oServicio = (Servicio)lstServicios.SelectedItem;
            vtnTicket oTicket = new vtnTicket();
            MessageBoxResult respuesta = MessageBox.Show("¿Desea registrar el pasaje?", "Registro de Pasaje.", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (respuesta == MessageBoxResult.Yes)
            {
                fechaHoraVenta = DateTime.Now;
               
                Pasaje oPasaje = new Pasaje();
                oPasaje.Cli_DNI = Convert.ToInt32(txtDNIBuscar.Text);
                oPasaje.Pas_FechaHora = fechaHoraVenta;
                oPasaje.Ser_Codigo = oServicio.Ser_Codigo;
                oPasaje.Pas_Precio = Convert.ToDecimal(txtPrecio.Text);
                oPasaje.Pas_Asiento = Convert.ToInt32(butaca);
                id = Convert.ToString(TrabajarPasajes.agregarPasaje(oPasaje));

                MessageBox.Show("El pasaje ha sido registrado.", "¡Información!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            
            dniCli = txtDNIBuscar.Text;
            nombre = txtNombreed.Text;
            apellido = txtApellidoed.Text;
            empresa = txtEmpresa.Text;
            fechaHoraServicio = txtFecha.Text;
            precio = txtPrecio.Text;
            origen = txtOrigen.Text;
            destino = txtDestino.Text;
            tipo = txtTipo.Text;
            clearFormAdd();
            oTicket.Show();
            grdAsientos.Visibility = Visibility.Collapsed;
            grdEtiqutasAsientos.Visibility = Visibility.Collapsed;
            grdListaPasajes.Visibility = Visibility.Visible;
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

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            Servicio oServicio = (Servicio)lstServicios.SelectedItem;

            if (oServicio!=null)
            {
                empresa = (string)oServicio.Emp_Nombre;
                tipo = (string)oServicio.Aut_TipoServicio;
                origen = (string)oServicio.Ter_Origen;
                destino = (string)oServicio.Ter_Destino;
                fechaHoraServicio = Convert.ToString(oServicio.Ser_FechaHora);

                txtEmpresa.Text = empresa;
                txtTipo.Text = tipo;
                txtOrigen.Text = origen;
                txtDestino.Text = destino;
                txtFecha.Text = fechaHoraServicio;
          
                grdListaPasajes.Visibility = Visibility.Hidden;
                grdGenerarPasaje.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Seleccione un servicio.", "¡Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void btnSiguiente_Click(object sender, RoutedEventArgs e)
        {
            Servicio oServicio = (Servicio)lstServicios.SelectedItem;

            if (oServicio != null)
            {
                Servicio oService = new Servicio();
                Empresa oBusiness = new Empresa();
                Autobus oBus = new Autobus();

                oBusiness.Emp_Nombre = oServicio.Emp_Nombre;
                oService.Aut_Codigo = oServicio.Aut_Codigo;
                oService.Ter_Codigo_Origen = oServicio.Ter_Codigo_Origen;
                oService.Ter_Codigo_Destino = oServicio.Ter_Codigo_Destino;
                oService.Ser_FechaHora = oServicio.Ser_FechaHora;
                oService.Ser_Codigo = oServicio.Ser_Codigo;

                grdGenerarPasaje.Visibility = Visibility.Hidden;
                cargarAsientos(oService);
                grdAsientos.Visibility = Visibility.Visible;
                grdEtiqutasAsientos.Visibility = Visibility.Visible;
            }
        }
              
        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (txtDni.Text != string.Empty && txtNombre.Text != string.Empty && txtApellido.Text != string.Empty && txtTelefono.Text != string.Empty && txtEmail.Text != string.Empty)
            {
                MessageBoxResult respuesta = MessageBox.Show("¿Desea guardar los datos?", "Alta de Cliente.", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (respuesta == MessageBoxResult.Yes)
                {
                    Cliente oCliente = new Cliente();
                    oCliente.Cli_DNI = Convert.ToInt32(txtDni.Text);
                    oCliente.Cli_Nombre = txtNombre.Text;
                    oCliente.Cli_Apellido = txtApellido.Text;
                    oCliente.Cli_Telefono = txtTelefono.Text;
                    oCliente.Cli_Email = txtEmail.Text;

                    TrabajarClientes.agregarCliente(oCliente);

                    MessageBox.Show("El Cliente ha sido registrado.", "¡Información!", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                    txtDni.Text = string.Empty;
                    txtNombre.Text = string.Empty;
                    txtApellido.Text = string.Empty;
                    txtTelefono.Text = string.Empty;
                    txtEmail.Text = string.Empty;
                    grdCliente.Visibility = Visibility.Collapsed;
                    grdGenerarPasaje.Visibility = Visibility.Visible;
                }
            }
            else
            {
                MessageBox.Show("Complete todos los campos necesarios.", "¡Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            grdGenerarPasaje.Visibility = Visibility.Hidden;
            grdListaPasajes.Visibility = Visibility.Visible;
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            grdGenerarPasaje.Visibility = Visibility.Hidden;
            grdCliente.Visibility = Visibility.Visible;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            grdCliente.Visibility = Visibility.Hidden;
            grdGenerarPasaje.Visibility = Visibility.Visible;

        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            grdAsientos.Visibility = Visibility.Hidden;
            grdGenerarPasaje.Visibility = Visibility.Visible;
        }

        private void btnVolverDatos_Click(object sender, RoutedEventArgs e)
        {
            grdAsientos.Visibility = Visibility.Collapsed;
            grdEtiqutasAsientos.Visibility = Visibility.Collapsed;
            grdGenerarPasaje.Visibility = Visibility.Visible;
        }

        void clearFormAdd()
        {
            txtDNIBuscar.Text = string.Empty;
            txtNombreed.Text = string.Empty;
            txtApellidoed.Text = string.Empty;
            txtFecha.Text = string.Empty;
            txtPrecio.Text = string.Empty;
            txtOrigen.Text = string.Empty;
            txtDestino.Text = string.Empty;
        }

        private void CerrarOperador(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void LogoutOP(object sender, RoutedEventArgs e)
        {
            this.Close();
            
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
