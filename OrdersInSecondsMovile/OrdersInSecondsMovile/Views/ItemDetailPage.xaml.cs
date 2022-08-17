using OrdersInSecondsMovile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace OrdersInSecondsMovile.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}