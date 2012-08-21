using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StatsMix;

namespace test
{
    class Example
    {
        const string YOUR_API_KEY = "abc123";
        static void Main(string[] args)
        {
            Client smclient = new Client(YOUR_API_KEY);
            string output = smclient.ApiKey;
            System.Console.WriteLine("hello stats world, the api key is: " + output);
            System.Console.ReadLine();
        }
    }
}
