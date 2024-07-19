using BussinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventorySys.WebForm.Pages.MaterialTransactions
{
    public partial class MaterialTransactions : System.Web.UI.Page
    {
        readonly MaterialTransactionsBL MaterialTransactionsBL = new MaterialTransactionsBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            MostrarMaterialTransactions();
        }
        private void MostrarMaterialTransactions()
        {

            List<EntityLayer.MaterialTransactions> lista = MaterialTransactionsBL.ListMaterialTransactions();
            gvMaterialTransactions.DataSource = lista;
            gvMaterialTransactions.DataBind();

            gvMaterialTransactions.UseAccessibleHeader = true;
            if (gvMaterialTransactions.HeaderRow != null)
            {
                gvMaterialTransactions.HeaderRow.TableSection = TableRowSection.TableHeader;
            }

            if (gvMaterialTransactions.FooterRow != null)
            {
                gvMaterialTransactions.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        private void Alertas(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('{mensaje}');", true);
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/MaterialTransactions/Create.aspx?MaterialTransactionID=0");
        }
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string MaterialTransactionID = btn.CommandArgument;
            Response.Redirect($"~/Pages/MaterialTransactions/Edit.aspx?MaterialTransactionID={MaterialTransactionID}");
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string MaterialTransactionID = btn.CommandArgument;
            int respuesta = MaterialTransactionsBL.EliminarMaterialTransactions(Convert.ToInt32(MaterialTransactionID));
            if (respuesta > 0)
                Alertas("La transaccion se ha sido eliminado con éxito");
            MostrarMaterialTransactions();
        }
    }
}