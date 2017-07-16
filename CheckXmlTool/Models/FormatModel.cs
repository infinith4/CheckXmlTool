using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckXmlTool.Models
{
    public class FormatModel
    {
        [Serializable]
        public class Format
        {
            public string Tag0 { get; set; }
            public string Tag1 { get; set; }
            public string Tag2 { get; set; }
            public string Tag3 { get; set; }
            public string Tag4 { get; set; }
            public string Attributes { get; set; }
            public string Required { get; set; }
            public string Conditions { get; set; }
        }
        public sealed class FormatModelMap : CsvClassMap<Format>
        {
            public FormatModelMap()
            {
                Map(m => m.Tag0).Index(0);
                Map(m => m.Tag1).Index(1);
                Map(m => m.Tag2).Index(2);
                Map(m => m.Tag3).Index(3);
                Map(m => m.Tag4).Index(4);
                Map(m => m.Attributes).Index(5);
                Map(m => m.Required).Index(6);
                Map(m => m.Conditions).Index(7);
            }
        }
    }
}
