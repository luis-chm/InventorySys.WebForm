using DataLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class ReportsBL
    {
        ReportsDAL reportsDAL = new ReportsDAL();
        public MemoryStream ReporteMaterialsDate(string fechainicio, string fechafin)
        {
            try
            {
                return reportsDAL.ReporteMaterialsDate(fechainicio, fechafin);
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }
        public MemoryStream ReporteMaterialsGeneral()
        {
            try
            {
                return reportsDAL.ReporteMaterialsGeneral();
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }
        public MemoryStream ReporteMaterialTransactionsByDate(string fechainicio, string fechafin)
        {
            try
            {
                return reportsDAL.ReporteMaterialTransactionsByDate(fechainicio, fechafin);
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }
        public MemoryStream ReporteMaterialTransactionsGeneral()
        {
            try
            {
                return reportsDAL.ReporteMaterialTransactionsGeneral();
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }
    }
}
