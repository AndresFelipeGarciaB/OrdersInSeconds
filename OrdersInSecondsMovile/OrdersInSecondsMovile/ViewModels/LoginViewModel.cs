using OrdersInSecondsMovile.Models;
using OrdersInSecondsMovile.Views;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace OrdersInSecondsMovile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        #region Commands
        public Command LoginCommand { get; }
        #endregion
        #region Properties
        private UsersModel _user;
        public UsersModel User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Constructor
        public LoginViewModel()
        {
            LoginCommand = new Command<string>(OptionButton);
            User = new UsersModel(); 
        }
        #endregion
        #region Methods
        private void OptionButton(string item)
        {
            switch (item)
            {
                case "Login":
                    validateLogin();                    
                    break;
                case "Register":
                    Navigation.PushPopupAsync(new PopUpRegister());
                    break;
                
            }
        }

        private void validateLogin()
        {
            try
            {

                var UsersSQLite  = App.RegistroRepository.GetUsuario(User);
                if (UsersSQLite != null)
                {
                    if(UsersSQLite.user == User.user && UsersSQLite.Pass == User.Pass)
                    {
                        Application.Current.MainPage = new AppShell();
                    }
                }
                else
                {
                    Application.Current.MainPage.DisplayAlert("Información", "No existe el usuario, por favor registrarse.", "Ok");
                }
                
                
            }
            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("Error", "En este momento se presenta una indisponibilidad, por favor intente mas tarde.", "Ok");
            }
            

        }



        #endregion
    }
}
