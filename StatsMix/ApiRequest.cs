using System;
using System.Collections;
using RestSharp;

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

        public bool create(string type,  Object obj)
        {
            var request = new RestRequest(type, Method.POST); 
            return false;
        }

        public string track(Hashtable parameters)
        {
            var request = new RestRequest("track", Method.POST);
            foreach (string key in parameters.Keys)
            {
                request.AddParameter(key, parameters[key]);
            }
            return restClient.Execute(request).Content;
        }

        public bool update(string type, Object obj ) 
        {
            return false;
        }

        public bool delete(string type, Object obj) 
        {
            return false;
        }

        public void makeParams(ref RestRequest request, Object obj)
        {
            
        }
    }
}
