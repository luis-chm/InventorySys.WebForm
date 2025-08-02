using BussinessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventorySys.WebForm.Pages.Users
{
    public partial class Edit : System.Web.UI.Page
    {
        private static int UserID = 0;
        RolesBL rolesBL = new RolesBL();
        UsersBL usersBL = new UsersBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarRoles();
                CargarUser();
            }
        }
        private void Alertas(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('{mensaje}');", true);
        }
        protected void CargarRoles(string RoleID = "")
        {
            List<EntityLayer.Roles> lista = rolesBL.ListRolesActivos();

            ddlRoles.DataTextField = "RoleName";
            ddlRoles.DataValueField = "RoleID";

            ddlRoles.DataSource = lista;
            ddlRoles.DataBind();

            if (RoleID != "")
                ddlRoles.SelectedValue = RoleID;
        }
        protected void CargarUser()
        {
            if (Request.QueryString["UserID"] != null)
            {
                UserID = Convert.ToInt32(Request.QueryString["UserID"].ToString());

                if (UserID != 0)
                {
                    EntityLayer.Users users = usersBL.ObtenerUser(UserID);
                    txtUserName.Text = users.UserName;
                    txtUserEmail.Text = users.UserEmail;
                    txtPassword.Text = users.UserEncryptedPassword;
                    CargarRoles(users.RoleID.ToString());
                    ddlRoles.SelectedValue = users.RoleID.ToString();
                    if (users.UserActive)
                    {
                        RadioButtonList1.SelectedValue = "1";
                    }
                    else
                    {
                        RadioButtonList1.SelectedValue = "0";
                    }
                }
                else
                {
                    Response.Redirect("~/Pages/Users/Users.aspx");
                }
            }
        }
        protected void btnAactualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text) ||
                string.IsNullOrWhiteSpace(txtUserEmail.Text) ||
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
                    Role = new EntityLayer.Roles() { RoleID = Convert.ToInt32(ddlRoles.SelectedValue) },
                    UserActive = Convert.ToBoolean(Convert.ToInt32(RadioButtonList1.SelectedValue))
                };
                if (UserID != 0)
                {
                    int resultado = usersBL.EditarUser(users);

                    if (resultado > 0)
                    {
                        string url = VirtualPathUtility.ToAbsolute("~/Pages/Users/Users.aspx");
                        string script = $"alert('Usuario actualizado con éxito'); window.location.href='{url}';";
                        ClientScript.RegisterStartupScript(this.GetType(), "AlertRedirect", script, true);
                    }
                    else
                    {
                        Alertas("Error al actualizar usuario");
                    }
                }
            }

            catch (Exception ex)
            {

                throw new Exception("Error", ex);
            }
        }
    }
}