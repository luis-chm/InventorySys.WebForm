using DataLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class MaterialsBL
    {
        readonly MaterialsDAL materialsDAL = new MaterialsDAL();
        public List<Materials> ListMaterials()
        {
            try
            {
                return materialsDAL.ListMaterials();
            }
            catch (Exception ex)
            {

                throw new Exception("Error", ex);
            }
        }
        public Materials ObtenerMaterial(int MaterialID)
        {
            try
            {
                return materialsDAL.ObtenerMaterial(MaterialID);
            }
            catch (Exception ex)
            {

                throw new Exception("Error", ex);
            }
        }
        public int CrearMaterials(Materials Materials)
        {
            try
            {
                return materialsDAL.CrearMaterials(Materials);
            }
            catch (Exception ex)
            {

                throw new Exception("Error", ex);
            }
        }
        public int EditarMaterials(Materials Materials)
        {
            try
            {
                return materialsDAL.EditarMaterials(Materials);
            }
            catch (Exception ex)
            {

                throw new Exception("Error", ex);
            }
        }
        public int EliminarMaterials(int MaterialID)
        {
            try
            {

                return materialsDAL.EliminarMaterials(MaterialID);
            }
            catch (Exception ex)
            {

                throw new Exception("Error", ex);
            }
        }
    }
}
