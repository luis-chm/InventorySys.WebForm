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

                throw ex;
            }
        }
        public Materials ObtenerMaterial(int CollectionID)
        {
            try
            {
                return materialsDAL.ObtenerMaterial(CollectionID);
            }
            catch (Exception ex)
            {

                throw ex;
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

                throw ex;
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

                throw ex;
            }
        }
        public int EliminarMaterials(int CollectionID)
        {
            try
            {

                return materialsDAL.EliminarMaterials(CollectionID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
