using Ejemplo_DAO_DTO_Singleton.DTO;
using System.Data;
using System.Data.SqlClient;

namespace Ejemplo_DAO_DTO_Singleton.DAO
{
    class ClienteDAO : ConexionDB
    {

        // Para ejecutar y obtener datos
        SqlDataReader leerFilas;
        SqlCommand sqlCmd = new();

        // METODOS CRUD
        public void Insertar(ClienteDTO cliente)
        {
            
        }

        public void Editar() { }
        public void Eliminar() { }

        public List<ClienteDTO> Listar(string filtro = "")
        {
            List<ClienteDTO> clientes = new();

            sqlCmd.Connection = conexion;
            sqlCmd.CommandText = "usp_FiltrarClientesPorIdONombre";
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@patronFiltro", filtro);

            conexion.Open();

            leerFilas = sqlCmd.ExecuteReader();
            while (leerFilas.Read())
                clientes.Add(new ClienteDTO
                {
                    ID = leerFilas.GetInt32(0),
                    Nombre = leerFilas.GetString(1),
                    Apellido = leerFilas.GetString(2),
                    Direccion = leerFilas.GetString(3),
                    Ciudad = leerFilas.GetString(4),
                    Email = leerFilas.GetString(5),
                    Telefono = leerFilas.GetString(6),
                    Ocupacion = leerFilas.GetString(7),
                });
            leerFilas.Close();
            conexion.Close();

            return clientes;
        }
    }
}
