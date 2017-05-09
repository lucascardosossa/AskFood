using AskFood.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AskFood.Services
{
    public interface IRestClient
    {
        Task<List<User>> GetUser(string endpoint);
        Task<List<Product>> GetProduct(string endpoint);
        Task<string> LoginUser(string endpoint, User user);
    }
}
