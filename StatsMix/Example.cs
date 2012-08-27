using System;
using System.Collections;
using System.Collections.Generic;

namespace test
{
    class Example
    {
        const string StatsMixApiKey = "apikey";
        private const bool ShouldDoTest = true;
        static void Main()
        {
            if (ShouldDoTest)
            {
                runTest();
            }
            else
            {
                StatsMix.Client smClient = new StatsMix.Client(StatsMixApiKey);

                Console.WriteLine("Tracking with Parameters and meta:");
                var properties = new Dictionary<string, string>();
                properties["value"] = "5.1";
                properties["ref_id"] = "Test01";
                var meta = new Dictionary<string, string>();
                meta.Add("food", "icecream");
                meta.Add("calories", "500");

                try
                {
                    String resp = smClient.track("metric_name", properties, meta);
                    Console.WriteLine("response was: " + resp);
                }
                catch (Exception e)
                {
                    Console.WriteLine("failed, response was: " + e.Message);
                }
            }


            //waiting for any input to close the console
            Console.WriteLine("Done!");
            Console.ReadLine();
        }

        private static void runTest()
        {
            StatsMix.Client client = new StatsMix.Client(StatsMixApiKey);
            StatsMix.Client raiseClient = new StatsMix.Client(StatsMixApiKey, true);


            var properties = new Dictionary<string, string>();
            properties["value"] = "5.1";
            properties["ref_id"] = "Test01";
            var meta = new Dictionary<string, string>();
            meta.Add("food", "icecream");
            meta.Add("calories", "500");

            var start = DateTime.Now;
            client.track("metric_name");
            client.track("metric_name", 2);
            client.track("metric_name", properties);
            client.track("metric_name", properties, meta);

            try { raiseClient.track("metric_name"); } catch (Exception e) { Console.WriteLine(e.Message); }
            try { raiseClient.track("metric_name", 2); } catch (Exception e) { Console.WriteLine(e.Message); }
            try { raiseClient.track("metric_name", properties); } catch (Exception e) { Console.WriteLine(e.Message); }
            try { raiseClient.track("metric_name", properties, meta); } catch (Exception e) { Console.WriteLine(e.Message); }
            Console.WriteLine(DateTime.Now - start);

        }
    }
}
