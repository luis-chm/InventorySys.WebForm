using DataLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class FinituresBL
    {
        readonly FinituresDAL finituresDAL = new FinituresDAL();
        public List<Finitures> ListFinitures()
        {
            try
            {
                return finituresDAL.ListFinitures();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public Finitures ObtenerFinitures(int FinitureID)
        {
            try
            {
                return finituresDAL.ObtenerFinitures(FinitureID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int CrearFinitures(Finitures finitures)
        {
            try
            {
                return finituresDAL.CrearFinitures(finitures);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int EditarFinitures(Finitures finitures)
        {
            try
            {
                return finituresDAL.EditarFinitures(finitures);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int EliminarFinitures(int FinitureID)
        {
            try
            {

                return finituresDAL.EliminarFinitures(FinitureID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
