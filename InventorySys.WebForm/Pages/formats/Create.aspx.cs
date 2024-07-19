using BussinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventorySys.WebForm.Pages.Formats
{
    public partial class Create : System.Web.UI.Page
    {
        private static int FormatID = 0;
        FormatsBL FormatsBL = new FormatsBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string FormatActive = RadioButtonList1.SelectedValue;
            }
        }
        private void Alertas(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('{mensaje}');", true);
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFormatName.Text) ||
                string.IsNullOrWhiteSpace(txtFormatSizeCM.Text) ||
                string.IsNullOrWhiteSpace(RadioButtonList1.SelectedValue))
            {
                Alertas("Por favor, complete todos los campos.");
                return;
            }
            try
            {
                EntityLayer.Formats Formats = new EntityLayer.Formats()
                {
                    FormatID = FormatID,
                    FormatName = txtFormatName.Text,
                    FormatSizeCM = Convert.ToDouble(txtFormatSizeCM.Text),
                    FormatActive = Convert.ToBoolean(Convert.ToInt32(RadioButtonList1.SelectedValue))
                };
                if (FormatID == 0)
                {
                    int resultado = FormatsBL.CrearFormats(Formats);

                    if (resultado > 0)
                    {
                        string url = VirtualPathUtility.ToAbsolute("~/Pages/Formats/Formats.aspx");
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