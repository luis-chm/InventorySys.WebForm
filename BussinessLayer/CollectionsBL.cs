using DataLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class CollectionsBL
    {
        readonly CollectionsDAL collectionsDAL = new CollectionsDAL();
        public List<Collections> ListCollections()
        {
            try
            {
                return collectionsDAL.ListCollections();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public Collections ObtenerCollection(int CollectionID)
        {
            try
            {
                return collectionsDAL.ObtenerCollection(CollectionID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int CrearCollections(Collections collections)
        {
            try
            {
                return collectionsDAL.CrearCollections(collections);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int EditarCollections(Collections collections)
        {
            try
            {
                return collectionsDAL.EditarCollections(collections);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int EliminarCollections(int CollectionID)
        {
            try
            {

                return collectionsDAL.EliminarCollections(CollectionID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
