using System;
using System.Collections;
using System.Collections.Generic;
using RestSharp;
using Newtonsoft.Json;

namespace StatsMix
{
    public class Client
    {
        public string ApiKey { get; private set; }
        public bool ThrowApiErrors { get; set; }
        private RestClient restClient;
        private const string BaseUrl = "http://statsmix.com/api/v2";
        private string p;

        public Client(string apiKey, bool throwApiErrors = false)
        {
            ApiKey = apiKey;
            ThrowApiErrors = throwApiErrors;
            restClient = new RestClient(BaseUrl);
            restClient.AddDefaultHeader("X-StatsMix-Token", apiKey);
            
        }
       
        public string track(string metricName, Hashtable parameters, Dictionary<string, string> meta)
        {
            string json = JsonConvert.SerializeObject(meta);
            parameters["meta"] = json;
            parameters["name"] = metricName;
            string resp = request("track", parameters, Method.POST);
            return resp;
        }

        public string track(string metricName, Hashtable parameters)
        {
            parameters["name"] = metricName;
            string resp = request("track", parameters, Method.POST);
            return resp;
        }

        public string track(string metricName, double value = 1.0)
        {
            var parameters = new Hashtable();
            parameters["name"] = metricName;
            parameters["value"] = value;
            return request("track", parameters, Method.POST);
        }

        private string request(string resource, Hashtable parameters, Method method)
        {
            var req = new RestRequest(resource, method);
            foreach (string key in parameters.Keys)
            {
                req.AddParameter(key, parameters[key]);
            }
            IRestResponse resp = restClient.Execute(req);
            if (ThrowApiErrors) statusCheck(resp); //will throw an exception if not 200
            return resp.Content;
        }

        private void statusCheck(IRestResponse resp)
        {   
            System.Collections.Generic.IEnumerator<RestSharp.Parameter> e = resp.Headers.GetEnumerator();
            while (e.MoveNext())
            {
                if (e.Current.Name == "Status")
                {
                    string status = (string)e.Current.Value;
                    if (status != "200")
                    {
                        Exception exc = new Exception(status + ":   " + resp.Content);
                        exc.HelpLink = "http://www.statsmix.com/developers/documentation";
                        throw exc;
                    }
                }
            }
        }
    }
}
