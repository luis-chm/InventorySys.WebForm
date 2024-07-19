using DataLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class MaterialTransactionsBL
    {
        readonly MaterialTransactionsDAL materialTransactionsDAL = new MaterialTransactionsDAL();
        public List<MaterialTransactions> ListMaterialTransactions()
        {
            try
            {
                return materialTransactionsDAL.ListMaterialTransactions();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public MaterialTransactions ObtenerMaterialTransaction(int MaterialTransactionID)
        {
            try
            {
                return materialTransactionsDAL.ObtenerMaterialTransaction(MaterialTransactionID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int CrearMaterialTransactions(MaterialTransactions MaterialTransactions)
        {
            try
            {
                return materialTransactionsDAL.CrearMaterialTransactions(MaterialTransactions);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int EditarMaterialTransactions(MaterialTransactions MaterialTransactions)
        {
            try
            {
                return materialTransactionsDAL.EditarMaterialTransactions(MaterialTransactions);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int EliminarMaterialTransactions(int MaterialTransactionID)
        {
            try
            {

                return materialTransactionsDAL.EliminarMaterialTransactions(MaterialTransactionID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
