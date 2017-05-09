using AskFood.Model;
using AskFood.Services;
using AskFood.View;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace AskFood.ViewModel
{
    public class LoginViewModel: BaseViewModel
    {
        
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
            Users = new ObservableCollection<User>();
            Signin = new Command((obj) => SigninCommand());

        }

        async void SigninCommand()
        {
            Exception Error = null;
            
                try
                {
                    
                    
                        User userCredentials = new User();
                        userCredentials.Name = _username;
                        userCredentials.Password = _password;
                        
                        var repository = new RestClient();
                        var logged = await repository.LoginUser("user/login", userCredentials);
                        if(logged == "OK")
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