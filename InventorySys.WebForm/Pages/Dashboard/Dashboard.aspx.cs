using BussinessLayer;
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
        private readonly DashboardBL dashboardBL = new DashboardBL();
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
            lblTotalMateriales.Text = dashboardBL.ObtenerTotalMateriales().ToString();
            lblStockTotal.Text = dashboardBL.ObtenerStockTotal().ToString("N0");
            lblTotalTransacciones.Text = dashboardBL.ObtenerTotalTransacciones().ToString();
            lblColeccionesActivas.Text = dashboardBL.ObtenerColeccionesActivas().ToString();
            lblSitiosActivos.Text = dashboardBL.ObtenerSitiosActivos().ToString();
            lblFormatosActivos.Text = dashboardBL.ObtenerFormatosActivos().ToString();
            lblAcabadosActivos.Text = dashboardBL.ObtenerAcabadosActivos().ToString();
            lblUsuariosRegistrados.Text = dashboardBL.ObtenerUsuariosRegistrados().ToString();
        }
    }
}