using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TareaClase
{
    static class Conexion
    {
        // Variable para guardar la cadena de conexión
        private static string cadenaConexion;

        // Método estático para establecer una nueva cadena de conexión
        public static void EstablecerCadenaConexion(string host, string baseDatos, string usuario, string contraseña) {
            // Construir cadena de conexión
            cadenaConexion = $"Server={host};Database={baseDatos};User Id={usuario};Password={contraseña};";
        }

        // Método estático para obtener la cadena de conexión actual
        public static string ObtenerCadena {
            get { return cadenaConexion; }
        }
    }
}
