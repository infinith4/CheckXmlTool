using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using CheckXmlTool.Models;
using CheckXmlTool.Common;
using CsvHelper;

namespace CheckXmlTool
{
    class Program
    {
        static void Main(string[] args)
        {
            string orderXmlPath = Properties.Settings.Default.OrderXmlPath;
            string orderXmlDirName = "Order02";  //ディレクトリ名を変更することで対象のOrder.xmlファイルを変更可能
            string orderXmlFileName = "Order.xml";
            string orderXmlFilePath = Path.Combine(orderXmlPath, orderXmlDirName, orderXmlFileName);
            FileStream fs = new FileStream(orderXmlFilePath, FileMode.Open);
            XmlSerializer serializer = new XmlSerializer(typeof(CenterOrder));  //Xml Serialize
            CenterOrder centerOrder = (CenterOrder)serializer.Deserialize(fs);

            string required = "◎";

            Log log = new Log();
            string formatCsvPath = Properties.Settings.Default.FormatCsvPath;
            StreamReader csvreader = new StreamReader(formatCsvPath, Encoding.UTF8);
            using (var csv = new CsvReader(csvreader))
            {
                csv.Configuration.HasHeaderRecord = true;  //Headerあり
                csv.Configuration.RegisterClassMap<FormatModel.FormatModelMap>();
                csv.Configuration.SkipEmptyRecords = false;  //カンマありの空行はカウントされるが、ただの空行はスキップされる
                var records = csv.GetRecords<FormatModel.Format>();
                foreach (var record in records)
                {
                    bool isExist = false;
                    FormatModel.Format formatModel = record;
                    string logFileName = string.Format("{0}_{1}", orderXmlDirName, orderXmlFileName);
                    var tagDict = FormatUtil.SelectFirstTag(formatModel);
                    string tagName = tagDict.First().Value;
                    int maxCommaNum = 5;
                    if (tagDict.First().Value == "CenterOrder")
                    {
                        if (formatModel.Required == required)
                        {
                            if (centerOrder != null)
                                isExist = true;

                            log.Write(logFileName, string.Format("{0},{1}", FormatUtil.GenerateCsvTagsStr(tagDict.First(), maxCommaNum), isExist), false);
                        }
                    }

                    if (tagDict.First().Value == "Order")
                    {
                        if (formatModel.Required == required)
                        {
                            if (centerOrder.Order != null)
                                isExist = true;

                            log.Write(logFileName, string.Format("{0},{1}", FormatUtil.GenerateCsvTagsStr(tagDict.First(), maxCommaNum), isExist));
                        }
                    }
                    if (tagDict.First().Value == "OrderId")
                    {
                        if (formatModel.Required == required)
                        {
                            if (!string.IsNullOrEmpty(centerOrder.Order.OrderId))
                                isExist = true;

                            log.Write(logFileName, string.Format("{0},{1}", FormatUtil.GenerateCsvTagsStr(tagDict.First(), maxCommaNum), isExist));
                        }
                    }

                    if (tagDict.First().Value == "PayType")
                    {
                        if (formatModel.Required == required)
                        {
                            List<int> allPayType = new List<int> { 2, 4, 5, 6 };

                            if (centerOrder.Order.PayType != null && allPayType.Contains((int)centerOrder.Order.PayType))
                                isExist = true;
                            #region 値を変換する
                            int convPayment = FormatUtil.ConvertPayType((int)centerOrder.Order.PayType);
                            #endregion
                            log.Write(logFileName, string.Format("{0},{1}-{2}", FormatUtil.GenerateCsvTagsStr(tagDict.First(), maxCommaNum), isExist, convPayment));
                        }
                    }

                    if (tagDict.First().Value == "ShipType")
                    {
                        if (formatModel.Required == required)
                        {
                            if (centerOrder.Order.ShipType != null)
                                isExist = true;
                            #region 値を変換する

                            #endregion
                            log.Write(logFileName, string.Format("{0},{1}", FormatUtil.GenerateCsvTagsStr(tagDict.First(), maxCommaNum), isExist));
                        }
                    }
                }
            }
        }
    }
}
