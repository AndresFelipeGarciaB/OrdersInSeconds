using OrdersInSecondsMovile.Models;
using OrdersInSecondsMovile.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OrdersInSecondsMovile.ViewModels
{
    public class ListProductsViewModel : BaseViewModel
    {
        private DataApiModel _selectedItem;
        #region Commands

        public ObservableCollection<DataApiModel> Items { get; }
        public Command LoadItemsCommand { get; }
        
        public Command<DataApiModel> ItemTapped { get; }
        #endregion

        #region Property
        
        #endregion

        public ListProductsViewModel()
        {
            
            Items = new ObservableCollection<DataApiModel>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<DataApiModel>(OnItemSelected);

            
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                
                var items = App.AddDataRepository.GetAllData(); 
                foreach (var item in items)
                {
                    var itemRating = new RatingModel()
                    {
                        rate = item.rate,
                        count = item.count,
                        starImage = (item.rate >= 4.0 ? "iconStar.png" : String.Empty)
                    };            

                    var itemModel = new DataApiModel() { 
                                title= item.title,
                                price = item.price,
                                description = item.description,
                                category = item.category,
                                image = item.image,
                                rating = itemRating
                    };
                    
                    Items.Add(itemModel);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }
        public DataApiModel SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }


        async void OnItemSelected(DataApiModel item)
        {
            if (item == null)
                return;
            try
            {
                await Shell.Current.GoToAsync($"{nameof(DetailProductsView)}?{nameof(DetailProductsVieModel.Title)}={item.title}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex);
            }  
        }
    }
}
