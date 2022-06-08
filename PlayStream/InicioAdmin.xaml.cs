using Newtonsoft.Json;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using PlayStream.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
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
            drvJSON provs = new drvJSON();
            provs.origen = "Assets\\movies.json";
            // C:\Users\mekmo\OneDrive\Documentos\MasterWeb\Primera parte\DAEE\Práctica final\PlayStream\PlayStream\Assets\
            //C:\Users\mekmo\OneDrive\Documentos\MasterWeb\Primera parte\DAEE\Práctica final\PlayStream\PlayStream\Assets\movies.json
            //  provs.origen = "Assets\\movies.json";
            provs.loadData();
            for (int i = 0; i < provs.getTotal(); i++)
            {
                Label label = new Label()
                {
                    Name = "label_" + (i + 1).ToString(),
                    Width = Double.NaN, //label.Autorize =  true;
                    Height = 26,
                    Content = provs.getDato(i)[provs.getKey(0)] + " - "
                            + provs.getDato(i)[provs.getKey(1)] + " - " 
                            + provs.getDato(i)[provs.getKey(5)] + " - ",

                    Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0x33)),
                    Background = new SolidColorBrush(Colors.White),
                    Margin = new Thickness(50, i * 26, 0, 0)
                };
                pnlDatos.Height += 26;
                pnlDatos.Children.Add(label);
            }
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

        public void Window_Loaded(object sender, RoutedEventArgs e)
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

        private void JSONpeliculas_Click(object sender, RoutedEventArgs e)
        {

            peliculaDataGrid.Visibility = Visibility.Hidden;
            btnNuevo.Visibility = Visibility.Hidden;
            GridJSON.Margin = new Thickness(5, 55, 5, 4);
            btnSalir.Visibility = Visibility.Hidden;
            generarPeliculasJSON();
        }

        public void generarPeliculasJSON() 
        {
            
            List<Pelicula> peliculas = new List<Pelicula>();
            for (int i= 1; i< 150; i++) 
            {
                

                Pelicula nuevaPelicula = new Pelicula();

                nuevaPelicula.titulo = "Titulo de la Pelicula " + i;
                nuevaPelicula.descripcion = "Descripcion de la Pelicula " + i;
                nuevaPelicula.director = "Director de la Pelicula " + i;
                nuevaPelicula.Genero = "Genero de la Pelicula " + i;
                nuevaPelicula.trailer = "Trailer de la Pelicula " + i;
                nuevaPelicula.enlacePelicula = "Enlace de la Pelicula " + i;

                peliculas.Add(nuevaPelicula);

            }

            var Json = JsonConvert.SerializeObject(peliculas);
            string path = "Assets\\movies.json";
            System.IO.File.WriteAllText(path, Json);
             
        }

        private void VaciarBD_Click(object sender, RoutedEventArgs e)
        {
            vaciarBD();
            db = new PlayStreamEntities();
            Window_Loaded(sender, e);
        }


        private void poblarBD_Click(object sender, RoutedEventArgs e)
        {
            PoblarBD(db);

        }
        public void vaciarBD()
        {
            try
            {
                db.Database.ExecuteSqlCommand("TRUNCATE TABLE [Pelicula]");
                db.Peliculas.Load();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al vaciar BD. Causa: " + ex.Message,
                            "Atención!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void PoblarBD(PlayStreamEntities db)
        {
            for (int i = 1; i < 15; i++)
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
                    db.Peliculas.Load();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al añadir una nueva pelicula. Causa: " + ex.Message,
                                "Atención!", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }

        }

        private void btnGenerarPDF_Click(object sender, RoutedEventArgs e)
        {

            drvJSON datos = new drvJSON();
            datos.origen = "Assets\\movies.json";
            datos.loadData();

            PdfDocument document = new PdfDocument();
            document.Info.Title = "Provincias de España";

            // Page Options
            PdfPage pdfPage = document.AddPage();
            pdfPage.Height = 1500;//842
            pdfPage.Width = 590;

            // Get an XGraphics object for drawing
            XGraphics graph = XGraphics.FromPdfPage(pdfPage);

            // Text format
            XStringFormat format = new XStringFormat();
            format.LineAlignment = XLineAlignment.Near;
            format.Alignment = XStringAlignment.Near;
            var tf = new XTextFormatter(graph);

            XFont fontParagraph = new XFont("Arial", 8, XFontStyle.Regular);

            // Row elements
            int el1_width = 15;
            int el2_width = 100;//380;

            // page structure options
            double lineHeight = 20;
            int marginLeft = 100;//20;
            int marginTop = 20;

            int el_height = 30;
            int rect_height = 15;

            int interLine_X_1 = 2;

            int offSetX_1 = el1_width;

            XSolidBrush rect_style1 = new XSolidBrush(XColors.LightGray);
            XSolidBrush rect_style2 = new XSolidBrush(XColors.Black);

            for (int i = 0; i < datos.getTotal(); i++)
            {
                double dist_Y = lineHeight * (i + 1);
                double dist_Y2 = dist_Y - 2;
                string provincia = datos.getDato(i)[datos.getKey(1)];
                string id = datos.getDato(i)[datos.getKey(0)];
                // header della G
                if (i == 0)
                {
                    graph.DrawRectangle(rect_style2, marginLeft, marginTop, el2_width + el1_width + interLine_X_1, rect_height);

                    tf.DrawString("Id", fontParagraph, XBrushes.White,
                                    new XRect(marginLeft, marginTop, el1_width, el_height), format);

                    tf.DrawString("Provincia", fontParagraph, XBrushes.White,
                                    new XRect(marginLeft + offSetX_1 + interLine_X_1, marginTop, el2_width, el_height), format);

                    // stampo il primo elemento insieme all'header
                    graph.DrawRectangle(rect_style1, marginLeft, dist_Y2 + marginTop, el1_width, rect_height);
                    tf.DrawString(id, fontParagraph, XBrushes.Black,
                                    new XRect(marginLeft, dist_Y + marginTop, el1_width, el_height), format);

                    //ELEMENT 2 - BIG 380
                    graph.DrawRectangle(rect_style1, marginLeft + offSetX_1 + interLine_X_1, dist_Y2 + marginTop, el2_width, rect_height);
                    tf.DrawString(
                        provincia,
                        fontParagraph,
                        XBrushes.Black,
                        new XRect(marginLeft + offSetX_1 + interLine_X_1, dist_Y + marginTop, el2_width, el_height),
                        format);
                }
                else
                {

                    //ELEMENT 1 - SMALL 80
                    graph.DrawRectangle(rect_style1, marginLeft, marginTop + dist_Y2, el1_width, rect_height);
                    tf.DrawString(

                        id,
                        fontParagraph,
                        XBrushes.Black,
                        new XRect(marginLeft, marginTop + dist_Y, el1_width, el_height),
                        format);

                    //ELEMENT 2 - BIG 380
                    graph.DrawRectangle(rect_style1, marginLeft + offSetX_1 + interLine_X_1, dist_Y2 + marginTop, el2_width, rect_height);
                    tf.DrawString(
                        provincia,
                        fontParagraph,
                        XBrushes.Black,
                        new XRect(marginLeft + offSetX_1 + interLine_X_1, marginTop + dist_Y, el2_width, el_height),
                        format);

                }

            }

            const string filename = "Assets\\movies.pdf"; //"C:\\Users\\mekmo\\OneDrive\\Documentos\\MasterWeb\\DAEE\\Sesion06\\Provincias.pdf";

            document.Save(filename);
            Process.Start(filename);

        }

    }
}
