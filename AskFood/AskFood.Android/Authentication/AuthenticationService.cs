using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using AskFood.Authentication;
using AskFood.Droid.Authentication;
using AskFood.Helpers;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(AuthenticationService))]
namespace AskFood.Droid.Authentication
{
    public class AuthenticationService : IAuthentication
    {
        public async Task<MobileServiceUser> Authenticate(MobileServiceClient client, MobileServiceAuthenticationProvider provider, IDictionary<string, string> parameters = null)
        {
            try
            {
                var user = await client.LoginAsync(Forms.Context, provider);

                Settings.AuthToken = user?.MobileServiceAuthenticationToken ?? string.Empty;
                Settings.UserId = user?.UserId;

                return user;
            }
            catch (Exception)
            {
                //TODO: LogError
                return null;
            }
        }
    }
}