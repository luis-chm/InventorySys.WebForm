using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DataLayer
{
    public static class SessionHelper
    {
        private const string USER_SESSION_KEY = "UserLogged";

        public static Users GetCurrentUser()
        {
            if (HttpContext.Current?.Session[USER_SESSION_KEY] != null)
            {
                return (Users)HttpContext.Current.Session[USER_SESSION_KEY];
            }
            return null;
        }

        public static int GetCurrentUserID()
        {
            var user = GetCurrentUser();
            return user?.UserID ?? 0;
        }

        public static string GetCurrentUserName()
        {
            var user = GetCurrentUser();
            return user?.UserName ?? "Sistema";
        }

        public static bool IsUserLoggedIn()
        {
            return GetCurrentUser() != null;
        }

        public static string GetCurrentUserRole()
        {
            var user = GetCurrentUser();
            return user?.Role?.RoleName;
        }

        public static void ClearUserSession()
        {
            if (HttpContext.Current?.Session != null)
            {
                HttpContext.Current.Session[USER_SESSION_KEY] = null;
            }
        }
    }
}
