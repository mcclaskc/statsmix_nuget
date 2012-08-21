using System;
using RestSharp;

namespace StatsMix
{
    class Client
    {
        public string ApiKey { get; set; }
        const string BaseUrl = "http://statsmix.com/api/v2";
        RestClient restClient;

        public Client(string apiKey)
        {
            ApiKey = apiKey;
            restClient = new RestClient(BaseUrl);
            restClient.AddDefaultHeader("X-StatsMix-Token", apiKey);
        }

        public string track(string metricName, Stat stat)
        {
            var request = new RestRequest("track", Method.POST);
            request.AddParameter("name", metricName); //string parameters = "?name=" + metricName;
            request.AddParameter("value", stat.Value); //parameters += "&Value=" + stat.Value;
            if (!stat.GeneratedAt.Equals(new DateTime())) request.AddParameter("generated_at", stat.GeneratedAt); //parameters += "&GeneratedAt=" + stat.GeneratedAt;
            //TODO META if (stat.Meta empty? stuff?) 
            if (!string.IsNullOrEmpty(stat.RefId)) request.AddParameter("ref_id", stat.RefId);//parameters += "&RefId=" + stat.RefId;
            if (stat.ProfileId != 0) request.AddParameter("profile_id", stat.ProfileId);//parameters += "&ProfileId=" + stat.ProfileId;
            Console.WriteLine("REQUEST: " + request.Parameters);
            return restClient.Execute(request).Content; //return BaseUrl + "/track" + parameters;
     
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
