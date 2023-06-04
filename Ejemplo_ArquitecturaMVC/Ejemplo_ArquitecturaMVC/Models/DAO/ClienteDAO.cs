using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejemplo_ArquitecturaMVC.Models.DTO;

namespace Ejemplo_ArquitecturaMVC.Models.DAO
{
    internal class ClienteDAO : DbContext
    {
        // Para ejecutar y obtener datos
        SqlDataReader leerFilas;
        SqlCommand sqlCmd;

        // METODOS CRUD
        public void Insertar(Cliente cliente)
        {

        }

        public void Editar() { }
        public void Eliminar() { }

        public List<Cliente> Listar(string filtro = "")
        {
            List<Cliente> clientes = new();

            sqlCmd = new();
            sqlCmd.Connection = connection;
            sqlCmd.CommandText = "usp_FiltrarClientesPorIdONombre";
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@patronFiltro", filtro);

            connection.Open();

            leerFilas = sqlCmd.ExecuteReader();
            while (leerFilas.Read())
                clientes.Add(new Cliente
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
            connection.Close();

            return clientes;
        }
    }
}
