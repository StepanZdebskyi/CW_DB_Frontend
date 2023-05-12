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
    public class DoctorsInfoConnection
    {
        private HttpClient newhttpClient;
        private readonly string ServerAddress;
        private List<DoctorsInfoModel> allInfo;

        public DoctorsInfoConnection(string SrvAddrs)
        {
            newhttpClient = new HttpClient();
            allInfo = new List<DoctorsInfoModel>();
            ServerAddress = SrvAddrs;
        }

        public List<DoctorsInfoModel> GetInfo()
        {
            allInfo = new List<DoctorsInfoModel>();

            using (newhttpClient = new HttpClient())
            {
                var endpoint = new Uri(ServerAddress);
                var result = newhttpClient.GetAsync(endpoint).Result;
                var json = result.Content.ReadAsStringAsync().Result;

                allInfo = JsonConvert.DeserializeObject<List<DoctorsInfoModel>>(json);
            }
            return allInfo;
        }

        public string AddInfo(DoctorsInfoModel info)
        {
            string ResultMessage = "";

            using (newhttpClient = new HttpClient())
            {
                var endpoint = new Uri(ServerAddress);
                var newPostJson = JsonConvert.SerializeObject(info);
                var payload = new StringContent(newPostJson, Encoding.UTF8, "application/json");

                var result = newhttpClient.PostAsync(endpoint, payload);
                var message = result.Result.Content.ReadAsStringAsync();
                ResultMessage = message.Result.ToString();
            }
            return ResultMessage;
        }

        public string EditInfo(DoctorsInfoModel info)
        {
            string ResultMessage = "";

            using (newhttpClient = new HttpClient())
            {
                var endpoint = new Uri(ServerAddress);
                var newPostJson = JsonConvert.SerializeObject(info);
                var payload = new StringContent(newPostJson, Encoding.UTF8, "application/json");

                var result = newhttpClient.PutAsync(endpoint, payload);
                var message = result.Result.Content.ReadAsStringAsync();
                ResultMessage = message.Result.ToString();
            }
            return ResultMessage;
        }

        public string DeleteInfo(DoctorsInfoModel info)
        {
            string ResultMessage = "";

            using (newhttpClient = new HttpClient())
            {
                var endpoint = new Uri(ServerAddress);
                var newPostJson = JsonConvert.SerializeObject(info);
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
