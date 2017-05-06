using AskFood.Model;
using AskFood.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AskFood.ViewModel
{
    public class UserDirectoryVM : ObservableBaseObject
    {
        public ObservableCollection<User> Users { get; set; }

        bool isBusy = false;

        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        public Command LoadDirectoryCommand { get; set; }

        public UserDirectoryVM()
        {
            Users = new ObservableCollection<User>();
            IsBusy = false;
            LoadDirectoryCommand = new Command((obj) => LoadDirectory());

        }

        async void LoadDirectory()
        {
            Exception Error = null;
            if(!IsBusy)
            {
                try
                {
                    IsBusy = true;

                    //await Task.Delay(3000);
                    bool resposta = await App.Current.MainPage.DisplayAlert("Confirmar", "Voce realmente deseja carregar os itens?", "sim", "não");

                    if (resposta) {
                        var repository = new RestClient();
                        var loadedDirectory = await repository.GetUser("user");
                        Users.Clear();
                        foreach (var user in loadedDirectory)
                        {
                            Users.Add(user);
                        }
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Alerta", "Tudo bem.","ok");
                    }
                    
                    

                    IsBusy = false;
                }
                catch(Exception ex)
                {
                    Error = ex;
                }
                finally
                {

                    IsBusy = false;
                    if (Error != null)
                    {
                        await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Error!", Error.Message, "OK");
                    }
                }

            }
            
        }
    }
}
