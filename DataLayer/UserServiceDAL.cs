using EntityLayer;
using System;
using System.Data.SqlClient;
using System.Data;


namespace DataLayer
{
    public class UserServiceDAL
    {
        public Users ValidarLogin(string userEmail, string userEncryptedPassword)
        {
            Users userEntidad = null;
            using (SqlConnection conn = new SqlConnection(DBConn.conn))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("ValidarUsuario", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@UserEmail", userEmail));
                        cmd.Parameters.Add(new SqlParameter("@UserEncryptedPassword", userEncryptedPassword));

                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            if (rdr.Read())
                            {
                                userEntidad = new Users
                                {
                                    UserID = rdr.GetInt32(rdr.GetOrdinal("UserID")),
                                    UserName = rdr.GetString(rdr.GetOrdinal("UserName")),
                                    UserEmail = rdr.GetString(rdr.GetOrdinal("UserEmail")),
                                    UserEncryptedPassword = rdr.GetString(rdr.GetOrdinal("UserEncryptedPassword")),
                                    UserActive = rdr.GetBoolean(rdr.GetOrdinal("UserActive")),
                                    Role = new Roles
                                    {
                                        RoleID = rdr.GetInt32(rdr.GetOrdinal("RoleID")),
                                        RoleName = rdr.GetString(rdr.GetOrdinal("RoleName")),
                                    }
                                };
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al validar el login", ex);
                }
            }
            return userEntidad;
        }
    }
}
