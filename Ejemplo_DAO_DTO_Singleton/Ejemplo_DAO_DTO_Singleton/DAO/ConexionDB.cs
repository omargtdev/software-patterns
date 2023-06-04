using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Ejemplo_DAO_DTO_Singleton.DAO
{
    // Esta clase sera heredada por todas las clases DAO para establecer en cada uno su
    // respectiva conexion, ya que al crear instancias (objetos) se genera consumo de memoria

    // Hacer la clase abstracta para que no se pueda crear instancias de esta
    abstract class ConexionDB
    {
        protected SqlConnection conexion = new SqlConnection(
            "Server=localhost;Database=Practica_Patrones;TrustServerCertificate=true;Trusted_Connection=true;"
        );
    }
}
