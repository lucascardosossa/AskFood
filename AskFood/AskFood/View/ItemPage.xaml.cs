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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemPage : ContentPage
    {
        private ItemViewModel ViewModel => BindingContext as ItemViewModel;
        public ItemPage()
        {
            InitializeComponent();
        }
    }
}