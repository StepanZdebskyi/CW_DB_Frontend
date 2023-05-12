using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CW_DB_Frontend.Model.Models;
using Newtonsoft.Json;

namespace CW_DB_Frontend.Model.ASP_NET_Connection
{
    public class SpecialityConnection
    {
        private HttpClient newhttpClient;
        private readonly string ServerAddress;
        private List<SpecialityModel> allSpec;

        public SpecialityConnection(string SrvAddrs)
        {
            newhttpClient = new HttpClient();
            allSpec = new List<SpecialityModel>();
            ServerAddress = SrvAddrs;
        }

        public List<SpecialityModel> GetSpecs()
        {
            allSpec = new List<SpecialityModel>();

            using (newhttpClient = new HttpClient())
            {
                var endpoint = new Uri(ServerAddress);
                var result = newhttpClient.GetAsync(endpoint).Result;
                var json = result.Content.ReadAsStringAsync().Result;

                allSpec = JsonConvert.DeserializeObject<List<SpecialityModel>>(json);
            }
            return allSpec;
        }

        public string AddSpec(SpecialityModel spec)
        {
            string ResultMessage = "";

            using (newhttpClient = new HttpClient())
            {
                var endpoint = new Uri(ServerAddress);
                var newPostJson = JsonConvert.SerializeObject(spec);
                var payload = new StringContent(newPostJson, Encoding.UTF8, "application/json");

                var result = newhttpClient.PostAsync(endpoint, payload);
                var message = result.Result.Content.ReadAsStringAsync();
                ResultMessage = message.Result.ToString();
            }
            return ResultMessage;
        }

        public string EditSpec(SpecialityModel spec)
        {
            string ResultMessage = "";

            using (newhttpClient = new HttpClient())
            {
                var endpoint = new Uri(ServerAddress);
                var newPostJson = JsonConvert.SerializeObject(spec);
                var payload = new StringContent(newPostJson, Encoding.UTF8, "application/json");

                var result = newhttpClient.PutAsync(endpoint, payload);
                var message = result.Result.Content.ReadAsStringAsync();
                ResultMessage = message.Result.ToString();
            }
            return ResultMessage;
        }

        public string DeleteSpec(SpecialityModel spec)
        {
            string ResultMessage = "";

            using (newhttpClient = new HttpClient())
            {
                var endpoint = new Uri(ServerAddress);
                var newPostJson = JsonConvert.SerializeObject(spec);
                var payload = new StringContent(newPostJson, Encoding.UTF8, "application/json");
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, endpoint);//хз чи спрацює але інакше ніяк
                request.Content = payload;

                var result = newhttpClient.SendAsync(request);
                var message = result.Result.Content.ReadAsStringAsync();
                ResultMessage = message.Result.ToString();
            }

            return ResultMessage;
        }
    }
}
