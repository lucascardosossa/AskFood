﻿using AskFood.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AskFood.Services
{
    public class RestClient : IRestClient
    {
        string URLWebAPI = "http://10.0.2.2:300/";

        public async Task<List<User>> GetUser(string endpoint)
        {
            HttpResponseMessage response = null;
            List<User> Users;
            var uri = new Uri(URLWebAPI + endpoint);
            
            using (var Client = new HttpClient())
            {
                Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                response = await Client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Users = JsonConvert.DeserializeObject<List<User>>(content);
                    return Users;
                }
                else
                {
                    return null;
                }
                
            }
            
        }

        public async Task<List<Product>> GetProduct(string endpoint)
        {
            List<Product> Products;
            var uri = new Uri(URLWebAPI + endpoint);
            using (var Client = new HttpClient())
            {
                Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await Client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Products = JsonConvert.DeserializeObject<List<Product>>(content);
                    return Products;
                }
                else
                {
                    return null;
                }
                
                
            }
            
        }

        public async Task<string> LoginUser(string endpoint, User user)
        {
            HttpResponseMessage response = null;
            String result;
            var uri = new Uri(URLWebAPI + endpoint);
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            using (var Client = new HttpClient())
            {
                response = await Client.PostAsync(uri, content);
                //result = await response.Content.ReadAsStringAsync();
                result = response.ReasonPhrase;
            }
            return result;
        }
    }
}