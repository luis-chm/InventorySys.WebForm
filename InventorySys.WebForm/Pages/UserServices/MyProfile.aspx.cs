using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussinessLayer;
using EntityLayer;
using InventorySys.WebForm.Views.Users;

namespace InventorySys.WebForm.Pages.UserServices
{
    public partial class MyProfile : System.Web.UI.Page
    {
        EntityLayer.Users userEntidad = new EntityLayer.Users();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EntityLayer.Users userEntidad = Session["UserLogged"] as EntityLayer.Users;

                if (userEntidad != null)
                {
                    string encryptedPassword = new string('*', userEntidad.UserEncryptedPassword.Length);
                    txtUserID.Text = userEntidad.UserID.ToString();
                    txtUserName.Text = userEntidad.UserName;
                    txtUserEmail.Text = userEntidad.UserEmail;
                    txtUserEncryptedPassword.Text = encryptedPassword;
                    txtRoleName.Text = userEntidad.Role.RoleName;
                }
                else
                {
                    Response.Redirect("~/Pages/Login.aspx");
                }
            }
        }
    }
}