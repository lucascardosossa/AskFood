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
            var repository = new RestClient();
            
            var items = await repository.GetItemsByProduct("item/byProduct",_product);

            Items.Clear();
            foreach (var i in items)
            {
                Items.Add(i);
            }
        }
    }
}

