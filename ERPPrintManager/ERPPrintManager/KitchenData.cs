using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPPrintManager
{

    using Newtonsoft.Json;

    public class KitchenData
    {
        public string doc_type { get; set; }
        public string CompanyName { get; set; }
        public string Waiter { get; set; }
        public string CashierName { get; set; }
        public string OrderDate { get; set; }
        public string OrderType { get; set; }
        public string InvoiceNo { get; set; }
        public string ReceiptType { get; set; }
        public string CompanyAddressLine1 { get; set; }
        public string CompanyAddressLine2 { get; set; }
        public List<KitchenItem> itemlist { get; set; }
        public string TotalItem { get; set; }
    }

    public class KitchenItem
    {
        public string ProductName { get; set; }
        public double Qty { get; set; }
        public string Remark { get; set; }

        // These map directly to the custom fields in your JSON
        [JsonProperty("Item-custom_is_order_item_1")]
        public bool IsOrderItem1 { get; set; }

        [JsonProperty("Item-custom_is_order_item_2")]
        public bool IsOrderItem2 { get; set; }

        [JsonProperty("Item-custom_is_order_item_3")]
        public bool IsOrderItem3 { get; set; }

        [JsonProperty("Item-custom_is_order_item_4")]
        public bool IsOrderItem4 { get; set; }

        [JsonProperty("Item-custom_is_order_item_5")]
        public bool IsOrderItem5 { get; set; }

        [JsonProperty("Item-custom_is_order_item_6")]
        public bool IsOrderItem6 { get; set; }

        [JsonProperty("Item-custom_is_order_item_7")]
        public bool IsOrderItem7 { get; set; }

        [JsonProperty("Item-custom_is_order_item_8")]
        public bool IsOrderItem8 { get; set; }

        [JsonProperty("Item-custom_is_order_item_9")]
        public bool IsOrderItem9 { get; set; }

        [JsonProperty("Item-custom_is_order_item_10")]
        public bool IsOrderItem10 { get; set; }

        // Computed property: an item is a kitchen item if it belongs to ANY order station
        // This replaces the old hardcoded/default false value
        [JsonIgnore] // Not in JSON, computed
        public bool IsKitchenItem => IsOrderItem1 || IsOrderItem2 || IsOrderItem3 || IsOrderItem4 || IsOrderItem5 ||
                                     IsOrderItem6 || IsOrderItem7 || IsOrderItem8 || IsOrderItem9 || IsOrderItem10;
    }

}
