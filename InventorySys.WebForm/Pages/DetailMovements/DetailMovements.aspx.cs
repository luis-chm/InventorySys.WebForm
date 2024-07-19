using BussinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventorySys.WebForm.Pages.DetailMovements
{
    public partial class DetailMovements : System.Web.UI.Page
    {
        readonly DetailMovementsBL DetailMovementsBL = new DetailMovementsBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            MostrarDetailMovements();
        }
        private void MostrarDetailMovements()
        {

            List<EntityLayer.DetailMovements> lista = DetailMovementsBL.ListDetailMovements();
            gvDetailMovements.DataSource = lista;
            gvDetailMovements.DataBind();

            gvDetailMovements.UseAccessibleHeader = true;
            if (gvDetailMovements.HeaderRow != null)
            {
                gvDetailMovements.HeaderRow.TableSection = TableRowSection.TableHeader;
            }

            if (gvDetailMovements.FooterRow != null)
            {
                gvDetailMovements.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        private void Alertas(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('{mensaje}');", true);
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/DetailMovements/Create.aspx?DetailMovID=0");
        }
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string DetailMovID = btn.CommandArgument;
            Response.Redirect($"~/Pages/DetailMovements/Edit.aspx?DetailMovID={DetailMovID}");
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string DetailMovID = btn.CommandArgument;
            int respuesta = DetailMovementsBL.EliminarDetailMovements(Convert.ToInt32(DetailMovID));
            if (respuesta > 0)
                Alertas("El movimiento ha sido eliminado con éxito");
            MostrarDetailMovements();
        }
    }
}