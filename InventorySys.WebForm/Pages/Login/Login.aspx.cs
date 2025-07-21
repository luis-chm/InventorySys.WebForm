using BussinessLayer;
using DataLayer;
using System;
using System.Web.UI;

namespace InventorySys.WebForm.Pages.Login
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SessionHelper.IsUserLoggedIn())
            {
                Response.Redirect("~/Pages/Inicio");
                return;
            }

            if (!Page.IsPostBack)
            {
                alertDiv.Visible = false; // Cambiar de alertLabel a alertDiv
            }
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            UserServiceBL userServiceBL = new UserServiceBL();
            EntityLayer.Users usersEntidad = userServiceBL.ValidarLogin(txtEmail.Text, txtPassword.Text);

            if (usersEntidad != null)
            {
                if (usersEntidad.UserActive)
                {
                    Session["UserLogged"] = usersEntidad;
                    Response.Redirect("~/Pages/Inicio");
                }
                else
                {
                    alertMessage.Text = "Tu cuenta está desactivada. Contacta al administrador.";
                    alertDiv.Visible = true;
                }
            }
            else
            {
                alertMessage.Text = "Credenciales incorrectas. Inténtalo de nuevo.";
                alertDiv.Visible = true;
            }
        }
    }
}