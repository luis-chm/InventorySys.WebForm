using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace DataLayer
{
    public class UsersDAL
    {
        public List<Users> ListUsers()
        {
            List<Users> lista = new List<Users>();
            using (SqlConnection conn = new SqlConnection(DBConn.conn))
            {
                SqlCommand cmd = new SqlCommand("GestionarUsuarios", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@accion", "listar");
                try
                {
                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Users
                            {
                                UserID = Convert.ToInt32(dr["UserID"]),
                                UserName = dr["UserName"].ToString(),
                                UserEmail = dr["UserEmail"].ToString(),
                                UserEncryptedPassword = dr["UserEncryptedPassword"].ToString(),
                                RoleID = Convert.ToInt32(dr["RoleID"]),
                                UserActive = Convert.ToBoolean(dr["UserActive"]),
                                Role = new Roles { RoleName = dr["RoleName"].ToString() }
                                
                            });
                        }
                    }
                    return lista;
                }

                catch (Exception ex)
                {
                    throw new Exception("Error", ex);
                }
            }
        }
        public Users ObtenerUser(int UserID)
        {
            Users userEntidad = new Users();

            using (SqlConnection conn = new SqlConnection(DBConn.conn))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("GestionarUsuarios", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@accion", "consultar");
                    cmd.Parameters.AddWithValue("@UserID", UserID);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            userEntidad.UserID = Convert.ToInt32(dr["UserID"]);
                            userEntidad.UserName = dr["UserName"].ToString();
                            userEntidad.UserEmail = dr["UserEmail"].ToString();
                            userEntidad.UserEncryptedPassword = dr["UserEncryptedPassword"].ToString();
                            userEntidad.RoleID = Convert.ToInt32(dr["RoleID"]);
                            userEntidad.UserActive = Convert.ToBoolean(dr["UserActive"]);
                        }
                    }
                }
                catch (Exception ex)
                {

                    throw new Exception("Error", ex);
                }
                finally 
                { 
                    conn.Close(); 
                }
                return userEntidad;
            }
        }
        public int CrearUser(Users user)
        {
            int result = 0;

            using (SqlConnection conn = new SqlConnection(DBConn.conn))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("GestionarUsuarios", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@accion", "agregar");
                    cmd.Parameters.AddWithValue("@UserName", user.UserName);
                    cmd.Parameters.AddWithValue("@UserEmail", user.UserEmail);
                    cmd.Parameters.AddWithValue("@UserEncryptedPassword", user.UserEncryptedPassword);
                    cmd.Parameters.AddWithValue("@RoleID", user.Role.RoleID);
                    cmd.Parameters.AddWithValue("@UserActive", user.UserActive);

                    int RowsAffected = cmd.ExecuteNonQuery();
                    if (RowsAffected > 0) result = 1;
                }
                catch (Exception ex)
                {

                    throw new Exception("Error", ex);
                }
                finally
                {
                    conn.Close();
                }
                return result;
            }
        }
        public int EditarUser(Users user)
        {
            int result = 0;

            using (SqlConnection conn = new SqlConnection(DBConn.conn))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("GestionarUsuarios", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@accion", "modificar");
                    cmd.Parameters.AddWithValue("@UserID", user.UserID);
                    cmd.Parameters.AddWithValue("@UserName", user.UserName);
                    cmd.Parameters.AddWithValue("@UserEmail", user.UserEmail);
                    cmd.Parameters.AddWithValue("@UserEncryptedPassword", user.UserEncryptedPassword);
                    cmd.Parameters.AddWithValue("@RoleID", user.Role.RoleID);
                    cmd.Parameters.AddWithValue("@UserActive", user.UserActive);

                    int RowsAffected = cmd.ExecuteNonQuery();
                    if (RowsAffected > 0) result = 1;
                }
                catch (Exception ex)
                {

                    throw new Exception("Error", ex);
                }
                finally
                {
                    conn.Close();
                }
                return result;
            }
        }
        public int EliminarUser(int UserID)
        {
            int result = 0;

            using (SqlConnection conn = new SqlConnection(DBConn.conn))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("GestionarUsuarios", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@accion", "borrar");
                    cmd.Parameters.AddWithValue("@UserID", UserID);

                    int RowsAffected = cmd.ExecuteNonQuery();
                    if (RowsAffected > 0) result = 1;
                }
                catch (Exception ex)
                {

                    throw new Exception("Error", ex);
                }
                finally
                {
                    conn.Close();
                }
                return result;
            }
        }
    }//fin clase DAL
}//fin namesapce