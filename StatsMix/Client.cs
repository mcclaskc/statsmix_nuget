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

        public Client(string apiKey, bool throwApiErrors = false)
        {
            ApiKey = apiKey;
            ThrowApiErrors = throwApiErrors;
            restClient = new RestClient(BaseUrl);
            restClient.AddDefaultHeader("X-StatsMix-Token", apiKey);
            
        }

        public string track(string metricName, Dictionary<string, string> properties, Dictionary<string, string> meta)
        {
            string json = JsonConvert.SerializeObject(meta);
            properties["meta"] = json;
            properties["name"] = metricName;
            string resp = request("track", properties, Method.POST);
            return resp;
        }

        public string track(string metricName, Dictionary<string, string> properties)
        {
            properties["name"] = metricName;
            string resp = request("track", properties, Method.POST);
            return resp;
        }

        public string track(string metricName, double value = 1.0)
        {
            var properties = new Dictionary<string, string>();
            properties["name"] = metricName;
            properties["value"] = value.ToString();
            return request("track", properties, Method.POST);
        }

        private string request(string resource, Dictionary<string, string> properties, Method method)
        {
            var req = new RestRequest(resource, method);
            foreach (string key in properties.Keys)
            {
                req.AddParameter(key, properties[key]);
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
