using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityLayer;
using BussinessLayer;
using InventorySys.WebForm.Views.Users;

namespace InventorySys.WebForm.Pages.Roles
{
    public partial class Create : System.Web.UI.Page
    {
        private static int RoleID = 0;
        RolesBL rolesBL = new RolesBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string estadoRol = RadioButtonList1.SelectedValue;
            }
        }
        private void Alertas(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('{mensaje}');", true);
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
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
                if (RoleID == 0)
                {
                    int resultado = rolesBL.CrearRol(roles);

                    if (resultado > 0)
                    {
                        string url = VirtualPathUtility.ToAbsolute("~/Pages/Roles/Roles.aspx");
                        string script = $"alert('Rol ingresado con éxito'); window.location.href='{url}';";
                        ClientScript.RegisterStartupScript(this.GetType(), "AlertRedirect", script, true);
                    }
                    else
                    {
                        Alertas("Error al ingresar rol");
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