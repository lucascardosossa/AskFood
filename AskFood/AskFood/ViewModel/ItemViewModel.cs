using AskFood.Model;
using AskFood.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AskFood.ViewModel
{
    public class ItemViewModel : BaseViewModel
    {
        public ObservableCollection<Item> Items { get;  }

        private readonly Product _product;

        public ItemViewModel(Product product)
        {
            Items = new ObservableCollection<Item>();
            _product = product;
        }

        public async Task LoadAsync()
        {
            Exception Error = null;
            var repository = new RestClient();
            try
            {
                var items = await repository.GetItemsByProduct($"item/byProduct/{_product.Id}");
                
                Items.Clear();
                foreach (var i in items)
                {
                    Items.Add(i);
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

