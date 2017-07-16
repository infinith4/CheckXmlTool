using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using CheckXmlTool.Models;
using CheckXmlTool.Common;

namespace CheckXmlTool
{
    class Program
    {
        static void Main(string[] args)
        {
            string orderXmlPath = Properties.Settings.Default.OrderXmlPath;
            string orderXmlDirName = "Order02";
            string orderXmlFileName = "Order.xml";
            string orderXmlFilePath = Path.Combine(orderXmlPath, orderXmlDirName, orderXmlFileName);
            FileStream fs = new FileStream(orderXmlFilePath, FileMode.Open);
            XmlSerializer serializer = new XmlSerializer(typeof(Orders));  //Xml Serialize
            Orders orders = (Orders)serializer.Deserialize(fs);
            using (var _db = new LearnAppsEntities())
            {
                foreach (var item in orders.Order.Articles.articleList)
                {
                    var mst_product = _db.MST_Product.Single(c => c.ProductId == item.ProductId);
                }
            }

            Log log = new Log();
        }
    }
}
