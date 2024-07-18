using BussinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventorySys.WebForm.Pages.Collections
{
    public partial class Create : System.Web.UI.Page
    {
        private static int CollectionID = 0;
        CollectionsBL collectionsBL = new CollectionsBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string CollectionActive = RadioButtonList1.SelectedValue;
            }
        }
        private void Alertas(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('{mensaje}');", true);
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCollectionName.Text) ||
                string.IsNullOrWhiteSpace(txtCollectionEffect.Text) ||
                string.IsNullOrWhiteSpace(RadioButtonList1.SelectedValue))
            {
                Alertas("Por favor, complete todos los campos.");
                return;
            }
            try
            {
                EntityLayer.Collections collections = new EntityLayer.Collections()
                {
                    CollectionID = CollectionID,
                    CollectionName = txtCollectionName.Text,
                    CollectionEffect = txtCollectionEffect.Text,
                    CollectionActive = Convert.ToBoolean(Convert.ToInt32(RadioButtonList1.SelectedValue))
                };
                if (CollectionID == 0)
                {
                    int resultado = collectionsBL.CrearCollections(collections);

                    if (resultado > 0)
                    {
                        string url = VirtualPathUtility.ToAbsolute("~/Pages/Collections/Collections.aspx");
                        string script = $"alert('Colleccion ingresado con éxito'); window.location.href='{url}';";
                        ClientScript.RegisterStartupScript(this.GetType(), "AlertRedirect", script, true);
                    }
                    else
                    {
                        Alertas("Error al ingresar coleccion");
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("ERROR: " + ex.Message);
            }
        }
    }
}