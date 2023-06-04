using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.DataAccess.Repository
{
    public class ConnectionSQL
    {
        protected SqlConnection connection = new SqlConnection(
            "Server=localhost;Database=Practica_Patrones;TrustServerCertificate=true;Trusted_Connection=true;"
        );
    }
}
