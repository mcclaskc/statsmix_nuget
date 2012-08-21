using System;
using RestSharp;

namespace test
{
    class Example
    {
        const string YOUR_API_KEY = "d114e70073327345a717";
        static void Main(string[] args)
        {
            Console.WriteLine("hello stats world");

            StatsMix.Client smClient = new StatsMix.Client(YOUR_API_KEY);
            StatsMix.Stat smStat = new StatsMix.Stat();
            smStat.Value = 3;

            Console.WriteLine("sending request...");
            
            string result = smClient.track("metric_name", smStat);
            
            Console.WriteLine("and your stat result is: " + result);
            Console.ReadLine();
        }
    }
}
