using AskFood.Model;
using AskFood.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using System;

namespace AskFood.ViewModel
{
    public class ProductViewModel : BaseViewModel
    {
        public ObservableCollection<Product> Products { get; }


        public ProductViewModel()
        {
            Products = new ObservableCollection<Product>();
        }

        private async void ExecuteShowItemCommand(Item obj)
        {
            await PushAsync<ItemViewModel>(obj);
        }

        public async void ShowItemCommand(Product obj)
        {
            await PushAsync<ItemViewModel>(obj);
        }

        public async Task LoadAsync()
        {
            var repository = new RestClient();
            var products = await repository.GetProduct("product");

            Products.Clear();
            foreach (var product in products)
            {
                Products.Add(product);
            }
        }
    }
}
