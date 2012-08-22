using System;
using System.Collections;
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

            //doing a track with just metric name
            // smClient.track("metric_name")

           /* // doing a track with metric name and a value
            Console.WriteLine("Basic Tracking:");
            string resp = smClient.track("metric_name", 5.2);
            Console.WriteLine("response was: " + resp); */

            // tracking with metric name and parameters
            Console.WriteLine("Tracking with Parameters:");
            var parameters = new Hashtable();
            parameters["value"] = 5.1;
            parameters["ref_id"] = "Test01";        
            string resp = smClient.track("metric_name", parameters);
            Console.WriteLine("response was: " + resp);

            StatsMix.Stat smStat = new StatsMix.Stat();

            //waiting for any input to close the console
            Console.ReadLine();
        }
    }
}
