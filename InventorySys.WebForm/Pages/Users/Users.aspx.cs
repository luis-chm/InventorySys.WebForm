using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityLayer;
using BussinessLayer;

namespace InventorySys.WebForm.Views.Users
{
    public partial class Users : System.Web.UI.Page
    {
        readonly UsersBL usersBL = new UsersBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            MostrarUsers();
        }
        private void MostrarUsers()
        {
            
            List<EntityLayer.Users> lista = usersBL.ListUsers();
            gvUsers.DataSource = lista;
            gvUsers.DataBind();

            gvUsers.UseAccessibleHeader = true;
            gvUsers.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvUsers.FooterRow.TableSection= TableRowSection.TableFooter;
        }
        private void Alertas(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('{mensaje}');", true);
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Users/Create.aspx?UserID=0");
        } 
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string UserID = btn.CommandArgument;
            Response.Redirect($"~/Pages/Users/Edit.aspx?UserID={UserID}");
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string UserID = btn.CommandArgument;
            int respuesta = usersBL.EliminarUser(Convert.ToInt32(UserID));
            if (respuesta > 0)
                Alertas("El usuario ha sido eliminado con éxito");
            MostrarUsers();
        }

    }
}