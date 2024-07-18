using DataLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class SitesBL
    {
        readonly SitesDAL sitesDAL= new SitesDAL();
        public List<Sites> ListSites()
        {
            try
            {
                return sitesDAL.ListSites();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public Sites ObtenerSites(int SiteID)
        {
            try
            {
                return sitesDAL.ObtenerSites(SiteID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int CrearSites(Sites sites)
        {
            try
            {
                return sitesDAL.CrearSites(sites);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int EditarSites(Sites sites)
        {
            try
            {
                return sitesDAL.EditarSites(sites);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int EliminarSites(int SiteID)
        {
            try
            {

                return sitesDAL.EliminarSites(SiteID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
