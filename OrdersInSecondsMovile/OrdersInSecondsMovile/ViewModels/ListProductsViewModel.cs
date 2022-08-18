using OrdersInSecondsMovile.Models;
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
        private DataApiModelSQLite _selectedItem;
        #region Commands

        public ObservableCollection<DataApiModelSQLite> Items { get; }
        public Command LoadItemsCommand { get; }
        
        public Command<DataApiModelSQLite> ItemTapped { get; }
        #endregion

        #region Property
        public DataApiModelSQLite SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }
        #endregion

        public ListProductsViewModel()
        {
            
            Items = new ObservableCollection<DataApiModelSQLite>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<DataApiModelSQLite>(OnItemSelected);

            
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                
                var items = await Task.FromResult(App.AddDataRepository.GetAllData()); ;
                foreach (var item in items)
                {
                    Items.Add(item);
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


        async void OnItemSelected(DataApiModelSQLite item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            //await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }
    }
}
