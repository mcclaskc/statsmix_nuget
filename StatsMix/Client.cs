using System;

namespace StatsMix
{
    class Client
    {
        public string ApiKey { get; set; }
        const string BASE_URL = "http://statsmix.com/api/v2";

        public Client(string api_key)
        {
            ApiKey = api_key;
        }

    }
}
