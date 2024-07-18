using BussinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventorySys.WebForm.Pages.Finitures
{
    public partial class Create : System.Web.UI.Page
    {
        private static int FinitureID = 0;
        FinituresBL finituresBL = new FinituresBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //string FinituresActive = RadioButtonList1.SelectedValue;
            }
        }
        private void Alertas(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('{mensaje}');", true);
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
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
                if (FinitureID == 0)
                {
                    int resultado = finituresBL.CrearFinitures(finitures);

                    if (resultado > 0)
                    {
                        string url = VirtualPathUtility.ToAbsolute("~/Pages/Finitures/Finitures.aspx");
                        string script = $"alert('Acabado ingresado con éxito'); window.location.href='{url}';";
                        ClientScript.RegisterStartupScript(this.GetType(), "AlertRedirect", script, true);
                    }
                    else
                    {
                        Alertas("Error al ingresar Acabado");
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