using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatsMix
{
    class Metric : Object
    {
        public string Name { get; set; }
        public string Sharing { get; set; }
        public bool IncludeInEmail { get; set; }
        public string Url { get; private set; }

        public Metric(int id)
        {
            Id = id;
            Url = "test";
        }

        private Metric(string xml)
        {
        
        }

        public string getUrl()
        {
            return Url;
        }
    }
}
