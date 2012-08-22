using System;
using System.Collections;

namespace StatsMix
{
    class Stat : Object
    {
        
        public int Value { get; set; }
        public string Meta { get; set; }
        public string RefId { get; set; }
        public int MetricId { get; set; }
        public DateTime GeneratedAt { get; set; }

        public Stat() 
        {
            Scope = "stats";
        }
    }
}