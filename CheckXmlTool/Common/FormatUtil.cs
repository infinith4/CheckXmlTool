using CheckXmlTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckXmlTool.Common
{
    public class FormatUtil
    {
        public static Dictionary<int, string> SelectFirstTag(FormatModel.Format formatModel)
        {
            Dictionary<int, string> tagDict = new Dictionary<int, string>();

            if (!string.IsNullOrEmpty(formatModel.Tag0))
                tagDict.Add(0, formatModel.Tag0);
            else if (!string.IsNullOrEmpty(formatModel.Tag1))
                tagDict.Add(1, formatModel.Tag1);
            else if (!string.IsNullOrEmpty(formatModel.Tag2))
                tagDict.Add(2, formatModel.Tag2);
            else if (!string.IsNullOrEmpty(formatModel.Tag3))
                tagDict.Add(3, formatModel.Tag3);
            else if (!string.IsNullOrEmpty(formatModel.Tag4))
                tagDict.Add(4, formatModel.Tag4);
            return tagDict;
        }

        public static string GenerateCsvTagsStr(KeyValuePair<int, string> keyValue, int maxCommaNum)
        {
            string commaStr = string.Empty;
            for (int i = 0; i < maxCommaNum; i++)
            {
                if (i == keyValue.Key) commaStr += "{0}";
                commaStr += ",";
            }
            commaStr = string.Format(commaStr, keyValue.Value);
            return commaStr;
        }

        public static int ConvertPayType(int payType)
        {
            int convPayment = -1;
            switch (payType)
            {
                case 2:
                case 4:
                    convPayment = 10;
                    break;
                case 5:
                    convPayment = 15;
                    break;
                case 7:
                    convPayment = 17;
                    break;
                default:
                    break;
            }
            return convPayment;
        }
    }
}
