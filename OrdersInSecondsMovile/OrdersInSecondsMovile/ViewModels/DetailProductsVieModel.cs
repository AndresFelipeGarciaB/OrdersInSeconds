using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace OrdersInSecondsMovile.ViewModels
{
    [QueryProperty(nameof(Id), nameof(Id))]
    public class DetailProductsVieModel :BaseViewModel
    {
        #region property
        private int id;
        public int  Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                LoadItemId(value);
            }
        }


       private string nameProduct;

        public string NameProduct
        {
            get => image;
            set => SetProperty(ref image, value);
        }

        private string image;

        public string Image
        {
            get => image;
            set => SetProperty(ref image, value);
        }

        private string price;
        public string Price
        {
            get => price;
            set => SetProperty(ref price, value);
        }

        public string categoria; 
        public string Categoria
        {
            get => categoria;
            set => SetProperty(ref categoria, value);
        }

        private string rating;
        public string Rating
        {
            get => rating;
            set => SetProperty(ref rating, value);
        }
       


        #endregion
        #region constructor
        public async void LoadItemId(int id)
        {
            try
            {
                var items = App.AddDataRepository.GetProduct(id);
                NameProduct = items.title;
                Image = items.image;
                Price = items.price.ToString();
                Categoria = items.category.ToString();
                Rating = items.rate.ToString();

            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        
        }
        #endregion
    }
}
