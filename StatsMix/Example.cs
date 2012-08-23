using System;
using System.Collections;
using System.Collections.Generic;
using RestSharp;

namespace test
{
    class Example
    {
        const string YOUR_API_KEY = "d114e70073327345a717";
        //const string YOUR_API_KEY = "bad";
        static void Main(string[] args)
        {
            Console.WriteLine("hello stats world");

            StatsMix.Client smClient = new StatsMix.Client(YOUR_API_KEY);

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
