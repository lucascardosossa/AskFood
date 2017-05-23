using AskFood.Model;
using AskFood.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AskFood.View
{
    
    public partial class ProductPage : ContentPage
    {
        private ProductViewModel ViewModel => BindingContext as ProductViewModel;
        public ProductPage()
        {
            InitializeComponent();

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (ViewModel != null)
                await ViewModel.LoadAsync();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem != null)
            {
                ViewModel.ShowItemCommand((Product)e.SelectedItem);
            }
            
        }
    }
}
