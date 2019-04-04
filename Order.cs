using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModifyXmlEShop
{
    class Order
    {
        public long IdOrder { get; set; }
        public long IdClient { get; set; }
        public long IdProduct { get; set; }
        public string DeliveryAddress { get; set; }
        public DateTime Registration { get; set; }
        public DateTime DateOfDelivery { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"IdOrder = {IdOrder}\r\n" +
                $"IdClient = {IdClient}\r\n" +
                $"IdProduct = {IdProduct}\r\n" +
                $"DeliveryAddress = {DeliveryAddress}\r\n" +
                $"Registration = {Registration.ToShortDateString()}\r\n" +
                $"DateOfDelivery = {DateOfDelivery.ToShortDateString()}\r\n" +
                $"Price = {Price}\r\n";
        }
    }
}
