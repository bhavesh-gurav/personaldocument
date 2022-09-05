using LabourCommissioner.Abstraction.DataModels;
using LabourCommissioner.Abstraction.Repositories;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabourCommissioner.DataRepository.Repositories
{
    public class BaseRepository<T>:IBaseRepository<T> where T : BaseDataTableEntity
    {
        IConfiguration appConfig;
        public BaseRepository(IConfiguration config)
        {
            appConfig = config;
        }

        //protected IDbConnection GetConnection()
        //{
        //    return new MySqlConnection(appConfig.GetConnectionString("LabourCommissioner")); 
        //}
        protected NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(appConfig.GetConnectionString("LabourCommissioner"));
        }
    }

}
