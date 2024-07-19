using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace DataLayer
{
    public class DetailMovementsDAL
    {
        public List<DetailMovements> ListDetailMovements()
        {
            List<DetailMovements> lista = new List<DetailMovements>();

            using (SqlConnection conn = new SqlConnection(DBConn.conn))
            {
                SqlCommand cmd = new SqlCommand("SELECT dm.DetailMovID,dm.MaterialTransactionID,dm.DetInitBalance,dm.DetCantEntry,dm.DetCantExit,dm.DetCurrentBalance,mt.MaterialTransactionDate,mt.MaterialTransactionType ,m.MaterialCode,m.MaterialDescription " +
                    "FROM [dbo].[tbl_DetailMovements] dm  INNER JOIN [dbo].[tbl_MaterialTransactions] mt ON dm.MaterialTransactionID = mt.MaterialTransactionID INNER JOIN [dbo].[tbl_Materials] m  ON mt.MaterialID = m.MaterialID", conn);
                cmd.CommandType = CommandType.Text;
                try
                {
                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new DetailMovements
                            {
                                DetailMovID = Convert.ToInt32(dr["DetailMovID"]),
                                MaterialTransactionID =Convert.ToInt32( dr["MaterialTransactionID"]),
                                MaterialTransaction = new MaterialTransactions 
                                {
                                    MaterialTransactionDate = Convert.ToDateTime(dr["MaterialTransactionDate"]),
                                    MaterialTransactionType = dr["MaterialTransactionType"].ToString(),
                                    Material = new Materials 
                                    { 
                                        MaterialCode = dr["MaterialCode"].ToString(),
                                        MaterialDescription = dr["MaterialDescription"].ToString()
                                    }
                                },
                                DetInitBalance = Convert.ToDouble(dr["DetInitBalance"]),
                                DetCantEntry = Convert.ToDouble(dr["DetCantEntry"]),
                                DetCantExit = Convert.ToDouble(dr["DetCantExit"]),
                                DetCurrentBalance = Convert.ToDouble(dr["DetCurrentBalance"]
                                )
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
        public DetailMovements ObtenerDetailMovement(int DetailMovID)
        {
            DetailMovements DetailMovementEntidad = new DetailMovements();

            using (SqlConnection conn = new SqlConnection(DBConn.conn))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("GestionarDetailMovements", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@accion", "consultar");
                    cmd.Parameters.AddWithValue("@DetailMovID", DetailMovID);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            DetailMovementEntidad.DetailMovID = Convert.ToInt32(dr["DetailMovID"]);
                            DetailMovementEntidad.MaterialTransactionID = Convert.ToInt32(dr["MaterialTransactionID"]);
                            DetailMovementEntidad.DetInitBalance = Convert.ToDouble(dr["DetInitBalance"]);
                            DetailMovementEntidad.DetCantEntry = Convert.ToDouble(dr["DetCantEntry"]);
                            DetailMovementEntidad.DetCantExit = Convert.ToDouble(dr["DetCantExit"]);
                            DetailMovementEntidad.DetCurrentBalance = Convert.ToDouble(dr["DetCurrentBalance"]);
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
                return DetailMovementEntidad;
            }
        }
        public int CrearDetailMovements(DetailMovements DetailMovements)
        {
            int result = 0;

            using (SqlConnection conn = new SqlConnection(DBConn.conn))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("GestionarDetailMovements", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@accion", "agregar");
                    cmd.Parameters.AddWithValue("@MaterialTransactionID", DetailMovements.MaterialTransactionID);
                    cmd.Parameters.AddWithValue("@DetInitBalance", DetailMovements.DetInitBalance);
                    cmd.Parameters.AddWithValue("@DetCantEntry", DetailMovements.DetCantEntry);
                    cmd.Parameters.AddWithValue("@DetCantExit", DetailMovements.DetCantExit);
                    cmd.Parameters.AddWithValue("@DetCurrentBalance", DetailMovements.DetCurrentBalance);
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
        public int EditarDetailMovements(DetailMovements DetailMovements)
        {
            int result = 0;

            using (SqlConnection conn = new SqlConnection(DBConn.conn))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("GestionarDetailMovements", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@accion", "modificar");
                    cmd.Parameters.AddWithValue("@DetailMovID", DetailMovements.DetailMovID);
                    cmd.Parameters.AddWithValue("@MaterialTransactionID", DetailMovements.MaterialTransactionID);
                    cmd.Parameters.AddWithValue("@DetInitBalance", DetailMovements.DetInitBalance);
                    cmd.Parameters.AddWithValue("@DetCantEntry", DetailMovements.DetCantEntry);
                    cmd.Parameters.AddWithValue("@DetCantExit", DetailMovements.DetCantExit);
                    cmd.Parameters.AddWithValue("@DetCurrentBalance", DetailMovements.DetCurrentBalance);

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
        public int EliminarDetailMovements(int DetailMovID)
        {
            int result = 0;

            using (SqlConnection conn = new SqlConnection(DBConn.conn))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("GestionarDetailMovements", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@accion", "borrar");
                    cmd.Parameters.AddWithValue("@DetailMovID", DetailMovID);

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
