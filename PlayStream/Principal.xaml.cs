using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PlayStream
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class Principal : Window
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = MessageBox.Show("¿Estás seguro que deseas salir ? ", "Atención",
           
            MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (res == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        

        private void btnIniciarSesionAdmin_Click(object sender, RoutedEventArgs e)
        {
            InicioAdmin inicio = new InicioAdmin();
            inicio.Show();
           
        }

        private void btnIniciarSesionUsuario_Click(object sender, RoutedEventArgs e)
        {
            InicioUsuario inicio = new InicioUsuario();
            inicio.Show();
        }
    }
}
