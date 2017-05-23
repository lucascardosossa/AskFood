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
    
    public partial class ItemPage : ContentPage
    {
        private ItemViewModel ViewModel => BindingContext as ItemViewModel;
        public ItemPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (ViewModel != null)
                await ViewModel.LoadAsync();
        }
    }
}