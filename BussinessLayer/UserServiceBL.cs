using DataLayer;
using EntityLayer;
using System;

namespace BussinessLayer
{
    public class UserServiceBL
    {
        UserServiceDAL userserviceDAL = new UserServiceDAL();
        public Users ValidarLogin(string userEmail, string userEncryptedPassword)
        {
            try
            {
                return userserviceDAL.ValidarLogin(userEmail, userEncryptedPassword);
            }
            catch (Exception ex)
            {

                throw new Exception("Error", ex);
            }
        }
    }
}
