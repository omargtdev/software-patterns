using Domain.Models.Abstractions;
using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.DataAccess.Repository
{
    public class ClientRepository : ConnectionSQL, IClientRepository
    {
        public int Add(Client client)
        {
            throw new NotImplementedException();
        }

        public int Edit(Client client)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Client> GetClients(string filter)
        {
            var clientes = new List<Client>();

            var sqlCmd = new SqlCommand();
            sqlCmd.Connection = connection;
            sqlCmd.CommandText = "usp_FiltrarClientesPorIdONombre";
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@patronFiltro", filter);

            connection.Open();

            var leerFilas = sqlCmd.ExecuteReader();
            while (leerFilas.Read())
                clientes.Add(new Client
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

        public int Remove(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
