using OrdersInSecondsMovile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OrdersInSecondsMovile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailProductsView : ContentPage
    {
        public DetailProductsView()
        {
            InitializeComponent();
            BindingContext = new DetailProductsVieModel();
        }
    }
}