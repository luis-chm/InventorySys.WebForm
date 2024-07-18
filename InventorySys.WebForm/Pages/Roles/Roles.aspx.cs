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
    public partial class Roles : System.Web.UI.Page
    {
        readonly RolesBL rolesBL = new RolesBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            MostrarRoles();
        }
        private void MostrarRoles()
        {
            List<EntityLayer.Roles> lista = rolesBL.ListRoles();

            gvRoles.DataSource = lista;
            gvRoles.DataBind();

            gvRoles.UseAccessibleHeader = true;
            gvRoles.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvRoles.FooterRow.TableSection = TableRowSection.TableFooter;
        }
        private void Alertas(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('{mensaje}');", true);
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Roles/Create.aspx?RoleID=0");
        }
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string RoleID = btn.CommandArgument;
            Response.Redirect($"~/Pages/Roles/Edit.aspx?RoleID={RoleID}");
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string RoleID = btn.CommandArgument;
            int respuesta = rolesBL.EliminarRol(Convert.ToInt32(RoleID));
            if (respuesta > 0)
                Alertas("El rol ha sido eliminado con éxito");
            MostrarRoles();
        }
    }
}