using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredApp.DataAccess.Repositories
{
    /// <summary>
    ///     Here is the common methods that use all repositories, like create, edit or list
    ///     a entity object in the data source.
    /// </summary>
    public abstract class MasterRepository : Repository
    {
        protected List<SqlParameter> parameters;

        protected int ExecuteNonQuery(string transactSql)
        {
            /// NOTE:
            ///     When use 'using', this call a dispose method. In this case, a
            ///     SqlConnection object close the connection when the object is disposed, so you
            ///     do not need to call to Close() method, it calls for default before object is disposed.

            // With this, liberate resources about object creations (Dispose when not use)
            using(var connection = GetConnection())
            {
                connection.Open();
                using(var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = transactSql;
                    command.CommandType = CommandType.Text;

                    if(parameters != null)
                        foreach (var parameter in parameters)
                            command.Parameters.Add(parameter);

                    int result = command.ExecuteNonQuery();
                    parameters = null;
                    return result;
                }
            }
        }

        protected DataTable ExecuteReader(string transactSql, CommandType typeCommand = CommandType.Text)
        {
            // With this, liberate resources about object creations (Dispose when not use)
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = transactSql;
                    command.CommandType = typeCommand;

                    if (parameters != null)
                        foreach (var parameter in parameters)
                            command.Parameters.Add(parameter);

                    SqlDataReader reader = command.ExecuteReader();
                    using(var table = new DataTable())
                    {
                        table.Load(reader);
                        reader.Dispose();
                        parameters = null;
                        return table;
                    }
                }
            }
        }
    }
}
