using OrdersInSecondsMovile.Models;
using OrdersInSecondsMovile.Utils;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrdersInSecondsMovile.Repositories
{
    public class AddDataRepository
    {
        public string StatusMessage { get; set; }

        SQLiteConnection connection;


        #region Constructor
        public AddDataRepository()
        {
            connection = new SQLiteConnection(Constants.DatabasePath, Constants.Flags);
            connection.CreateTable<DataApiModelSQLite>();
            
        }
        #endregion

        #region Method
        public int AddOrUpdate(DataApiModel data)
        {
            int result = 0;

            try
            {
                if (!Object.ReferenceEquals(null, data))
                {

                    var product = connection.Table<DataApiModelSQLite>().FirstOrDefault(x => x.id == data.id);
                    
                    if (product != null )
                    {
                        if (product.id != data.id
                            || product.title != data.title
                            || product.price != data.price
                            || product.description != data.description
                            || product.category != data.category
                            || product.image != data.image
                            || product.rate != data.rating.rate
                            || product.count != data.rating.count)
                        {
                            var productSQLit = new DataApiModelSQLite
                            {
                                 id = data.id,
                                 title = data.title,
                                 price = data.price,
                                 description = data.description,
                                 category = data.category,
                                 image = data.image,
                                 rate = data.rating.rate,
                                 count = data.rating.count
                            };
                            result = connection.Update(productSQLit);
                            StatusMessage = (result != 0 ? "Se actualizo el producto." : "");
                            
                        }
                        else
                        {
                            StatusMessage = $"Este producto ya existe.";
                        }   
                    }
                    else
                    {
                        var productSQLit = new DataApiModelSQLite
                        {
                            id = data.id,
                            title = data.title,
                            price = data.price,
                            description = data.description,
                            category = data.category,
                            image = data.image,
                            rate = data.rating.rate,
                            count = data.rating.count
                        };
                        result = connection.Insert(productSQLit);
                        StatusMessage = (result != 0 ? "Se Insertó el producto." : "");
                    }
                }
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }

            return result;
        }


        public bool GetAll()
        {
            try
            {
                var data = connection.Table<DataApiModelSQLite>().ToList();
                return (data.Count == 0  ? false : true);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }

            return false;
        }
        public List<DataApiModelSQLite> GetAllData()
        {
            try
            {
                return connection.Table<DataApiModelSQLite>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
            return null ;
        }

        public DataApiModelSQLite GetProduct(string Title)
        {
            try
            {
                return connection.Table<DataApiModelSQLite>().FirstOrDefault(x => x.title == Title);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
            return null;
        }


        #endregion
    }
}
