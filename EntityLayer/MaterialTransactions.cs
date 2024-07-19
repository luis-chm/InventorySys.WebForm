using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class MaterialTransactions
    {
        public int MaterialTransactionID { get; set; }
        public string MaterialTransactionType { get; set; }
        public double MaterialTransactionQuantity { get; set; }
        public DateTime MaterialTransactionDate { get; set; }
        public int? UserID { get; set; }
        public Users User { get; set; }
        public int? MaterialID { get; set; }
        public Materials Material { get; set; }
    }
}
