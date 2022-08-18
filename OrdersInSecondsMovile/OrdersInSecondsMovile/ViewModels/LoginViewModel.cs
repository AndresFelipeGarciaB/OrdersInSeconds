using Newtonsoft.Json;
using OrdersInSecondsMovile.Models;
using OrdersInSecondsMovile.Utils;
using OrdersInSecondsMovile.Views;
using RestSharp;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
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
                var UsersSQLite  = App.RegisterRepository.GetUsuario(User);
                if (UsersSQLite != null)
                {
                    if(UsersSQLite.user == User.user && UsersSQLite.Pass == User.Pass)
                    {
                        bool thereData = App.AddDataRepository.GetAll();
                        if (Connectivity.NetworkAccess == NetworkAccess.Internet)
                        {
                            downloadData();
                            Application.Current.MainPage = new AppShell();
                        }
                        else if(thereData == false && Connectivity.NetworkAccess != NetworkAccess.Internet)
                        {
                            Application.Current.MainPage.DisplayAlert("Información", "Necesita conexión a internet.", "Ok");
                        }
                        else
                        {
                            Application.Current.MainPage.DisplayAlert("Información", "En este momento usted no tiene internet, pero se puede utilizar con normalidad la App.", "Ok");
                            Application.Current.MainPage = new AppShell();
                        }                       
                    }
                    else
                    {
                        Application.Current.MainPage.DisplayAlert("Información", "Password incorrecto.", "Ok");
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

        private void downloadData()
        {
            try
            {
                var client = new RestClient(Constants.APIBASE);                
                var request = new RestRequest("products", Method.Get);
                var response = client.Get(request);

                if (!string.IsNullOrEmpty(response.Content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var mensaje = JsonConvert.DeserializeObject<List<DataApiModel>>(response.Content);
                        if(!object.ReferenceEquals(null, mensaje))
                        {
                            InsertDataSQLite(mensaje);
                        }
                        else
                        {
                            Application.Current.MainPage.DisplayAlert("Hay una indisponibilidad en la plataforma, por favor intente mas tarde.", "", "Ok");
                        }
                    }
                    else
                    {
                        Application.Current.MainPage.DisplayAlert("Error "+ response.StatusCode.ToString() +":", "  "+ response.ErrorMessage, "Ok");
                    }
                }
                


            }
            catch(Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("Error", "En este momento se presenta una indisponibilidad, por favor intente mas tarde.", "Ok");
            }
        }

        private  Response InsertDataSQLite(List<DataApiModel> data)
        {
            Response re = new Response();
            try
            {
                foreach (var item in data)
                {
                    App.AddDataRepository.AddOrUpdate(item);                    
                }                

            } catch(Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("Error", "En este momento se presenta una indisponibilidad, por favor intente mas tarde.", "Ok");
            }
            return re;
        }

        #endregion
    }
}
