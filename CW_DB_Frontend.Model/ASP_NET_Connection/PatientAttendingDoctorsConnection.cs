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
    public class PatientAttendingDoctorsConnection
    {
        private HttpClient newhttpClient;
        private readonly string ServerAddress;
        private List<PatientAttendingDoctorsModel> allDoctors;

        public PatientAttendingDoctorsConnection(string SrvAddrs)
        {
            newhttpClient = new HttpClient();
            allDoctors = new List<PatientAttendingDoctorsModel>();
            ServerAddress = SrvAddrs;
        }

        public List<PatientAttendingDoctorsModel> GetRecords()
        {
            allDoctors = new List<PatientAttendingDoctorsModel>();

            using (newhttpClient = new HttpClient())
            {
                var endpoint = new Uri(ServerAddress);
                var result = newhttpClient.GetAsync(endpoint).Result;
                var json = result.Content.ReadAsStringAsync().Result;

                allDoctors = JsonConvert.DeserializeObject<List<PatientAttendingDoctorsModel>>(json);
            }
            return allDoctors;
        }

        public string AddRecord(PatientAttendingDoctorsModel record)
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

        public string EditRecord(PatientAttendingDoctorsModel record)
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

        public string DeleteRecord(PatientAttendingDoctorsModel record)
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
