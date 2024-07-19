using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussinessLayer;

namespace InventorySys.WebForm.Pages.Sites
{
    public partial class Sites : System.Web.UI.Page
    {
        readonly SitesBL sitesBL = new SitesBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            MostrarSites();
        }
        private void MostrarSites()
        {

            List<EntityLayer.Sites> lista = sitesBL.ListSites();

                gvSites.DataSource = lista;
                gvSites.DataBind();
                gvSites.UseAccessibleHeader = true;
            if (gvSites.HeaderRow != null)
            {
                gvSites.HeaderRow.TableSection = TableRowSection.TableHeader;
            }

            if (gvSites.FooterRow != null)
            {
                gvSites.FooterRow.TableSection = TableRowSection.TableFooter;
            }



        }
        private void Alertas(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('{mensaje}');", true);
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Sites/Create.aspx?SiteID=0");
        }
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string SiteID = btn.CommandArgument;
            Response.Redirect($"~/Pages/Sites/Edit.aspx?SiteID={SiteID}");
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string SiteID = btn.CommandArgument;
            int respuesta = sitesBL.EliminarSites(Convert.ToInt32(SiteID));
            if (respuesta > 0)
                Alertas("El sitio ha sido eliminado con éxito");
            MostrarSites();
        }
    }
}