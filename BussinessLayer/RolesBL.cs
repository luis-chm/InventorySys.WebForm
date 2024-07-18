using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using EntityLayer;

namespace BussinessLayer
{
    public class RolesBL
    {
        RolesDAL rolesDAL = new RolesDAL();
        public List<Roles> ListRoles()
        {
            try
            {
                return rolesDAL.ListRoles();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<Roles> ListRolesActivos()
        {
            try
            {
                return rolesDAL.ListRolesActivos();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public Roles ObtenerRol(int RoleID)
        {
            try
            {
                return rolesDAL.ObtenerRol(RoleID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int CrearRol(Roles roles)
        {
            try
            {
                return rolesDAL.CrearRol(roles);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int EditarRol(Roles roles)
        {
            try
            {
                return rolesDAL.EditarRol(roles);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int EliminarRol(int RoleID)
        {
            try
            {

                return rolesDAL.EliminarRol(RoleID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
