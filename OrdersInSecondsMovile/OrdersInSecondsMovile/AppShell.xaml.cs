using OrdersInSecondsMovile.ViewModels;
using OrdersInSecondsMovile.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace OrdersInSecondsMovile
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(DetailProductsView), typeof(DetailProductsView));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
