using System;
using System.Collections;
using System.Collections.Generic;

namespace test
{
    class Example
    {
        const string StatsMixApiKey = "your api key goes here";
        static void Main(string[] args)
        {
            StatsMix.Client smClient = new StatsMix.Client(StatsMixApiKey);

            Console.WriteLine("Tracking with Parameters and meta:");
            var parameters = new Hashtable();
            parameters["value"] = 5.1;
            parameters["ref_id"] = "Test01";
            var meta = new Dictionary<string, string>();
            meta.Add("food", "icecream");
            meta.Add("calories", "500");
            
            try
            {
                String resp = smClient.track("metric_name", parameters, meta);
                Console.WriteLine("response was: " + resp);
            }
            catch (Exception e)
            {
                Console.WriteLine("failed, response was: " + e.Message);
            }            
            


            //waiting for any input to close the console
            Console.ReadLine();
        }
    }
}
