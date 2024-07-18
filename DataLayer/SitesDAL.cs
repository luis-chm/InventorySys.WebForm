using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Policy;

namespace DataLayer
{
    public class SitesDAL
    {
        public List<Sites> ListSites()
        {
            List<Sites> lista = new List<Sites>();

            using (SqlConnection conn = new SqlConnection(DBConn.conn))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_Sites", conn);
                cmd.CommandType = CommandType.Text;
                try
                {
                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Sites
                            {
                                SiteID = Convert.ToInt32(dr["SiteID"]),
                                SiteName = dr["SiteName"].ToString(),
                                SiteLocation = dr["SiteLocation"].ToString(),
                                SiteActive = Convert.ToBoolean(dr["SiteActive"])
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                return lista;
            }
        }
        public Sites ObtenerSites(int SiteID)
        {
            Sites sites = new Sites();

            using (SqlConnection conn = new SqlConnection(DBConn.conn))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("GestionarSites", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@accion", "consultar");
                    cmd.Parameters.AddWithValue("@SiteID", SiteID);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            sites.SiteID = Convert.ToInt32(dr["SiteID"]);
                            sites.SiteName = dr["SiteName"].ToString();
                            sites.SiteLocation = dr["SiteLocation"].ToString();
                            sites.SiteActive = Convert.ToBoolean(dr["SiteActive"]);
                        }
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
                return sites;
            }
        }
        public int CrearSites(Sites sites)
        {
            int result = 0;

            using (SqlConnection conn = new SqlConnection(DBConn.conn))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("GestionarSites", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@accion", "agregar");
                    cmd.Parameters.AddWithValue("@SiteName", sites.SiteName);
                    cmd.Parameters.AddWithValue("@SiteLocation", sites.SiteLocation);
                    cmd.Parameters.AddWithValue("@SiteActive", sites.SiteActive);

                    int RowsAffected = cmd.ExecuteNonQuery();
                    if (RowsAffected > 0) result = 1;
                }
                catch (Exception ex)
                {

                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
                return result;
            }
        }
        public int EditarSites(Sites sites)
        {
            int result = 0;

            using (SqlConnection conn = new SqlConnection(DBConn.conn))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("GestionarSites", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@accion", "modificar");
                    cmd.Parameters.AddWithValue("@SiteID", sites.SiteID);
                    cmd.Parameters.AddWithValue("@SiteName", sites.SiteName);
                    cmd.Parameters.AddWithValue("@SiteLocation", sites.SiteLocation);
                    cmd.Parameters.AddWithValue("@SiteActive", sites.SiteActive);

                    int RowsAffected = cmd.ExecuteNonQuery();
                    if (RowsAffected > 0) result = 1;
                }
                catch (Exception ex)
                {

                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
                return result;
            }
        }
        public int EliminarSites(int SiteID)
        {
            int result = 0;

            using (SqlConnection conn = new SqlConnection(DBConn.conn))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("GestionarSites", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@accion", "borrar");
                    cmd.Parameters.AddWithValue("@SiteID", SiteID);

                    int RowsAffected = cmd.ExecuteNonQuery();
                    if (RowsAffected > 0) result = 1;
                }
                catch (Exception ex)
                {

                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
                return result;
            }
        }
    }
}
