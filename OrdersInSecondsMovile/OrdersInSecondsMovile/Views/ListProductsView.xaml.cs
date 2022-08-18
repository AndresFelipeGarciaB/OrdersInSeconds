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
    public partial class ListProductsView : ContentPage
    {
        ListProductsViewModel _viewModel;
        public ListProductsView()
        {
            InitializeComponent();
            ;
            BindingContext = _viewModel = new ListProductsViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
        void Handle_SearchButtonPressed(object sender, System.EventArgs e)
        {
            var countriesSearched = _viewModel.Items.Where(c => c.title.Contains(searchBar.Text));
            ItemsListView.ItemsSource = countriesSearched;
        }
    }
}