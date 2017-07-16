using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CheckXmlTool.Models
{

    [XmlRoot("CenterOrder")]
    public class CenterOrder
    {
        [XmlElement("Order")]
        public Order Order { get; set; }
    }
    
    public class Order
    {
        [XmlAttribute("AppId")]
        public string AppId { get; set; }

        [XmlElement("OrderId")]
        public string OrderId { get; set; }
        [XmlElement("PayType")]
        public int? PayType { get; set; }
        [XmlElement("ShipType")]
        public int? ShipType { get; set; }
        [XmlElement("Option")]
        public string Option { get; set; }
        [XmlElement("Articles")]
        public Articles Articles { get; set; }
    }

    public class Articles
    {
        [XmlElement("Article")]
        public List<Article> ArticleList { get; set; }
    }
    public class Article
    {
        public string ProductId { get; set; }
        public decimal? Price { get; set; }
    }
}
