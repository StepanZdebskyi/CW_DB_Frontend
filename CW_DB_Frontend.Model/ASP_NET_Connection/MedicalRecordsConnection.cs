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
    public class MedicalRecordsConnection
    {
        private HttpClient newhttpClient;
        private readonly string ServerAddress;
        private List<MedicalRecordModel> allRecords;

        public MedicalRecordsConnection(string SrvAddrs)
        {
            newhttpClient = new HttpClient();
            allRecords = new List<MedicalRecordModel>();
            ServerAddress = SrvAddrs;
        }

        public List<MedicalRecordModel> GetRecords()
        {
            allRecords = new List<MedicalRecordModel>();

            using (newhttpClient = new HttpClient())
            {
                var endpoint = new Uri(ServerAddress);
                var result = newhttpClient.GetAsync(endpoint).Result;
                var json = result.Content.ReadAsStringAsync().Result;

                allRecords = JsonConvert.DeserializeObject<List<MedicalRecordModel>>(json);
            }
            return allRecords;
        }

        public string AddRecord(MedicalRecordModel record)
        {
            string ResultMessage = "";

            using (newhttpClient = new HttpClient())
            {
                var endpoint = new Uri(ServerAddress);
                var newPostJson = JsonConvert.SerializeObject(record);
                var payload = new StringContent(newPostJson, Encoding.UTF8, "application/json");

                var result = newhttpClient.PostAsync(endpoint, payload);
                var message = result.Result.Content.ReadAsStringAsync();
                ResultMessage = message.Result.ToString();
            }
            return ResultMessage;
        }

        public string EditRecord(MedicalRecordModel record)
        {
            string ResultMessage = "";

            using (newhttpClient = new HttpClient())
            {
                var endpoint = new Uri(ServerAddress);
                var newPostJson = JsonConvert.SerializeObject(record);
                var payload = new StringContent(newPostJson, Encoding.UTF8, "application/json");

                var result = newhttpClient.PutAsync(endpoint, payload);
                var message = result.Result.Content.ReadAsStringAsync();
                ResultMessage = message.Result.ToString();
            }
            return ResultMessage;
        }

        public string DeleteRecord(MedicalRecordModel record)
        {
            string ResultMessage = "";

            using (newhttpClient = new HttpClient())
            {
                var endpoint = new Uri(ServerAddress);
                var newPostJson = JsonConvert.SerializeObject(record);
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
