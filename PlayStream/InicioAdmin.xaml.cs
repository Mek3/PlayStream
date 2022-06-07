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

        public void btnDetail_Click(object sender, EventArgs e)
        {
            Pelicula p = (Pelicula)peliculaDataGrid.SelectedItem;
            lblTituloDetalle.Content = "Detalle de la pelicula: '" +
            p.titulo + "'";
            peliculaDataGrid.Visibility = Visibility.Hidden;
            gridCajaDetalle.Margin = new Thickness(5, 55, 5, 4);
            gridCajaDetalle.Visibility = Visibility.Visible;
            btnNuevo.Visibility = Visibility.Hidden;
            btnSalir.Visibility = Visibility.Hidden;


        }

        private void btnVolverDetalle_Click(object sender, RoutedEventArgs e)
        {
            gridCajaDetalle.Margin = new Thickness(825, 55, -650, 5);
            gridCajaDetalle.Visibility = Visibility.Hidden;
            peliculaDataGrid.Visibility = Visibility.Visible;
            btnNuevo.Visibility = Visibility.Visible;
            btnSalir.Visibility = Visibility.Visible;

        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            //limpiarFormNuevo();
            peliculaDataGrid.Visibility = Visibility.Hidden;
            btnNuevo.Visibility = Visibility.Hidden;
            gridCajaNuevo.Margin = new Thickness(5, 55, 5, 4);
            gridCajaNuevo.Visibility = Visibility.Visible;
            btnSalir.Visibility = Visibility.Hidden;

           // rellenarComboCategorias(slctCategorias);*
        }

        private void btnVolverNuevo_Click(object sender, RoutedEventArgs e)
        {
            mostrarListado();
        }

        private void mostrarListado()
        {
            gridCajaNuevo.Margin = new Thickness(5, -393, 3.6, 453);
            gridCajaNuevo.Visibility = Visibility.Hidden;
            peliculaDataGrid.Visibility = Visibility.Visible;
            btnNuevo.Visibility = Visibility.Visible;
            btnSalir.Visibility = Visibility.Visible;
        }

        private void btnAddNuevo_Click(object sender, RoutedEventArgs e)
        {
           Pelicula nuevaPelicula = new Pelicula();

            try
            {
                string titulo = tituloTextBox1.Text;
                string descripcion = descripcionTextBox1.Text;
                string director = directorTextBox1.Text;
                string genero = generoTextBox1.Text;
                string trailer = trailerTextBox1.Text;
                string enlacepelicula = enlacePeliculaTextBox1.Text;

                if (!titulo.Equals("") && descripcion != "" && titulo != "" &&
                    !descripcion.Equals("") && descripcion != "" && descripcion != "" &&
                    !director.Equals("") && director != "" && director != "" &&
                    !genero.Equals("") && genero != "" && genero != "")
                {

                    nuevaPelicula.titulo = titulo;
                    nuevaPelicula.descripcion = descripcion;
                    nuevaPelicula.director = director;
                    nuevaPelicula.Genero = genero;
                    nuevaPelicula.trailer = trailer;
                    nuevaPelicula.enlacePelicula = enlacepelicula;

                        db.Peliculas.Add(nuevaPelicula);
                        db.SaveChanges();

                        MessageBox.Show("Pelicula '" + nuevaPelicula.titulo + "' añadida correctamente.",
                        "Atención!", MessageBoxButton.OK, MessageBoxImage.Information);

                        mostrarListado();
                }
                else
                {
                    MessageBox.Show("Ninguno de los campos puede quedar vacío.", "Atención!",
                                    MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al añadir un nuevo producto. Causa: " + ex.Message,
                            "Atención!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Pelicula p = (Pelicula)peliculaDataGrid.SelectedItem;
            MessageBoxResult res =
                MessageBox.Show("¿Está seguro que desea borrar la pelicula '"
                                + p.titulo + "'?", "Atención!",
                                MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (res == MessageBoxResult.Yes)
            {
                try
                {
                    db.Peliculas.Remove(p);
                    db.SaveChanges();

                    MessageBox.Show("Pelicula '" + p.titulo + "' eliminada correctamente.",
                                     "Atención!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar la pelicula '"
                                + p.titulo + "' . Causa: " + ex.Message,
                                     "Atención!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnVolverEdit_Click(object sender, RoutedEventArgs e)
        {
            volverDesdeEdit();
        }
        private void volverDesdeEdit()
        {
            gridCajaEditar.Margin = new Thickness(5, 432, 3.6, -372);
            gridCajaEditar.Visibility = Visibility.Hidden;
            peliculaDataGrid.Visibility = Visibility.Visible;
            btnSalir.Visibility = Visibility.Visible;
            btnNuevo.Visibility = Visibility.Visible;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            peliculaDataGrid.Visibility = Visibility.Hidden;
            btnNuevo.Visibility = Visibility.Hidden;
            gridCajaEditar.Margin = new Thickness(5, 55, 5, 4);
            gridCajaEditar.Visibility = Visibility.Visible;
            btnSalir.Visibility = Visibility.Hidden;

        }

        private void btnEditProd_Click(object sender, RoutedEventArgs e)
        {
            //TODO: verificar que los datos del formulario son correctos
            Pelicula p = (Pelicula)peliculaDataGrid.SelectedItem;
            try
            {
                db.SaveChanges();
                volverDesdeEdit();
                MessageBox.Show("Pelicula '" + p.titulo + "' editada correctamente.",
                        "Atención!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar la pelicula  '" + p.titulo + "' . Causa:" +
                ex.Message, "Atención!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
