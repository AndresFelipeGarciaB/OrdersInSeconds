using OrdersInSecondsMovile.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace OrdersInSecondsMovile.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        #region Commands
        public Command BotonAgregar { get; }
        #endregion

        #region Properties
        private UsersModel _newUser;
        public UsersModel NewUser
        {
            get { return _newUser; }
            set
            {
                _newUser = value;
                OnPropertyChanged();
            }
        }
        #endregion


        #region Constructor
        public RegisterViewModel()
        {
            BotonAgregar = new Command(CreateUser);
            NewUser = new UsersModel();
        }
        #endregion

        #region Methods
        private void CreateUser()
        {
            try
            {
                if(NewUser != null)
                {
                    App.RegisterRepository.AddOrUpdate(NewUser);
                    App.Current.MainPage.DisplayAlert("Usuario agregado", App.RegisterRepository.StatusMessage, "Aceptar");
                }
                else
                {
                    App.Current.MainPage.DisplayAlert("Usuario No agregado", App.RegisterRepository.StatusMessage, "Aceptar");
                }
                
                
            }
            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("Registro Incompleto", "El registro no se pudo realizar por favor intente mas tarde.", "Ok");
            }
        }


        #endregion
    }
}
