using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ModifyXmlEShop
{
    class ManagerXmlEShop
    {
        private string xmlFile;
        private XmlDocument document;
        private XmlElement root;

        public ManagerXmlEShop(string xmlFile)
        {
            document = new XmlDocument();
            document.Load(xmlFile);
            root = (XmlElement)document.SelectSingleNode("eShop");

            this.xmlFile = xmlFile;
        }

        private XmlElement FindOrder(int orderId)
        {
            foreach (XmlNode node in root)
            {
                if (node.NodeType != XmlNodeType.Element) continue;

                if (node.Attributes["IdOrder"]?.Value == orderId.ToString())
                {
                    return (XmlElement)node;
                }
            }

            return null;
        }

        public void RemoveOrderById(int orderId)
        {
            root.RemoveChild(FindOrder(orderId));
        }

        public void AddOrder(Order order)
        {
            XmlElement xOrder = CreateElement(document, root, "order");
            CreateAttribute(document, xOrder, "IdOrder", order.IdOrder.ToString());

            CreateAttribute(document, CreateElement(document, xOrder, "Client"), "IdClient", order.IdClient.ToString());
            CreateAttribute(document, CreateElement(document, xOrder, "Product"), "IdProduct", order.IdProduct.ToString());

            CreateTextNode(document, CreateElement(document, xOrder, "DeliveryAddress"), order.DeliveryAddress);
            CreateTextNode(document, CreateElement(document, xOrder, "Registration"), order.Registration.ToString("yyyy-MM-dd"));
            CreateTextNode(document, CreateElement(document, xOrder, "DateOfDelivery"), order.DateOfDelivery.ToString("yyyy-MM-dd"));
            CreateTextNode(document, CreateElement(document, xOrder, "Price"), order.Price.ToString(CultureInfo.InvariantCulture));
        }

        public void AddOrderAttribute(int orderId, string name, string value)
        {
            XmlElement xOrder = FindOrder(orderId);
            CreateAttribute(document, xOrder, name, value);
        }

        public void RemoveOrderAttribute(int orderId, string name)
        {
            XmlElement xOrder = FindOrder(orderId);
            xOrder.Attributes.RemoveNamedItem(name);
        }

        public void SetOrderAttribute(int orderId, string name, string value)
        {
            XmlElement xOrder = FindOrder(orderId);
            CreateAttribute(document, xOrder, name, value);
        }

        private void SetOrderTextNode(int orderId, string nodeName, string text)
        {
            XmlElement xOrder = FindOrder(orderId);
            XmlElement element = (XmlElement)xOrder.SelectSingleNode(nodeName);

            foreach (XmlNode node in element.ChildNodes)
            {
                if (node.NodeType != XmlNodeType.Text) continue;
                element.RemoveChild(node);
            }

            CreateTextNode(document, element, text);
        }

        public void SetPrice(int orderId, decimal price)
        {
            SetOrderTextNode(orderId, "Price", price.ToString(CultureInfo.InvariantCulture));
        }

        public void SetDeliveryAddress(int orderId, string address)
        {
            SetOrderTextNode(orderId, "DeliveryAddress", address);
        }

        public void SetDateOfDelivery(int orderId, DateTime date)
        {
            SetOrderTextNode(orderId, "DateOfDelivery", date.ToString("yyyy-MM-dd"));
        }

        public void Save()
        {
            document.Save(xmlFile);
        }

        private XmlText CreateTextNode(XmlDocument document, XmlElement element, string text)
        {
            XmlText xText = document.CreateTextNode(text);
            element.AppendChild(xText);
            return xText;
        }

        private XmlAttribute CreateAttribute(XmlDocument document, XmlElement element, string name, string value)
        {
            XmlAttribute attribute = document.CreateAttribute(name);
            attribute.Value = value;
            element.Attributes.Append(attribute);
            return attribute;
        }

        private XmlElement CreateElement(XmlDocument document, XmlNode parent, string name)
        {
            XmlElement element = document.CreateElement(name);
            parent.AppendChild(element);
            return element;
        }

    }
}
