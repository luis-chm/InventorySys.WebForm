using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussinessLayer;
using EntityLayer;

namespace InventorySys.WebForm.Pages.Finitures
{
    public partial class Finitures : System.Web.UI.Page
    {
        readonly FinituresBL finituresBL = new FinituresBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            MostrarFinitures();
        }
        private void MostrarFinitures()
        {

            List<EntityLayer.Finitures> lista = finituresBL.ListFinitures();
            gvFinitures.DataSource = lista;
            gvFinitures.DataBind();

            gvFinitures.UseAccessibleHeader = true;
            gvFinitures.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvFinitures.FooterRow.TableSection = TableRowSection.TableFooter;
        }
        private void Alertas(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('{mensaje}');", true);
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Finitures/Create.aspx?FinitureID=0");
        }
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string FinitureID = btn.CommandArgument;
            Response.Redirect($"~/Pages/Finitures/Edit.aspx?FinitureID={FinitureID}");
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string FinitureID = btn.CommandArgument;
            int respuesta = finituresBL.EliminarFinitures(Convert.ToInt32(FinitureID));
            if (respuesta > 0)
                Alertas("El acabado ha sido eliminado con éxito");
            MostrarFinitures();
        }
    }
}