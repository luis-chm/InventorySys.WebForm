using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityLayer;
using BussinessLayer;
using InventorySys.WebForm.Views.Users;
using System.Data;
using Microsoft.AspNet.FriendlyUrls;
using System.Web.Security;

namespace InventorySys.WebForm.Pages.Users
{
    public partial class Create : System.Web.UI.Page
    {
        private static int UserID = 0;
        RolesBL rolesBL = new RolesBL();
        UsersBL usersBL = new UsersBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarRoles();
            }
        }
        private void Alertas(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('{mensaje}');", true);
        }
        protected void CargarRoles()
        {
            List<EntityLayer.Roles> lista = rolesBL.ListRolesActivos();

            ddlRoles.DataTextField = "RoleName";
            ddlRoles.DataValueField = "RoleID";

            ddlRoles.DataSource = lista;
            ddlRoles.DataBind();
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text) ||
                string.IsNullOrWhiteSpace(txtUserEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(ddlRoles.SelectedValue) ||
                string.IsNullOrWhiteSpace(RadioButtonList1.SelectedValue))
            {
                Alertas("Por favor, complete todos los campos.");
                return;
            }

            try
            {
                EntityLayer.Users users = new EntityLayer.Users()
                {
                    UserID = UserID,
                    UserName = txtUserName.Text,
                    UserEmail = txtUserEmail.Text,
                    UserEncryptedPassword = txtPassword.Text,
                    UserActive = Convert.ToBoolean(Convert.ToInt32(RadioButtonList1.SelectedValue)),
                    Role = new EntityLayer.Roles() { RoleID = Convert.ToInt32(ddlRoles.SelectedValue) },
                };
                if (UserID == 0)
                {
                    int resultado = usersBL.CrearUser(users);

                    if (resultado > 0)
                    {
                        string url = VirtualPathUtility.ToAbsolute("~/Pages/Users/Users.aspx");
                        string script = $"alert('Usuario ingresado con éxito'); window.location.href='{url}';";
                        ClientScript.RegisterStartupScript(this.GetType(), "AlertRedirect", script, true);
                    }
                    else
                    {
                        Alertas("Error al ingresar usuario");
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}