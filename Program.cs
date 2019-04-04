using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModifyXmlEShop
{
    class Program
    {
        static void Main(string[] args)
        {
            ManagerXmlEShop manager = new ManagerXmlEShop("eshop.xml");

            manager.RemoveOrderById(2);

            // Attributes
            manager.AddOrderAttribute(1, "Status", "InProgress");
            manager.SetOrderAttribute(1, "Status", "Done");

            manager.AddOrderAttribute(1, "SomeUslessAttribute", "SomeData");
            manager.RemoveOrderAttribute(1, "SomeUslessAttribute");



            manager.SetDeliveryAddress(1, "Ukraine,Kharkiv,Gvardeizev Shironinzev 51, 100");
            manager.SetDateOfDelivery(1, DateTime.Parse("2017-01-18", CultureInfo.InvariantCulture));
            manager.SetPrice(1, 999.0m);


            Order order = new Order()
            {
                IdOrder = 3,
                IdClient = 9,
                IdProduct = 99,
                DeliveryAddress = "Ukraine,Kharkiv,Pushkinska 17, 81",
                Registration = DateTime.Parse("2016-09-19", CultureInfo.InvariantCulture),
                DateOfDelivery = DateTime.Parse("2016-10-19", CultureInfo.InvariantCulture),
                Price = 30000.0m
            };

            manager.AddOrder(order);

            manager.Save();

            Console.WriteLine("Done!");
            Console.ReadLine();
        }
    }
}
