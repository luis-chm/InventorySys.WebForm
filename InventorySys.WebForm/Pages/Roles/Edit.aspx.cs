using BussinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityLayer;

namespace InventorySys.WebForm.Pages.Roles
{
    public partial class Edit : System.Web.UI.Page
    {
        private static int RoleID = 0;
        RolesBL rolesBL = new RolesBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarRol();
            }
        }
        private void Alertas(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('{mensaje}');", true);
        }
        protected void CargarRol()
        {
            if (Request.QueryString["RoleID"] != null)
            {
                RoleID = Convert.ToInt32(Request.QueryString["RoleID"].ToString());

                if (RoleID != 0)
                {
                    EntityLayer.Roles roles = rolesBL.ObtenerRol(RoleID);
                    txtRoleName.Text = roles.RoleName;

                    if (roles.RoleActive)
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
                    Response.Redirect("~/Pages/Roles/Roles.aspx");
                }
            }
        }
        protected void btnAactualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRoleName.Text) ||
                string.IsNullOrWhiteSpace(RadioButtonList1.SelectedValue))
            {
                Alertas("Por favor, complete todos los campos.");
                return;
            }
            try
            {
                EntityLayer.Roles roles = new EntityLayer.Roles()
                {
                    RoleID = RoleID,
                    RoleName = txtRoleName.Text,
                    RoleActive = Convert.ToBoolean(Convert.ToInt32(RadioButtonList1.SelectedValue))
                };
                if (RoleID != 0)
                {
                    int resultado = rolesBL.EditarRol(roles);

                    if (resultado > 0)
                    {
                        string url = VirtualPathUtility.ToAbsolute("~/Pages/Roles/Roles.aspx");
                        string script = $"alert('Rol actualizado con éxito'); window.location.href='{url}';";
                        ClientScript.RegisterStartupScript(this.GetType(), "AlertRedirect", script, true);
                    }
                    else
                    {
                        Alertas("Error al actualizar rol");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}