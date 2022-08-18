using OrdersInSecondsMovile.ViewModels;
using Rg.Plugins.Popup.Pages;
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
    public partial class PopUpRegister : PopupPage
    {
        public PopUpRegister()
        {
            InitializeComponent();
            this.BindingContext = new RegisterViewModel();
        }
    }
}