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

        private static RegisterRepository _registerRepository;

        public static RegisterRepository RegisterRepository
        {
            get
            {
                if (_registerRepository == null)
                {
                    _registerRepository = new RegisterRepository();
                }

                return _registerRepository;
            }

        }

        private static AddDataRepository _addDataRepository;

        public static AddDataRepository AddDataRepository
        {
            get
            {
                if (_addDataRepository == null)
                {
                    _addDataRepository = new AddDataRepository();
                }

                return _addDataRepository;
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
