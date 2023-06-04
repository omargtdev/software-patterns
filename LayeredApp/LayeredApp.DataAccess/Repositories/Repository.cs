using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace LayeredApp.DataAccess.Repositories
{
    /// <summary>
    ///     Here is all configuration about the data source, in this case, a SQL Server DB, like
    ///     connection string and get object connection.
    /// </summary>
    public abstract class Repository
    {
        private readonly string _connectionString;

        public Repository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["MyCompanyConnection"].ToString();
        }

        protected SqlConnection GetConnection() => new SqlConnection(_connectionString);


    }
}
