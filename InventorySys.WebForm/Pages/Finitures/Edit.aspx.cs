using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussinessLayer;

namespace InventorySys.WebForm.Pages.Finitures
{
    public partial class Edit : System.Web.UI.Page
    {
        private static int FinitureID = 0;
        FinituresBL finituresBL = new FinituresBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarFinitures();
            }
        }
        private void Alertas(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('{mensaje}');", true);
        }
        protected void CargarFinitures()
        {
            if (Request.QueryString["FinitureID"] != null)
            {
                FinitureID = Convert.ToInt32(Request.QueryString["FinitureID"].ToString());

                if (FinitureID != 0)
                {
                    EntityLayer.Finitures finitures = finituresBL.ObtenerFinitures(FinitureID);
                    txtFinitureCode.Text = finitures.FinitureCode;
                    txtFinitureName.Text = finitures.FinitureName;

                    if (finitures.FinitureActive)
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
                    Response.Redirect("~/Pages/Finitures/Finitures.aspx");
                }
            }
        }
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFinitureCode.Text) ||
                string.IsNullOrWhiteSpace(txtFinitureName.Text) ||
                string.IsNullOrWhiteSpace(RadioButtonList1.SelectedValue))
            {
                Alertas("Por favor, complete todos los campos.");
                return;
            }
            try
            {
                EntityLayer.Finitures finitures = new EntityLayer.Finitures()
                {
                    FinitureID = FinitureID,
                    FinitureCode = txtFinitureCode.Text,
                    FinitureName = txtFinitureName.Text,
                    FinitureActive = Convert.ToBoolean(Convert.ToInt32(RadioButtonList1.SelectedValue))
                };
                if (FinitureID != 0)
                {
                    int resultado = finituresBL.EditarFinitures(finitures);

                    if (resultado > 0)
                    {
                        string url = VirtualPathUtility.ToAbsolute("~/Pages/Finitures/Finitures.aspx");
                        string script = $"alert('Acabado actualizado con éxito'); window.location.href='{url}';";
                        ClientScript.RegisterStartupScript(this.GetType(), "AlertRedirect", script, true);
                    }
                    else
                    {
                        Alertas("Error al actualizar acabado");
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