using System;
using RestSharp;

namespace StatsMix
{
    class Client
    {
        public string ApiKey { get; set; }
        const string BaseUrl = "http://statsmix.com/api/v2";

        public Client(string apiKey)
        {
            ApiKey = apiKey;
        }

        public string track(string metricName, Stat stat)
        {
            string parameters = "?name=" + metricName;
            parameters += "&Value=" + stat.Value;
            if (!stat.GeneratedAt.Equals(new DateTime())) parameters += "&GeneratedAt=" + stat.GeneratedAt;
            //TODO META if (stat.Meta empty? stuff?) 
            if (!string.IsNullOrEmpty(stat.RefId)) parameters += "&RefId=" + stat.RefId;
            if (stat.ProfileId != 0) parameters += "&ProfileId=" + stat.ProfileId;

            return BaseUrl + "/track" + parameters;
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
