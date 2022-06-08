using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayStream.Models
{
    interface IDataDriver
    {
        int getTotal(); // obtener el total de datos
        int getTotalKeys(); // obtener total de columnas
        string getKey(int indice); // obtener un nombre de campo
        dynamic getDato(int indice); // leer un dato
        bool setDato(int indice, dynamic dato); // escribir
        bool loadData(); // cargar y almacenar datos del fichero
        bool saveData();
        bool hayError(); // gestión de errores
        string getError();
    }
}
