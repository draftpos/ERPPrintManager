using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPPrintManager
{

        public class KitchenData
    {
        public string doc_type { get; set; }
        public string CompanyName { get; set; }
        public string Waiter { get; set; }
        public string Cashier { get; set; }
        public string OrderDate { get; set; }
        public string OrderType { get; set; }
        public string OrderNo { get; set; }
        public List<KitchenItem> itemlist { get; set; }
        public string TotalItem { get; set; }
    }

    public class KitchenItem
    {
        public string ItemName { get; set; }
        public int Qty { get; set; }
        public string Remark { get; set; }
    }

}
