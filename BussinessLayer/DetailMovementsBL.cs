using DataLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class DetailMovementsBL
    {
        readonly DetailMovementsDAL DetailMovementsDAL = new DetailMovementsDAL();
        public List<DetailMovements> ListDetailMovements()
        {
            try
            {
                return DetailMovementsDAL.ListDetailMovements();
            }
            catch (Exception ex)
            {

                throw new Exception("Error", ex);
            }
        }
        public DetailMovements ObtenerDetailMovement(int DetailMovementID)
        {
            try
            {
                return DetailMovementsDAL.ObtenerDetailMovement(DetailMovementID);
            }
            catch (Exception ex)
            {

                throw new Exception("Error", ex);
            }
        }
        public int CrearDetailMovements(DetailMovements DetailMovements)
        {
            try
            {
                return DetailMovementsDAL.CrearDetailMovements(DetailMovements);
            }
            catch (Exception ex)
            {

                throw new Exception("Error", ex);
            }
        }
        public int EditarDetailMovements(DetailMovements DetailMovements)
        {
            try
            {
                return DetailMovementsDAL.EditarDetailMovements(DetailMovements);
            }
            catch (Exception ex)
            {

                throw new Exception("Error", ex);
            }
        }
        public int EliminarDetailMovements(int DetailMovementID)
        {
            try
            {

                return DetailMovementsDAL.EliminarDetailMovements(DetailMovementID);
            }
            catch (Exception ex)
            {

                throw new Exception("Error", ex);
            }
        }
    }
}
