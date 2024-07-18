using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public static class DBConn
    {
        public static string conn = ConfigurationManager.ConnectionStrings["cadenaSQL"].ConnectionString;
        /*public static SqlConnection GetConnection()
        {
            string s = System.Configuration.ConfigurationManager.ConnectionStrings["cadenaSQL"].ConnectionString;
            SqlConnection conexion = new SqlConnection(s);
            conexion.Open();
            return conexion;
        }*/
    }
}
