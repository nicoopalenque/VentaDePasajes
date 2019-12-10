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
using System.Collections.ObjectModel;
using ClasesBase;

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para vtnAsientos.xaml
    /// </summary>
    public partial class vtnAsientos : Window
    {
        public vtnAsientos(Servicio servicio)
        {
            InitializeComponent();


            ObservableCollection<Pasaje> ListaPasajes = TrabajarPasajes.traerPasajes(servicio.Ser_Codigo);

            foreach (var control in grdAsientos.Children)
            {
                if (control.GetType().ToString() == "System.Windows.Controls.Button")
                {
                    ((Button)control).SetValue(Border.BackgroundProperty, (Brushes.Green));
                    ((Button)control).ToolTip = "Asiento Disponible";
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
                        }
                    }
                }
            }
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
