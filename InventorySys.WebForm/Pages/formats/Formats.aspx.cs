using BussinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventorySys.WebForm.Pages.Formats
{
    public partial class Formats : System.Web.UI.Page
    {
        readonly FormatsBL FormatsBL = new FormatsBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            MostrarFormats();
        }
        private void MostrarFormats()
        {

            List<EntityLayer.Formats> lista = FormatsBL.ListFormats();
            gvFormats.DataSource = lista;
            gvFormats.DataBind();

            gvFormats.UseAccessibleHeader = true;
            if (gvFormats.HeaderRow != null)
            {
                gvFormats.HeaderRow.TableSection = TableRowSection.TableHeader;
            }

            if (gvFormats.FooterRow != null)
            {
                gvFormats.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        private void Alertas(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('{mensaje}');", true);
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Formats/Create.aspx?FormatID=0");
        }
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string FormatID = btn.CommandArgument;
            Response.Redirect($"~/Pages/Formats/Edit.aspx?FormatID={FormatID}");
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string FormatID = btn.CommandArgument;
            int respuesta = FormatsBL.EliminarFormats(Convert.ToInt32(FormatID));
            if (respuesta > 0)
                Alertas("La Coleccion ha sido eliminada con éxito");
            MostrarFormats();
        }
    }
}