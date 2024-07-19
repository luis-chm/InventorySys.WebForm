using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityLayer;
using BussinessLayer;
using InventorySys.WebForm.Views.Users;
using InventorySys.WebForm.Pages.Finitures;

namespace InventorySys.WebForm.Pages.Collections
{
    public partial class Collections : System.Web.UI.Page
    {
        readonly CollectionsBL collectionsBL = new CollectionsBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            MostrarCollections();
        }
        private void MostrarCollections()
        {

            List<EntityLayer.Collections> lista = collectionsBL.ListCollections();
            gvCollections.DataSource = lista;
            gvCollections.DataBind();

            gvCollections.UseAccessibleHeader = true;
            if (gvCollections.HeaderRow != null)
            {
                gvCollections.HeaderRow.TableSection = TableRowSection.TableHeader;
            }

            if (gvCollections.FooterRow != null)
            {
                gvCollections.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        private void Alertas(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('{mensaje}');", true);
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Collections/Create.aspx?CollectionID=0");
        }
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string CollectionID = btn.CommandArgument;
            Response.Redirect($"~/Pages/Collections/Edit.aspx?CollectionID={CollectionID}");
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string CollectionID = btn.CommandArgument;
            int respuesta = collectionsBL.EliminarCollections(Convert.ToInt32(CollectionID));
            if (respuesta > 0)
                Alertas("La Coleccion ha sido eliminada con éxito");
            MostrarCollections();
        }
    }
}