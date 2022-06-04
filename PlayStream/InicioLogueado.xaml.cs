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
using System.Windows.Shapes;

namespace PlayStream
{
    /// <summary>
    /// Lógica de interacción para InicioLogueado.xaml
    /// </summary>
    public partial class InicioLogueado : Window
    {
        public InicioLogueado()
        {
            InitializeComponent();
        }

        private void btnPeliculas_Click(object sender, RoutedEventArgs e)
        {
            framePrincipal.Navigate(new Peliculas());
        }

        private void btnPagina1_Click(object sender, RoutedEventArgs e)
        {
            framePrincipal.Navigate(new Series());
        }

        private void BtnPerfil_Click(object sender, RoutedEventArgs e)
        {
            framePrincipal.Navigate(new Perfil());
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
    }
}
