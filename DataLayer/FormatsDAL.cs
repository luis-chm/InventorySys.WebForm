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
    public class FormatsDAL
    {
        public List<Formats> ListFormats()
        {
            List<Formats> lista = new List<Formats>();

            using (SqlConnection conn = new SqlConnection(DBConn.conn))
            {
                SqlCommand cmd = new SqlCommand("GestionarFormats", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@accion", "listar");
                try
                {
                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Formats
                            {
                                FormatID = Convert.ToInt32(dr["FormatID"]),
                                FormatName = dr["FormatName"].ToString(),
                                FormatSizeCM = float.Parse(dr["FormatSizeCM"].ToString()),
                                FormatActive = Convert.ToBoolean(dr["FormatActive"])
                            }); ;
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
        public Formats ObtenerFormat(int FormatID)
        {
            Formats FormatEntidad = new Formats();

            using (SqlConnection conn = new SqlConnection(DBConn.conn))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("GestionarFormats", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@accion", "consultar");
                    cmd.Parameters.AddWithValue("@FormatID", FormatID);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            FormatEntidad.FormatID = Convert.ToInt32(dr["FormatID"]);
                            FormatEntidad.FormatName = dr["FormatName"].ToString();
                            FormatEntidad.FormatSizeCM = double.Parse(dr["FormatSizeCM"].ToString());
                            FormatEntidad.FormatActive = Convert.ToBoolean(dr["FormatActive"]);
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
                return FormatEntidad;
            }
        }
        public int CrearFormats(Formats formats)
        {
            int result = 0;

            using (SqlConnection conn = new SqlConnection(DBConn.conn))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("GestionarFormats", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@accion", "agregar");
                    cmd.Parameters.AddWithValue("@FormatName", formats.FormatName);
                    cmd.Parameters.AddWithValue("@FormatSizeCM", formats.FormatSizeCM);
                    cmd.Parameters.AddWithValue("@FormatActive", formats.FormatActive);

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
        public int EditarFormats(Formats formats)
        {
            int result = 0;

            using (SqlConnection conn = new SqlConnection(DBConn.conn))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("GestionarFormats", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@accion", "modificar");
                    cmd.Parameters.AddWithValue("@FormatID", formats.FormatID);
                    cmd.Parameters.AddWithValue("@FormatName", formats.FormatName);
                    cmd.Parameters.AddWithValue("@FormatSizeCM", formats.FormatSizeCM);
                    cmd.Parameters.AddWithValue("@FormatActive", formats.FormatActive);

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
        public int EliminarFormats(int FormatID)
        {
            int result = 0;

            using (SqlConnection conn = new SqlConnection(DBConn.conn))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("GestionarFormats", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@accion", "borrar");
                    cmd.Parameters.AddWithValue("@FormatID", FormatID);

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
