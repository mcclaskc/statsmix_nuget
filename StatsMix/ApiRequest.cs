using System;
using System.Collections;
using RestSharp;
using System.Reflection;

namespace StatsMix
{
    class ApiRequest
    {
        const string BaseUrl = "http://statsmix.com/api/v2";
        RestClient restClient;

        public ApiRequest(string apiKey)
        {
            restClient = new RestClient(BaseUrl);
            restClient.AddDefaultHeader("X-StatsMix-Token", apiKey);
        }

        
    }
}
