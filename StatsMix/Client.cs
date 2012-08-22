using System;
using System.Collections;
using RestSharp;
namespace StatsMix
{
    class Client
    {
        public string ApiKey { get; private set; }
        private RestClient restClient;
        private const string BaseUrl = "http://statsmix.com/api/v2";

        public Client(string apiKey)
        {
            ApiKey = apiKey;
            restClient = new RestClient(BaseUrl);
            restClient.AddDefaultHeader("X-StatsMix-Token", apiKey);
        }
       
        public string track(string metricName, Hashtable parameters)
        {
            parameters["name"] = metricName;
            return request("track", parameters, Method.POST); 
        }

        public string track(string metricName, double value = 1.0)
        {
            var parameters = new Hashtable();
            parameters["name"] = metricName;
            parameters["value"] = value;
            return request("track", parameters, Method.POST);
        }
        public string createStat(int metricId, Hashtable parameters)
        {
            parameters["metric_id"] = metricId;
            return request("stats", parameters, Method.POST);
        }

        private string request(string resource, Hashtable parameters, Method method)
        {
            var request = new RestRequest(resource, method);
            foreach (string key in parameters.Keys)
            {
                request.AddParameter(key, parameters[key]);
            }
            return statusCheck(restClient.Execute(request));
        }

        private string statusCheck(IRestResponse resp)
        {
            System.Collections.Generic.IList<RestSharp.Parameter> headers = resp.Headers;
            foreach (Parameter item in headers)
            {
                Console.WriteLine("header: " + item.Name);
            }
            
            System.Collections.Generic.IEnumerator<RestSharp.Parameter> e = resp.Headers.GetEnumerator();
            while (e.MoveNext())
            {
                if (e.Current.Name == "Status")
                {
                    string status = (string)e.Current.Value;
                    Console.WriteLine("enum: Status = " + status);
                    if (status != "200")
                    {
                        Exception exc = new Exception(status + ":   " + resp.Content);
                        exc.HelpLink = "http://www.statsmix.com/developers/documentation#metric-examples";
                        throw exc;
                    }
                    return status; 
                }
            }
            return "shouldn't reach here";
        }

        private void error(string status)
        {
            Exception e = new Exception();
            
            throw e;
        }
    }
}

/* 
        public int Id { get; set; }
        public int Value { get; set; }
        public string Meta { get; set; }
        public string RefId { get; set; }
        public int ProfileId { get; set; }
        public int MetricId { get; set; }
        public DateTime GeneratedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
 */
