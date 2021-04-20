using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Farfetch.Models
{
    public class DB
    {
        public DB() { }
        public SqlConnection connect()
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "farfetchdbserver.database.windows.net";
                builder.UserID = "henrique";
                builder.Password = "admin1299@";
                builder.InitialCatalog = "Farfetch_db";

                SqlConnection connection = new SqlConnection(builder.ConnectionString);
                return connection;

            }
            catch
            {
                return null;
            }
        }
    }
}
