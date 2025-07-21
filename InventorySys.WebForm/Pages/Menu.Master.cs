using DataLayer;
using EntityLayer;
using System;

namespace InventorySys.WebForm
{
    public partial class Menu : System.Web.UI.MasterPage
    {
        Users users = new Users();

        protected void Page_Load(object sender, EventArgs e)
        {
            VerificarSeguridadPagina();

            if (!IsPostBack)
            {
                MostrarInfoUsuario();
            }
        }
        private void VerificarSeguridadPagina()
        {
            string currentPage = Request.Url.AbsolutePath.ToLower();

            //Páginas que NO requieren autenticación
            if (currentPage.Contains("/login/") || currentPage.Contains("/login.aspx") ||
                currentPage.Contains("/default.aspx") || currentPage.Contains("/error.aspx"))
            {
                return; // No verificar en páginas públicas
            }

            // Si NO está logueado, redirigir al login
            if (!SessionHelper.IsUserLoggedIn())
            {
                Response.Redirect("~/Pages/Login/Login.aspx");
                return;
            }
        }
        private void MostrarInfoUsuario()
        {
            if (SessionHelper.IsUserLoggedIn())
            {
                Users userEntidad = SessionHelper.GetCurrentUser();
                if (userEntidad != null)
                {
                    lblUserName.Text = userEntidad.UserEmail;
                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            SessionHelper.ClearUserSession();
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/Pages/Login/Login.aspx");
        }

        // Métodos útiles para las páginas hijas
        public string GetCurrentUserName()
        {
            return SessionHelper.GetCurrentUserName();
        }

        public int GetCurrentUserID()
        {
            return SessionHelper.GetCurrentUserID();
        }

        public string GetCurrentUserRole()
        {
            return SessionHelper.GetCurrentUserRole();
        }
    }
}