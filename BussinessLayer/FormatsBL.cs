using DataLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class FormatsBL
    {
        readonly FormatsDAL FormatsDAL = new FormatsDAL();
        public List<Formats> ListFormats()
        {
            try
            {
                return FormatsDAL.ListFormats();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public Formats ObtenerFormat(int FormatID)
        {
            try
            {
                return FormatsDAL.ObtenerFormat(FormatID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int CrearFormats(Formats Formats)
        {
            try
            {
                return FormatsDAL.CrearFormats(Formats);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int EditarFormats(Formats Formats)
        {
            try
            {
                return FormatsDAL.EditarFormats(Formats);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int EliminarFormats(int FormatID)
        {
            try
            {

                return FormatsDAL.EliminarFormats(FormatID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
