using AskFood.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AskFood.Services
{
    public class RestClient
    {
        string URLWebAPI = "http://10.0.2.2:300/";
        public async Task<List<User>> GetUser(string endpoint)
        {
            List<User> Users;
            using (var Client = new System.Net.Http.HttpClient())

            {

                var JSON = await Client.GetStringAsync(URLWebAPI+endpoint);

                Users = Newtonsoft.Json.JsonConvert.DeserializeObject<List<User>>(JSON);

            }

            return Users;
        }

        public async Task<string> LoginUser(string endpoint)
        {
            String status;
            using (var Client = new System.Net.Http.HttpClient())

            {

                var JSON = await Client.GetStringAsync(URLWebAPI + endpoint);

                status = Newtonsoft.Json.JsonConvert.DeserializeObject<string>(JSON);

            }

            return status;
        }
    }
}