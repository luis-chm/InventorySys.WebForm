using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DataLayer
{
    public class RolesDAL
    {
        public List<Roles> ListExecuteQuery(string sqlQuery)
        {
            List<Roles> lista = new List<Roles>();

            using (SqlConnection conn = new SqlConnection(DBConn.conn))
            {
                SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                cmd.CommandType = CommandType.Text;
                try
                {
                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Roles
                            {
                                RoleID = Convert.ToInt32(dr["RoleID"]),
                                RoleName = dr["RoleName"].ToString(),
                                RoleActive = Convert.ToBoolean(dr["RoleActive"])
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR: " + ex.Message);
                }
                return lista;
            }
        }
        public List<Roles> ListRoles()
        {
            return ListExecuteQuery("SELECT * FROM tbl_Roles");
        }
        public List<Roles> ListRolesActivos()
        {
            return ListExecuteQuery("SELECT * FROM tbl_Roles WHERE RoleActive = 1");
        }
        public Roles ObtenerRol(int RoleID)
        {
            Roles rolesEntidad = new Roles();

            using (SqlConnection conn = new SqlConnection(DBConn.conn))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("GestionarRoles", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@accion", "consultar");
                    cmd.Parameters.AddWithValue("@RoleID", RoleID);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            rolesEntidad.RoleID = Convert.ToInt32(dr["RoleID"]);
                            rolesEntidad.RoleName = dr["RoleName"].ToString();
                            rolesEntidad.RoleActive = Convert.ToBoolean(dr["RoleActive"]);
                        }
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine("ERROR: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
                return rolesEntidad;
            }
        }
        public int CrearRol(Roles roles)
        {
            int result = 0;

            using (SqlConnection conn = new SqlConnection(DBConn.conn))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("GestionarRoles", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@accion", "agregar");
                    cmd.Parameters.AddWithValue("@RoleName", roles.RoleName);
                    cmd.Parameters.AddWithValue("@RoleActive", roles.RoleActive);

                    int RowsAffected = cmd.ExecuteNonQuery();
                    if (RowsAffected > 0) result = 1;
                }
                catch (Exception ex)
                {

                    Console.WriteLine("ERROR: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
                return result;
            }
        }
        public int EditarRol(Roles roles)
        {
            int result = 0;

            using (SqlConnection conn = new SqlConnection(DBConn.conn))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("GestionarRoles", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@accion", "modificar");
                    cmd.Parameters.AddWithValue("@RoleID", roles.RoleID);
                    cmd.Parameters.AddWithValue("@RoleName", roles.RoleName);
                    cmd.Parameters.AddWithValue("@RoleActive", roles.RoleActive);

                    int RowsAffected = cmd.ExecuteNonQuery();
                    if (RowsAffected > 0) result = 1;
                }
                catch (Exception ex)
                {

                    Console.WriteLine("ERROR: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
                return result;
            }
        }
        public int EliminarRol(int RoleID)
        {
            int result = 0;

            using (SqlConnection conn = new SqlConnection(DBConn.conn))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("GestionarRoles", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@accion", "borrar");
                    cmd.Parameters.AddWithValue("@RoleID", RoleID);

                    int RowsAffected = cmd.ExecuteNonQuery();
                    if (RowsAffected > 0) result = 1;
                }
                catch (Exception ex)
                {

                    Console.WriteLine("ERROR: " + ex.Message);
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
