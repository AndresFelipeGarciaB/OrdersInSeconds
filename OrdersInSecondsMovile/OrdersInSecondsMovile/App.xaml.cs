using OrdersInSecondsMovile.Repositories;
using OrdersInSecondsMovile.Services;
using OrdersInSecondsMovile.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OrdersInSecondsMovile
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new LoginPage(); //AppShell();
        }

        private static RegisterRepository _registroRepository;

        public static RegisterRepository RegistroRepository
        {
            get
            {
                if (_registroRepository == null)
                {
                    _registroRepository = new RegisterRepository();
                }

                return _registroRepository;
            }

        }


        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
