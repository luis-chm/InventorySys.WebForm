using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using EntityLayer;

namespace BussinessLayer
{
    public class UsersBL
    {
        readonly UsersDAL usersDAL = new UsersDAL();
        public List<Users> ListUsers()
        {
            try
            {
               return usersDAL.ListUsers();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public Users ObtenerUser(int UserID)
        {
            try
            {
                return usersDAL.ObtenerUser(UserID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int CrearUser(Users user)
        {
            try
            {
                return usersDAL.CrearUser(user);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int EditarUser(Users user)
        {
            try
            {
                return usersDAL.EditarUser(user);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int EliminarUser(int UserID)
        {
            try
            {

                return usersDAL.EliminarUser(UserID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
