using AskFood.Model;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace AskFood.ViewModel
{
    public class LoginViewModel: ObservableBaseObject
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
                    
                    bool resposta = await App.Current.MainPage.DisplayAlert("Confirmar", "Voce realmente deseja carregar os itens?", "sim", "não");

                    if (resposta)
                    {
                    //var repository = new RestClient();
                    //var loadedDirectory = await repository.GetUser();
                    //Users.Clear();
                    //foreach (var user in loadedDirectory)
                    //{
                    //    Users.Add(user);
                    //}
                    //await App.Current.MainPage.DisplayAlert("Alerta", $"Usuário: {_username}, Senha: {_password}", "ok");
                    await App.Current.MainPage.Navigation.PushAsync(new MainPage());
                }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Alerta", "Tudo bem.", "ok");
                    }

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