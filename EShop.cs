using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModifyXmlEShop
{
    class EShop
    {
        public string ShopName { get; set; }
        public IDictionary<long, Order> Orders { get; set; }

        public EShop()
        {
            Orders = new Dictionary<long, Order>();
        }

        public EShop(string shopName, IDictionary<long, Order> orders)
        {
            this.ShopName = shopName;
            this.Orders = orders;
        }

        public override string ToString()
        {
            string str = "eShop: shopName = " + ShopName + "\r\nOrders:\r\n\r\n";

            foreach (Order order in Orders.Values)
            {
                str += order.ToString() + "\r\n\r\n";
            }

            return str;
        }

    }
}
