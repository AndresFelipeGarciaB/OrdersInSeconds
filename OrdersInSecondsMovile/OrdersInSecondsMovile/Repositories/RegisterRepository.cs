using OrdersInSecondsMovile.Models;
using OrdersInSecondsMovile.Utils;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrdersInSecondsMovile.Repositories
{
    public class RegisterRepository
    {
        public string StatusMessage { get; set; }

        SQLiteConnection connection;


        #region Constructor
        public RegisterRepository()
        {
            connection = new SQLiteConnection(Constants.DatabasePath, Constants.Flags);
            connection.CreateTable<UsersModelSQLIT>();
        }
        #endregion

        #region Method
        public int AddOrUpdate(UsersModel users)
        {
            int result = 0;

            try
            {
                if (!string.IsNullOrEmpty(users.user))
                {
                   
                    var userBe= connection.Table<UsersModelSQLIT>().FirstOrDefault(x => x.user == users.user);
                    if(userBe != null) 
                    {                        
                        StatusMessage = $"Este Usuario ya existe por favor registre otro.";
                    }
                    else
                    {
                        var userSQlite = new UsersModelSQLIT()
                        {
                            user = users.user,
                            Pass = users.Pass
                        };
                        result = connection.Insert(userSQlite);
                        StatusMessage = $"{result} Usuario Registrado Correctamente.";
                    }
                }
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }

            return result;
        }

        public UsersModelSQLIT GetUsuario(UsersModel User)
        {
            try
            {
                return connection.Table<UsersModelSQLIT>().FirstOrDefault(x => x.user == User.user  );
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
