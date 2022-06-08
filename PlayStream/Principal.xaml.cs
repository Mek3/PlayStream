using Newtonsoft.Json;
using PlayStream.Models;
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
        PlayStreamEntities db;

        public Principal()
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

        private void btnPoblarBD_Click(object sender, RoutedEventArgs e)
        {
            PoblarBD();
        }
        public void PoblarBD()
        {

            vaciarBD();

            for (int i = 1; i < 5; i++)
            {
                Pelicula nuevaPelicula = new Pelicula();

                nuevaPelicula.titulo = "Titulo de la Pelicula " + i;
                nuevaPelicula.descripcion = "Descripcion de la Pelicula " + i;
                nuevaPelicula.director = "Director de la Pelicula " + i;
                nuevaPelicula.Genero = "Genero de la Pelicula " + i;
                nuevaPelicula.trailer = "Trailer de la Pelicula " + i;
                nuevaPelicula.enlacePelicula = "Enlace de la Pelicula " + i;
               
                try
                {
                    db.Peliculas.Add(nuevaPelicula);
                    db.SaveChanges();

                } catch (Exception ex)
                {
                    MessageBox.Show("Error al añadir una nueva pelicula. Causa: " + ex.Message,
                                "Atención!", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            
        }

        public void vaciarBD()
        {
            try
            {
                db.Database.ExecuteSqlCommand("TRUNCATE TABLE [Pelicula]");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al vaciar BD. Causa: " + ex.Message,
                            "Atención!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
