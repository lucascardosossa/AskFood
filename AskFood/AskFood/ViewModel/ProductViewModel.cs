using AskFood.Model;
using AskFood.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace AskFood.ViewModel
{
    public class ProductViewModel : BaseViewModel
    {
        public ObservableCollection<Product> Products { get; }

        public ProductViewModel()
        {
            Products = new ObservableCollection<Product>();
        }

        public async Task LoadAsync()
        {
            var repository = new RestClient();
            var products = await repository.GetProduct("product");

            System.Diagnostics.Debug.WriteLine("chegou aqui");
            Products.Clear();
            foreach (var product in products)
            {
                Products.Add(product);
            }
        }
    }
}
