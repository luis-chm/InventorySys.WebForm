using BussinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventorySys.WebForm.Pages.Sites
{
    public partial class Edit : System.Web.UI.Page
    {
        private static int SiteID = 0;
        SitesBL sitesBL = new SitesBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarSites();
            }
        }
        private void Alertas(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('{mensaje}');", true);
        }
        protected void CargarSites()
        {
            if (Request.QueryString["SiteID"] != null)
            {
                SiteID = Convert.ToInt32(Request.QueryString["SiteID"].ToString());

                if (SiteID != 0)
                {
                    EntityLayer.Sites sites = sitesBL.ObtenerSites(SiteID);
                    txtSiteName.Text = sites.SiteName;
                    txtSiteLocation.Text = sites.SiteLocation;

                    if (sites.SiteActive)
                    {
                        RadioButtonList1.SelectedValue = "1";
                    }
                    else
                    {
                        RadioButtonList1.SelectedValue = "0";
                    }
                }
                else
                {
                    Response.Redirect("~/Pages/Sites/Sites.aspx");
                }
            }
        }
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSiteName.Text) ||
                string.IsNullOrWhiteSpace(txtSiteLocation.Text) ||
                string.IsNullOrWhiteSpace(RadioButtonList1.SelectedValue))
            {
                Alertas("Por favor, complete todos los campos.");
                return;
            }
            try
            {
                EntityLayer.Sites sites = new EntityLayer.Sites()
                {
                    SiteID = SiteID,
                    SiteName = txtSiteName.Text,
                    SiteLocation = txtSiteLocation.Text,
                    SiteActive = Convert.ToBoolean(Convert.ToInt32(RadioButtonList1.SelectedValue))
                };
                if (SiteID != 0)
                {
                    int resultado = sitesBL.EditarSites(sites);

                    if (resultado > 0)
                    {
                        string url = VirtualPathUtility.ToAbsolute("~/Pages/Sites/Sites.aspx");
                        string script = $"alert('Sitio actualizado con éxito'); window.location.href='{url}';";
                        ClientScript.RegisterStartupScript(this.GetType(), "AlertRedirect", script, true);
                    }
                    else
                    {
                        Alertas("Error al actualizar sitio");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}