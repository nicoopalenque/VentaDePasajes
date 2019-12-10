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
using System.Windows.Markup;

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para vtnTicket.xaml
    /// </summary>
    public partial class vtnTicket : Window
    {
        public vtnTicket()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FixedDocument fd = new FixedDocument();
            PageContent pc = new PageContent();
            FixedPage fp = new FixedPage();
            ((IAddChild)pc).AddChild(fp);
            fd.Pages.Add(pc);
            Canvas cv = new Canvas();
            Canvas cv2 = new Canvas();
            TextBlock tb = new TextBlock();
            TextBlock tb2 = new TextBlock();
            TextBlock tb3 = new TextBlock();
            tb.Text = " \t\tTICKET DE VIAJE\n" +
                      "\t\tEmpresa de transporte: " + vtnPasaje.empresa + ".\n" +
                       "\t\tBalcarce 200\tCUIT: 30-12345678-6\n" +
                       "\tS.S de Jujuy\tIIBB:999\n\n";

            tb2.Text = "______________________________________________________________\n\n" +
                       "Pasaje Número: " + vtnPasaje.id + "\t\tFecha Operacion: " + vtnPasaje.fechaHoraVenta +"\n" +
                       "______________________________________________________________\n\n" +
                       "Fecha y Hora de Partida: " + vtnPasaje.fechaHoraServicio + "\n\n" +
                       "Origen: "+ vtnPasaje.origen + "\n\n" +
                       "Destino: "+ vtnPasaje.destino + "\n\n" +
                       "Tipo de Servicio: "+ vtnPasaje.tipo + "\t\tButaca: " + vtnPasaje.butaca + "\n\n" +
                       "Precio: $" + vtnPasaje.precio +"\n\n" +
                       "Cliente: " + vtnPasaje.nombre + " " + vtnPasaje.apellido + "\n\n" +
                       "______________________________________________________________\n" +
                       "Usuario: " + LoginCU.oUsuario.Usu_ApellidoNombre;
            

            tb.TextAlignment = TextAlignment.Center;
            tb.FontSize = 16;
            tb2.FontSize = 16;
            Canvas.SetLeft(tb, 10);
            Canvas.SetTop(tb, 10);
            Canvas.SetLeft(tb2, 10);
            Canvas.SetTop(tb2, 100);
            cv.Children.Add(tb);
            cv.Children.Add(tb2);
            fp.Children.Add(cv);

            // lo muestra en la ventana
            DocumentViewer dv = new DocumentViewer();
            dv.Document = fd;
            ((IAddChild)this).AddChild(dv);
        }
       
    }
}
