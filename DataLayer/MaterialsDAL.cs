using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using System.Security.Policy;
using System.Collections.ObjectModel;
using System.Collections;

namespace DataLayer
{
    public class MaterialsDAL
    {
        public List<Materials> ListMaterials()
        {
            List<Materials> lista = new List<Materials>();

            using (SqlConnection conn = new SqlConnection(DBConn.conn))
            {
                SqlCommand cmd = new SqlCommand("SELECT m.MaterialID ,m.MaterialCode ,m.MaterialDescription ,m.CollectionID ,c.CollectionName,m.FinitureID,f.FinitureName,m.FormatID,ft.FormatName,m.SiteID,s.SiteName,m.MaterialIMG ,m.MaterialReceivedDate ,m.MaterialStock,m.UserID,u.UserName " +
                    "FROM [dbo].[tbl_Materials] m  INNER JOIN [dbo].[tbl_Collections] c ON c.CollectionID = m.CollectionID  INNER JOIN [dbo].[tbl_Finitures] f  ON f.FinitureID = m.FinitureID INNER JOIN [dbo].[tbl_Formats] ft ON ft.FormatID = m.FormatID  INNER JOIN [dbo].[tbl_Sites] s  ON s.SiteID = m.SiteID INNER JOIN [dbo].[tbl_Users] u ON u.UserID = m.UserID", conn);
                cmd.CommandType = CommandType.Text;
                try
                {
                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Materials
                            {
                                MaterialID = Int32.Parse(dr["MaterialID"].ToString()),
                                MaterialCode = dr["MaterialCode"].ToString(),
                                MaterialDescription = dr["MaterialDescription"].ToString(),
                                CollectionID = Int32.Parse(dr["CollectionID"].ToString()),
                                Collection = new Collections{ CollectionName = dr["CollectionName"].ToString() },
                                User = new Users {UserName = dr["UserName"].ToString() },
                                FinitureID = Int32.Parse(dr["FinitureID"].ToString()),
                                Finiture = new Finitures { FinitureName = dr["FinitureName"].ToString() },
                                FormatID = Int32.Parse(dr["FormatID"].ToString()),
                                Format = new Formats { FormatName = dr["FormatName"].ToString() },
                                SiteID = Int32.Parse(dr["SiteID"].ToString()),
                                Site = new Sites { SiteName = dr["SiteName"].ToString() },
                                MaterialIMG = dr["MaterialIMG"].ToString(),
                                MaterialReceivedDate = DateTime.Parse(dr["MaterialReceivedDate"].ToString()),
                                MaterialStock = Convert.ToDouble(dr["MaterialStock"].ToString()),
                                UserID = Int32.Parse(dr["UserID"].ToString())
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
        public Materials ObtenerMaterial(int MaterialID)
        {
            Materials MaterialEntidad = new Materials();

            using (SqlConnection conn = new SqlConnection(DBConn.conn))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("GestionarMaterials", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@accion", "consultar");
                    cmd.Parameters.AddWithValue("@MaterialID", MaterialID);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            MaterialEntidad.MaterialID = Int32.Parse(dr["MaterialID"].ToString());
                            MaterialEntidad.MaterialCode = dr["MaterialCode"].ToString();
                            MaterialEntidad.MaterialDescription = dr["MaterialDescription"].ToString();
                            MaterialEntidad.CollectionID = Int32.Parse(dr["CollectionID"].ToString());
                            MaterialEntidad.FinitureID = Int32.Parse(dr["FinitureID"].ToString());
                            MaterialEntidad.FormatID = Int32.Parse(dr["FormatID"].ToString());
                            MaterialEntidad.SiteID = Int32.Parse(dr["SiteID"].ToString());
                            MaterialEntidad.MaterialIMG = dr["MaterialIMG"].ToString();
                            MaterialEntidad.MaterialReceivedDate = DateTime.Parse(dr["MaterialReceivedDate"].ToString());
                            MaterialEntidad.MaterialStock = Convert.ToDouble(dr["MaterialStock"].ToString());
                            MaterialEntidad.UserID = Int32.Parse(dr["UserID"].ToString());
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
                return MaterialEntidad;
            }
        }
        public int CrearMaterials(Materials materials)
        {
            int result = 0;

            using (SqlConnection conn = new SqlConnection(DBConn.conn))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("GestionarMaterials", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@accion", "agregar");
                    cmd.Parameters.AddWithValue("@MaterialCode", materials.MaterialCode);
                    cmd.Parameters.AddWithValue("@MaterialDescription", materials.MaterialDescription);
                    cmd.Parameters.AddWithValue("@CollectionID", materials.Collection.CollectionID);
                    cmd.Parameters.AddWithValue("@FinitureID", materials.Finiture.FinitureID);
                    cmd.Parameters.AddWithValue("@FormatID", materials.Format.FormatID);
                    cmd.Parameters.AddWithValue("@SiteID", materials.Site.SiteID);
                    cmd.Parameters.AddWithValue("@MaterialIMG", materials.MaterialIMG);
                    cmd.Parameters.AddWithValue("@MaterialReceivedDate", materials.MaterialReceivedDate);
                    cmd.Parameters.AddWithValue("@MaterialStock", materials.MaterialStock);
                    cmd.Parameters.AddWithValue("@UserID", materials.User.UserID);
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
        public int EditarMaterials(Materials materials)
        {
            int result = 0;

            using (SqlConnection conn = new SqlConnection(DBConn.conn))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("GestionarMaterials", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@accion", "modificar");
                    cmd.Parameters.AddWithValue("@MaterialID", materials.MaterialID);
                    cmd.Parameters.AddWithValue("@MaterialCode", materials.MaterialCode);
                    cmd.Parameters.AddWithValue("@MaterialDescription", materials.MaterialDescription);
                    cmd.Parameters.AddWithValue("@CollectionID", materials.Collection.CollectionID);
                    cmd.Parameters.AddWithValue("@FinitureID", materials.Finiture.FinitureID);
                    cmd.Parameters.AddWithValue("@FormatID", materials.Format.FormatID);
                    cmd.Parameters.AddWithValue("@SiteID", materials.Site.SiteID);
                    cmd.Parameters.AddWithValue("@MaterialIMG", materials.MaterialIMG);
                    cmd.Parameters.AddWithValue("@MaterialReceivedDate", materials.MaterialReceivedDate);
                    cmd.Parameters.AddWithValue("@MaterialStock", materials.MaterialStock);
                    cmd.Parameters.AddWithValue("@UserID", materials.User.UserID);

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
        public int EliminarMaterials(int MaterialID)
        {
            int result = 0;

            using (SqlConnection conn = new SqlConnection(DBConn.conn))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("GestionarMaterials", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@accion", "borrar");
                    cmd.Parameters.AddWithValue("@MaterialID", MaterialID);

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
