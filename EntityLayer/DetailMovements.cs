using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class DetailMovements
    {
        public int DetailMovID { get; set; }
        public int? MaterialTransactionID { get; set; }
        public MaterialTransactions MaterialTransaction { get; set; }
        public double DetInitBalance { get; set; }
        public double DetCantEntry { get; set; }
        public double DetCantExit { get; set; }
        public double DetCurrentBalance { get; set; }
    }
}
