using AskFood.Helpers;
using AskFood.Model;
using AskFood.Services;
using AskFood.View;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AskFood.ViewModel
{
    public class LoginViewModel: BaseViewModel
    {
        //Social Login
        private readonly AzureService _azureService;

        private bool _isBusy;

        public Command LoginCommand { get; }

        // End Social Login

        public ObservableCollection<User> Users { get; set; }

        public Command Signin { get;}
        public Command Signup { get; }

        public String _username;

        public String Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        public String _password;

        public String Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public LoginViewModel()
        {
            //Social login
            Settings.AuthToken = string.Empty;
            Settings.UserId = string.Empty;

            _azureService = DependencyService.Get<AzureService>();
            LoginCommand = new Command(async () => await ExecuteLoginCommandAsync());
            // end social login 

            Users = new ObservableCollection<User>();
            Signin = new Command((obj) => SigninCommand());

        }

        private async Task ExecuteLoginCommandAsync()
        {
            if (_isBusy || !(await LoginAsync()))
            {
                return;
            }
            else
            {
                await PushAsync<ProductViewModel>();
            }
            _isBusy = false;
        }

        private Task<bool> LoginAsync()
        {
            _isBusy = true;
            if (Settings.IsLoggedIn)
                return Task.FromResult(true);

            return _azureService.LoginAsync();
        }

        async void SigninCommand()
        {
            Exception Error = null;
            
                try
                {
                    
                    
                        User userCredentials = new User();
                        userCredentials.name = _username;
                        userCredentials.password = _password;
                        
                        var repository = new RestClient();
                        var logged = await repository.LoginUser("user/login", userCredentials);
                        if(logged != "True")
                        {
                            //var repository = new RestClient();
                            // var user = await repository.GetUser("user");
                            //var products = await repository.GetProduct("product");
                            await PushAsync<ProductViewModel>();
                        }
                            
                        else
                            await App.Current.MainPage.DisplayAlert("Alerta", "Credenciais incorretas.", "ok");

                }
                catch (Exception ex)
                {
                    Error = ex;
                }
                finally
                {

                    if (Error != null)
                    {
                        await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Error!", Error.Message, "OK");
                    }
                }

        }
    }
}