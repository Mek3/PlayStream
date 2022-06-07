using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    public partial class InicioAdmin : Window
    {
        PlayStreamEntities db;
        public InicioAdmin()
        {
            InitializeComponent();
            db = new PlayStreamEntities();
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource peliculaViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("peliculaViewSource")));
            // Cargar datos estableciendo la propiedad CollectionViewSource.Source:
            // peliculaViewSource.Source = [origen de datos genérico]

            db.Peliculas.Load();
            peliculaViewSource.Source = db.Peliculas.Local;
        }

        private void peliculaDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
