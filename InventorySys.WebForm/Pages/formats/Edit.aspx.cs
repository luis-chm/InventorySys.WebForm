using BussinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventorySys.WebForm.Pages.Formats
{
    public partial class Edit : System.Web.UI.Page
    {
        private static int FormatID = 0;
        FormatsBL formatsBL = new FormatsBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarFormat();
            }
        }
        private void Alertas(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('{mensaje}');", true);
        }
        protected void CargarFormat()
        {
            if (Request.QueryString["FormatID"] != null)
            {
                FormatID = Convert.ToInt32(Request.QueryString["FormatID"].ToString());

                if (FormatID != 0)
                {
                    EntityLayer.Formats Formats = formatsBL.ObtenerFormat(FormatID);
                    txtFormatName.Text = Formats.FormatName;
                    txtFormatSizeCM.Text = Formats.FormatSizeCM.ToString();

                    if (Formats.FormatActive)
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
                    Response.Redirect("~/Pages/Formats/Formats.aspx");
                }
            }
        }
        protected void btnActualizar_Click(object sender, EventArgs e)
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
                if (FormatID != 0)
                {
                    int resultado = formatsBL.EditarFormats(Formats);

                    if (resultado > 0)
                    {
                        string url = VirtualPathUtility.ToAbsolute("~/Pages/Formats/Formats.aspx");
                        string script = $"alert('Formato actualizado con éxito'); window.location.href='{url}';";
                        ClientScript.RegisterStartupScript(this.GetType(), "AlertRedirect", script, true);
                    }
                    else
                    {
                        Alertas("Error al actualizar el formato");
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