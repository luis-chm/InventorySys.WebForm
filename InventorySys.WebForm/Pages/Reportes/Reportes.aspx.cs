using DataLayer;
using System;
using ClosedXML.Excel;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace InventorySys.WebForm.Pages.Reportes
{
    public partial class Reportes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            ReporteMaterialsDate(txtFechaInicio.Text, txtFechaFin.Text);
        }

        protected void ReporteMaterialsDate(string fechainicio, string fechafin)
        {
            DataTable table_Materials = new DataTable();

            using (SqlConnection conn = new SqlConnection(DBConn.conn))
            {
                conn.Open();
                using (var adapter = new SqlDataAdapter())
                {
                    adapter.SelectCommand = new SqlCommand("ReporteMaterialPorFechas", conn);
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.AddWithValue("@fechaInicio", DateTime.Parse(fechainicio).ToString("dd/MM/yyyy"));
                    adapter.SelectCommand.Parameters.AddWithValue("@fechaFin", DateTime.Parse(fechafin).ToString("dd/MM/yyyy"));

                    adapter.Fill(table_Materials);
                }
            }

            using (var libro = new XLWorkbook())
            {
                table_Materials.TableName = "Materiales";
                var hoja = libro.Worksheets.Add(table_Materials);
                hoja.ColumnsUsed().AdjustToContents();

                using (var memoria = new MemoryStream())
                {
                    libro.SaveAs(memoria);
                    memoria.Position = 0;

                    var nombreExcel = $"Reporte Materiales {DateTime.Now:yyyyMMddHHmmss}.xlsx";
                    Response.Clear();
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", $"attachment; filename={nombreExcel}");
                    Response.BinaryWrite(memoria.ToArray());
                    Response.End();
                }
            }
        }
    }
}