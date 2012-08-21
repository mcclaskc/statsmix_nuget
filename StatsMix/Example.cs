using System;

namespace test
{
    class Example
    {
        const string YOUR_API_KEY = "abc123";
        static void Main(string[] args)
        {
            StatsMix.Client smClient = new StatsMix.Client(YOUR_API_KEY);
            string output = smClient.ApiKey;
            Console.WriteLine("hello stats world, the api key is: " + output);

            StatsMix.Stat smStat = new StatsMix.Stat();
            smStat.RefId = "0xDEADBEEF";
           /*Console.WriteLine("Id: " + smStat.Id);
            Console.WriteLine("Value: " + smStat.Value);
            Console.WriteLine("Meta: " + smStat.Meta);
            Console.WriteLine("RefId: " + smStat.RefId);
            Console.WriteLine("ProfileId: " + smStat.ProfileId);
            Console.WriteLine("MetricId: " + smStat.MetricId);
            Console.WriteLine("GeneratedAt: " + smStat.GeneratedAt);
            Console.WriteLine("CreatedAt: " + smStat.CreatedAt);
            Console.WriteLine("UpdatedAt: " + smStat.UpdatedAt);*/
            string result = smClient.track("metric_name", smStat);
            Console.WriteLine("and your stat result is: " + result);
            Console.ReadLine();
        }
    }
}
