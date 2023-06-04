using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplo_ArquitecturaMVC.Models.DAO
{
    internal abstract class DbContext
    {
        protected SqlConnection connection = new SqlConnection(
            "Server=localhost;Database=Practica_Patrones;TrustServerCertificate=true;Trusted_Connection=true;"
        );
    }
}
