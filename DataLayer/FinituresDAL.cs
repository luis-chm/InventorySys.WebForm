using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class FinituresDAL
    {
        public List<Finitures> ListFinitures()
        {
            List<Finitures> lista = new List<Finitures>();

            using (SqlConnection conn = new SqlConnection(DBConn.conn))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_Finitures", conn);
                cmd.CommandType = CommandType.Text;
                try
                {
                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Finitures
                            {
                                FinitureID = Convert.ToInt32(dr["FinitureID"]),
                                FinitureCode = dr["FinitureCode"].ToString(),
                                FinitureName = dr["FinitureName"].ToString(),
                                FinitureActive = Convert.ToBoolean(dr["FinitureActive"])
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: "+ex.Message);
                }
                return lista;
            }
        }
        public Finitures ObtenerFinitures(int FinitureID)
        {
            Finitures finitures = new Finitures();

            using (SqlConnection conn = new SqlConnection(DBConn.conn))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("GestionarFinitures", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@accion", "consultar");
                    cmd.Parameters.AddWithValue("@FinitureID", FinitureID);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            finitures.FinitureID = Convert.ToInt32(dr["FinitureID"]);
                            finitures.FinitureCode = dr["FinitureCode"].ToString();
                            finitures.FinitureName = dr["FinitureName"].ToString();
                            finitures.FinitureActive = Convert.ToBoolean(dr["FinitureActive"]);
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
                return finitures;
            }
        }
        public int CrearFinitures(Finitures finitures)
        {
            int result = 0;

            using (SqlConnection conn = new SqlConnection(DBConn.conn))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("GestionarFinitures", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@accion", "agregar");
                    cmd.Parameters.AddWithValue("@FinitureCode", finitures.FinitureCode);
                    cmd.Parameters.AddWithValue("@FinitureName", finitures.FinitureName);
                    cmd.Parameters.AddWithValue("@FinitureActive", finitures.FinitureActive);

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
        public int EditarFinitures(Finitures finitures)
        {
            int result = 0;

            using (SqlConnection conn = new SqlConnection(DBConn.conn))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("GestionarFinitures", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@accion", "modificar");
                    cmd.Parameters.AddWithValue("@FinitureID", finitures.FinitureID);
                    cmd.Parameters.AddWithValue("@FinitureCode", finitures.FinitureCode);
                    cmd.Parameters.AddWithValue("@FinitureName", finitures.FinitureName);
                    cmd.Parameters.AddWithValue("@FinitureActive", finitures.FinitureActive);

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
        public int EliminarFinitures(int FinitureID)
        {
            int result = 0;

            using (SqlConnection conn = new SqlConnection(DBConn.conn))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("GestionarFinitures", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@accion", "borrar");
                    cmd.Parameters.AddWithValue("@FinitureID", FinitureID);

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
