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

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para vtnLogin.xaml
    /// </summary>
    public partial class vtnLogin : Window
    {
        
        public vtnLogin()
        {
            InitializeComponent();
        }

        

        private void CerrarLogin(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

    }
}
