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
using Serilog;
using System.IO;

namespace MASEP.Data
{
    public class SqliteDataAccess
    {
        public string ConnectionStringName { get; set; } = "Obs";
        private readonly IConfiguration _config;

        public SqliteDataAccess(IConfiguration config)
        {
            _config = config;
        }
        
        public bool TestConnection()
        {
            string connecitonString = string.Empty;
            connecitonString = _config.GetConnectionString(ConnectionStringName);
            
            //Auth db exists?
            string authConStr = _config.GetConnectionString("Auth");
            string authDbFile = authConStr.Split(";")[0].Replace("Data Source=", "");
            if (!File.Exists(authDbFile))
            {
                Log.Error("DB not found-" + authDbFile);
                return false;
            }
            
            //Obs db exists?
            string obsConStr = _config.GetConnectionString("Obs");
            string obsDbFile = obsConStr.Split(";")[0].Replace("Data Source=", "");
            if (!File.Exists(obsDbFile))
            {
                Log.Error("DB not found-" + obsDbFile);
                return false;
            }

            //if(connecitonString.Split(";")[0].Replace("Data Source=", ""))
            using (IDbConnection connection = new SQLiteConnection(connecitonString))
            {
                try
                {
                    connection.Open();
                    if (connection.State == ConnectionState.Open)
                    {
                        string sql = "Select Count(*) From Meta_Observations";
                        string result = GetDataString<dynamic, dynamic>(sql, new { }, "");
                        return (result == "0" || result == "") ? false : true;
                    }
                    else
                        return false;
                }
                catch (Exception e)
                {
                    Log.Error(e.Message);
                    return false;
                }
            }
        }

        public string GetDataString<T, U>(string sql, U parameters, string? con)
        {
            string connecitonString;
            if (con == "")
                connecitonString = _config.GetConnectionString(ConnectionStringName);
            else
                connecitonString = _config.GetConnectionString(con);

            using (IDbConnection connection = new SQLiteConnection(connecitonString))
            {
                try
                {
                    var data = connection.Query<string>(sql, parameters);
                    if (data.Count() == 0)
                        return "";
                    else
                        return data.FirstOrDefault().ToString();
                }
                catch (Exception e)
                {
                    Log.Error(e.Message);
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
                Log.Error(e.Message);
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
                Log.Error(e.Message);
                return 0;
            }
            return rows;
        }

        public bool ValidateLogin(string username, string password)
        {
            string sql = "Select count(*) From obs_users where Username=@username and Password=@password";
            string result = GetDataString<dynamic, dynamic>(sql, new { @username = username, @password = password }, "Auth");
            return result == "0" ? false : true;
        }
        
        public bool IsRetake(string username)
        {
            string sql = "Select Count(*) From ParticipantsDetail where ParticipantsID=@Username";
            string result = GetDataString<dynamic, dynamic>(sql, new {@Username = username}, "Obs");
            return result == "0" ? false : true;
        }

        public async Task<List<T>> LoadMetaItems<T>(string itemType)
        {
            string sql = "Select * From Meta_Items where ItemType=@itemType order by SortOrder";
            return await LoadData<T, dynamic>(sql, new { @itemType = itemType });
        }

        public Task<List<ObservationModel>> LoadMetaObservations(string filter)
        {
            string sql = string.Empty;
            if (filter != null)
                sql = "Select ObsId,ObsText From Meta_Observations where GrpId=@filter order by SortOrder";
            else
                sql = "Select ObsId,ObsText From Meta_Observations order by SortOrder";

            return LoadData<ObservationModel, dynamic>(sql, new {@filter = filter });
        }
    }
}
