using BussinessLayer;
using System;

namespace InventorySys.WebForm.Pages.Login
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            UserServiceBL userServiceBL = new UserServiceBL();
            EntityLayer.Users usersEntidad = userServiceBL.ValidarLogin(txtEmail.Text, txtPassword.Text);

            if (usersEntidad != null)
            {
                Session["UserLogged"] = usersEntidad;
                Response.Redirect("~/Pages/Inicio");
            }
            else
            {
                alertLabel.Text = "Credenciales incorrectas. Inténtalo de nuevo.";
                alertLabel.Visible = true;
            }
        }
        public void alertas(String texto)
        {
            string message = texto;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }
    }
}