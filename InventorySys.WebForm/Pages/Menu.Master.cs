using EntityLayer;
using System;

namespace InventorySys.WebForm
{
    public partial class Menu : System.Web.UI.MasterPage
    {
        Users users = new Users();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserLogged"] != null)
                {
                    Users userEntidad = Session["UserLogged"] as Users;
                    if (userEntidad != null)
                    {
                        lblUserName.Text = userEntidad.UserEmail;
                    }
                }
            }
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Remove("UserLogged");
            Response.Redirect("~/Pages/Login/Login");
        }
    }
}