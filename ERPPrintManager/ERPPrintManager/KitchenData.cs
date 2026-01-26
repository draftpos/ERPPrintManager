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
        public string CashierName { get; set; }
        public string OrderDate { get; set; }
        public string OrderType { get; set; }
        public string InvoiceNo { get; set; }
        public string ReceiptType { get; set; }//
        public List<KitchenItem> itemlist { get; set; }
        public string TotalItem { get; set; }
    }

    public class KitchenItem
    {
        public string ProductName { get; set; }
        public double Qty { get; set; }
        public string Remark { get; set; }
        public bool IsKitchenItem { get; set; } = false;
    }


}
