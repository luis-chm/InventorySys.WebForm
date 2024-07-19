using Microsoft.SqlServer.Server;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Materials
    {
        public int MaterialID { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialDescription { get; set; }
        public int? CollectionID { get; set; }
        public int? FinitureID { get; set; }
        public int? FormatID { get; set; }
        public int? SiteID { get; set; }
        public string MaterialIMG { get; set; }
        public DateTime MaterialReceivedDate { get; set; }
        public double MaterialStock { get; set; }
        public int? UserID { get; set; }

        public Collections Collection { get; set; }
        public Finitures Finiture { get; set; }
        public Formats Format { get; set; }
        public Sites Site { get; set; }
        public Users User { get; set; }
    }
}
