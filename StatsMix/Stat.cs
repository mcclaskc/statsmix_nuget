using System;
using System.Collections;

namespace StatsMix
{
    class Stat : Object
    {
        public int id {get; set;}
        public int profile_id { get; set; }
        public int value { get; set; }
        public string meta { get; set; }
        public string ref_id { get; set; }
        public int metric_id { get; set; }
        public DateTime generated_at { get; set; }

        public Stat() 
        {
            Scope = "stats";
        }

        public Stat(Hashtable parameters)
        {
            foreach (string key in parameters)
            {
                switch (key)
                {
                    case "id":
                        id = (int)parameters["id"];
                        break;
                    case "profile_id":
                        //ProfileId = (int)parameters["profile_id"];
                        break;
                    case "value":
                        break;
                    case "meta":
                        break;
                    case "ref_id":
                        break;
                    case "metric_id":
                        break;
                    case "generated_at":
                        break;
                }
            }
        }
    }
}