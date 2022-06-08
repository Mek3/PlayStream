using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PlayStream.Models
{
    static class BDJSON
    {

        
        static public void PoblarBD(PlayStreamEntities db)
        {

            vaciarBD(db);

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

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al añadir una nueva pelicula. Causa: " + ex.Message,
                                "Atención!", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }

        }

        static public void vaciarBD(PlayStreamEntities db)
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
