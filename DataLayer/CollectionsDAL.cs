using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DataLayer
{
    public class CollectionsDAL
    {
        public List<Collections> ListCollections()
        {
            List<Collections> lista = new List<Collections>();

            using (SqlConnection conn = new SqlConnection(DBConn.conn))
            {
                SqlCommand cmd = new SqlCommand("GestionarCollections", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@accion", "listar");
                try
                {
                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Collections
                            {
                                CollectionID = Convert.ToInt32(dr["CollectionID"]),
                                CollectionName = dr["CollectionName"].ToString(),
                                CollectionEffect = dr["CollectionEffect"].ToString(),
                                CollectionActive = Convert.ToBoolean(dr["CollectionActive"])
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
        public Collections ObtenerCollection(int CollectionID)
        {
            Collections CollectionEntidad = new Collections();

            using (SqlConnection conn = new SqlConnection(DBConn.conn))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("GestionarCollections", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@accion", "consultar");
                    cmd.Parameters.AddWithValue("@CollectionID", CollectionID);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            CollectionEntidad.CollectionID = Convert.ToInt32(dr["CollectionID"]);
                            CollectionEntidad.CollectionName = dr["CollectionName"].ToString();
                            CollectionEntidad.CollectionEffect = dr["CollectionEffect"].ToString();
                            CollectionEntidad.CollectionActive = Convert.ToBoolean(dr["CollectionActive"]);
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
                return CollectionEntidad;
            }
        }
        public int CrearCollections(Collections collections)
        {
            int result = 0;

            using (SqlConnection conn = new SqlConnection(DBConn.conn))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("GestionarCollections", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@accion", "agregar");
                    cmd.Parameters.AddWithValue("@CollectionName", collections.CollectionName);
                    cmd.Parameters.AddWithValue("@CollectionEffect", collections.CollectionEffect);
                    cmd.Parameters.AddWithValue("@CollectionActive", collections.CollectionActive);

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
        public int EditarCollections(Collections collections)
        {
            int result = 0;

            using (SqlConnection conn = new SqlConnection(DBConn.conn))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("GestionarCollections", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@accion", "modificar");
                    cmd.Parameters.AddWithValue("@CollectionID", collections.CollectionID);
                    cmd.Parameters.AddWithValue("@CollectionName", collections.CollectionName);
                    cmd.Parameters.AddWithValue("@CollectionEffect", collections.CollectionEffect);
                    cmd.Parameters.AddWithValue("@CollectionActive", collections.CollectionActive);

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
        public int EliminarCollections(int CollectionID)
        {
            int result = 0;

            using (SqlConnection conn = new SqlConnection(DBConn.conn))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("GestionarCollections", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@accion", "borrar");
                    cmd.Parameters.AddWithValue("@CollectionID", CollectionID);

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
