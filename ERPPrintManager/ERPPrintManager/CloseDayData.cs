using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPPrintManager
{
    
    public class CloseDayData
    {
        public Message message { get; set; }
    }

    public class Message
    {
        public string status { get; set; }
        public int count { get; set; }
        public List<ZReport> data { get; set; }
    }

    public class ZReport
    {
        public string name { get; set; }
        public string owner { get; set; }
        public string creation { get; set; }
        public string modified { get; set; }
        public string modified_by { get; set; }
        public int docstatus { get; set; }
        public int idx { get; set; }
        public string device_serial_no { get; set; }
        public string fiscal_date { get; set; }
        public string fiscal_day { get; set; }
        public string invoice_type { get; set; }
        public string currency { get; set; }
        public string daily_total { get; set; }
        public string vatable_net_amount { get; set; }
        public string vatable_tax { get; set; }
        public string zero_nonvatable_net { get; set; }
        public string exempt_nonvatable_net { get; set; }
        public string amended_from { get; set; }
        public string doctype { get; set; }
    }
}
