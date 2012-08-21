using System;

namespace StatsMix
{
    class Client
    {
        public string ApiKey { get; set; }
        const string BASE_URL = "http://statsmix.com/api/v2";

        public Client(string apiKey)
        {
            ApiKey = apiKey;
        }

        public bool track(string metricName, Stat stat)
        {
            if(stat.Value == 0)
            {
                return true;
            }
            return false;
        }
    }
}
