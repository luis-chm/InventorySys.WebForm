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
    public class MaterialTransactionsDAL
    {
        public List<MaterialTransactions> ListMaterialTransactions()
        {
            List<MaterialTransactions> lista = new List<MaterialTransactions>();

            using (SqlConnection conn = new SqlConnection(DBConn.conn))
            {
                SqlCommand cmd = new SqlCommand("GestionarMaterialTransactions", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@accion", "listar");
                try
                {
                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new MaterialTransactions
                            {
                                MaterialTransactionID = Convert.ToInt32(dr["MaterialTransactionID"]),
                                MaterialTransactionType = dr["MaterialTransactionType"].ToString(),
                                MaterialTransactionQuantity =Double.Parse(dr["MaterialTransactionQuantity"].ToString()),
                                MaterialTransactionDate = DateTime.Parse(dr["MaterialTransactionDate"].ToString()),
                                UserID = Convert.ToInt32(dr["UserID"]),
                                User = new Users { UserName = dr["UserName"].ToString() },
                                MaterialID = Convert.ToInt32(dr["MaterialID"]),
                                Material = new Materials { MaterialDescription = dr["MaterialDescription"].ToString(),MaterialCode= dr["MaterialCode"].ToString() },
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
        public MaterialTransactions ObtenerMaterialTransaction(int MaterialTransactionID)
        {
            MaterialTransactions CollectionEntidad = new MaterialTransactions();

            using (SqlConnection conn = new SqlConnection(DBConn.conn))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("GestionarMaterialTransactions", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@accion", "consultar");
                    cmd.Parameters.AddWithValue("@MaterialTransactionID", MaterialTransactionID);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            CollectionEntidad.MaterialTransactionID = Convert.ToInt32(dr["MaterialTransactionID"]);
                            CollectionEntidad.MaterialTransactionType = dr["MaterialTransactionType"].ToString();
                            CollectionEntidad.MaterialTransactionQuantity =Convert.ToDouble(dr["MaterialTransactionQuantity"]);
                            CollectionEntidad.MaterialTransactionDate = Convert.ToDateTime(dr["MaterialTransactionDate"]);
                            CollectionEntidad.UserID = Convert.ToInt32(dr["UserID"]);
                            CollectionEntidad.MaterialID = Convert.ToInt32(dr["MaterialID"]);
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
        public int CrearMaterialTransactions(MaterialTransactions materialTransactions)
        {
            int result = 0;

            using (SqlConnection conn = new SqlConnection(DBConn.conn))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("GestionarMaterialTransactions", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@accion", "agregar");
                    cmd.Parameters.AddWithValue("@MaterialTransactionType", materialTransactions.MaterialTransactionType);
                    cmd.Parameters.AddWithValue("@MaterialTransactionQuantity", materialTransactions.MaterialTransactionQuantity);
                    cmd.Parameters.AddWithValue("@MaterialTransactionDate", materialTransactions.MaterialTransactionDate);
                    cmd.Parameters.AddWithValue("@UserID", materialTransactions.User.UserID);
                    cmd.Parameters.AddWithValue("@MaterialID", materialTransactions.Material.MaterialID);
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
        public int EditarMaterialTransactions(MaterialTransactions materialTransactions)
        {
            int result = 0;

            using (SqlConnection conn = new SqlConnection(DBConn.conn))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("GestionarMaterialTransactions", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@accion", "modificar");
                    cmd.Parameters.AddWithValue("@MaterialTransactionID", materialTransactions.MaterialTransactionID);
                    cmd.Parameters.AddWithValue("@MaterialTransactionType", materialTransactions.MaterialTransactionType);
                    cmd.Parameters.AddWithValue("@MaterialTransactionQuantity", materialTransactions.MaterialTransactionQuantity);
                    cmd.Parameters.AddWithValue("@MaterialTransactionDate", materialTransactions.MaterialTransactionDate);
                    cmd.Parameters.AddWithValue("@UserID", materialTransactions.User.UserID);
                    cmd.Parameters.AddWithValue("@MaterialID", materialTransactions.Material.MaterialID);
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
        public int EliminarMaterialTransactions(int MaterialTransactionID)
        {
            int result = 0;

            using (SqlConnection conn = new SqlConnection(DBConn.conn))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("GestionarMaterialTransactions", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@accion", "borrar");
                    cmd.Parameters.AddWithValue("@MaterialTransactionID", MaterialTransactionID);

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
