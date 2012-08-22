using System;
using System.Collections;

namespace StatsMix
{
    class Client
    {
        public string ApiKey { get; private set; }
        private ApiRequest Request;

        public Client(string apiKey)
        {
            ApiKey = apiKey;
            Request = new ApiRequest(apiKey);
        }
       
        public string track(string metricName, Hashtable parameters)
        {
            parameters["name"] = metricName;
            return Request.track(parameters); 
        }

        public string track(string metricName, double value = 1)
        {
            var parameters = new Hashtable();
            parameters["name"] = metricName;
            parameters["value"] = value;
            return Request.track(parameters);
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
