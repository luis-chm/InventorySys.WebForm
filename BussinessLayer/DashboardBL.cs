using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class DashboardBL
    {
        readonly DashboardDAL dashboardDAL = new DashboardDAL();
        public int ObtenerTotalMateriales()
        {
            try
            {
                return dashboardDAL.ObtenerTotalMateriales();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener total de materiales", ex);
            }
        }
        public decimal ObtenerStockTotal()
        {
            try
            {
                return dashboardDAL.ObtenerStockTotal();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener stock total", ex);
            }
        }
        public int ObtenerTotalTransacciones()
        {
            try
            {
                return dashboardDAL.ObtenerTotalTransacciones();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener total de transacciones", ex);
            }
        }
        public int ObtenerColeccionesActivas()
        {
            try
            {
                return dashboardDAL.ObtenerColeccionesActivas();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener colecciones activas", ex);
            }
        }
        public int ObtenerSitiosActivos()
        {
            try
            {
                return dashboardDAL.ObtenerSitiosActivos();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener sitios activos", ex);
            }
        }
        public int ObtenerFormatosActivos()
        {
            try
            {
                return dashboardDAL.ObtenerFormatosActivos();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener formatos activos", ex);
            }
        }
        public int ObtenerAcabadosActivos()
        {
            try
            {
                return dashboardDAL.ObtenerAcabadosActivos();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener acabados activos", ex);
            }
        }
        public int ObtenerUsuariosRegistrados()
        {
            try
            {
                return dashboardDAL.ObtenerUsuariosRegistrados();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener usuarios registrados", ex);
            }
        }
    }
}
