using DataLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventorySys.WebForm.Pages.Dashboard
{
    public partial class Dashboard : System.Web.UI.Page
    {
        private MaterialsDAL materialsDAL = new MaterialsDAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatosDashboard();
            }
        }
        private void CargarDatosDashboard()
        {
            try
            {
                lblFechaActual.Text = DateTime.Now.ToString("dddd, dd 'de' MMMM 'de' yyyy", new CultureInfo("es-ES"));
                CargarMetricasPrincipales();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al cargar dashboard: {ex.Message}");
            }
        }
        private void CargarMetricasPrincipales()
        {
            lblTotalMateriales.Text = materialsDAL.ObtenerTotalMateriales().ToString();
            lblStockTotal.Text = materialsDAL.ObtenerStockTotal().ToString("N0");
            lblTotalTransacciones.Text = materialsDAL.ObtenerTotalTransacciones().ToString();
            lblColeccionesActivas.Text = materialsDAL.ObtenerColeccionesActivas().ToString();
            lblSitiosActivos.Text = materialsDAL.ObtenerSitiosActivos().ToString();
            lblFormatosActivos.Text = materialsDAL.ObtenerFormatosActivos().ToString();
            lblAcabadosActivos.Text = materialsDAL.ObtenerAcabadosActivos().ToString();
            lblUsuariosRegistrados.Text = materialsDAL.ObtenerUsuariosRegistrados().ToString();
        }
    }
}