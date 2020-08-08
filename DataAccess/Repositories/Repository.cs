using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace DataAccess.Repositories
{
     public abstract class Repository
    {
        private readonly string cadenaDeConexion;

        public Repository()
        {
            cadenaDeConexion = ConfigurationManager.ConnectionStrings["presentacion.Properties.Settings.miConexion"].ToString();
        }

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(cadenaDeConexion);
        }

    }
}
