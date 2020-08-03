using Dapper;
using Microsoft.Extensions.Configuration;
using OBSCompents.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace MASEP.Data
{
    public class SqliteDataAccess
    {
        public string ConnectionStringName { get; set; } = "Default";
        private readonly IConfiguration _config;

        public SqliteDataAccess(IConfiguration config)
        {
            _config = config;
        }
        public string GetDataString<T, U>(string sql, U parameters)
        {
            string connecitonString = _config.GetConnectionString(ConnectionStringName);
            using (IDbConnection connection = new SQLiteConnection(connecitonString))
            {
                try
                {
                    var data = connection.Query<string>(sql, parameters);
                    return data.First().ToString();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return "";
                }
            }
        }

        public async Task<List<T>> LoadData<T, U>(string sql, U parameters)
        {
            try
            {
                string connectionString = _config.GetConnectionString(ConnectionStringName);
                using (IDbConnection connection = new SQLiteConnection(connectionString))
                {
                    var data = await connection.QueryAsync<T>(sql, parameters);
                    return data.ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }

        public int SaveData<T>(string sql, T parameters)
        {
            int rows = 0;
            try
            {
                string connecitonString = _config.GetConnectionString(ConnectionStringName);
                using (IDbConnection connection = new SQLiteConnection(connecitonString))
                {
                    rows = connection.Execute(sql, parameters);
                }
            }
            catch (Exception e)
            {

                //Console.WriteLine(e.Message);
                return 0;
            }
            return rows;
        }
        
        #region Login

        //public int InsertUser(LoginModel login)
        //{
        //    string sql = @"Insert into obs_users(Username,Password)
        //                    Values(@Username,@Password);";

        //    return SaveData(sql, login);
        //}

        public bool ValidateLogin(string username, string password)
        {
            string sql = "Select count(*) From obs_users where Username='" + username + "' and Password='" + password + "'";
            string result = GetDataString<dynamic, dynamic>(sql, new { });
            return result == "0" ? false : true;

        }

        #endregion

        public async Task<List<T>> LoadMetaItems<T>(string itemType)
        {
            string sql = "Select * From Meta_Items where ItemType='" + itemType + "' order by SortOrder";
            return await LoadData<T, dynamic>(sql, new { });
        }
        public Task<List<ObservationModel>> LoadMetaObservations(string filter)
        {
            string sql = string.Empty;
            if (filter != null)
                sql = "Select ObsId,ObsText From Meta_Observations where GrpId =" + filter+ " order by SortOrder";
            else
                sql = "Select ObsId,ObsText From Meta_Observations order by SortOrder";

            return LoadData<ObservationModel, dynamic>(sql, new { });
        }
    }
}
