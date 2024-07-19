using BussinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventorySys.WebForm.Pages.Materials
{
    public partial class Materials : System.Web.UI.Page
    {
        readonly MaterialsBL MaterialsBL = new MaterialsBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            MostrarMaterials();
        }
        private void MostrarMaterials()
        {

            List<EntityLayer.Materials> lista = MaterialsBL.ListMaterials();
            gvMaterials.DataSource = lista;
            gvMaterials.DataBind();

            gvMaterials.UseAccessibleHeader = true;
            if (gvMaterials.HeaderRow != null)
            {
                gvMaterials.HeaderRow.TableSection = TableRowSection.TableHeader;
            }

            if (gvMaterials.FooterRow != null)
            {
                gvMaterials.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        private void Alertas(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('{mensaje}');", true);
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Materials/Create.aspx?MaterialID=0");
        }
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string MaterialID = btn.CommandArgument;
            Response.Redirect($"~/Pages/Materials/Edit.aspx?MaterialID={MaterialID}");
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string MaterialID = btn.CommandArgument;
            int respuesta = MaterialsBL.EliminarMaterials(Convert.ToInt32(MaterialID));
            if (respuesta > 0)
                Alertas("El usuario ha sido eliminado con éxito");
            MostrarMaterials();
        }
    }
}