using BussinessLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventorySys.WebForm.Pages.Reportes
{
    public partial class ReporteMaterials1 : System.Web.UI.Page
    {
        ReportsBL reportsBL = new ReportsBL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void Alertas(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('{mensaje}');", true);
        }
        protected void btnReporteByDate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFechaInicio.Text) || string.IsNullOrWhiteSpace(txtFechaFin.Text))
            {
                Alertas("Por favor, complete ambos campos de fecha.");
                return;
            }
            MemoryStream memoria = reportsBL.ReporteMaterialsDate(txtFechaInicio.Text, txtFechaFin.Text);

            var nombreExcel = $"Reporte Materiales {DateTime.Now:yyyyMMddHHmmss}.xlsx";
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", $"attachment; filename={nombreExcel}");
            Response.BinaryWrite(memoria.ToArray());
            txtFechaInicio.Text = string.Empty;
            txtFechaFin.Text = string.Empty;
            Response.Flush();
            Response.SuppressContent = true;
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        protected void btnReporteGeneral_Click(object sender, EventArgs e)
        {
            MemoryStream memoria = reportsBL.ReporteMaterialsGeneral();

            var nombreExcel = $"Reporte General Materiales {DateTime.Now:yyyyMMddHHmmss}.xlsx";
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", $"attachment; filename={nombreExcel}");
            Response.BinaryWrite(memoria.ToArray());
            Response.End();
        }
    }
}