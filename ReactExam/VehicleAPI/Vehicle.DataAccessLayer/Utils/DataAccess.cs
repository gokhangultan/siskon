using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Vehicle.DataAccessLayer.Utils
{
    public interface IDataAccess
    {
        SqlConnection CreateConnection();
    }
    public class DataAccess : IDataAccess
    {
        private readonly string _conString;

        public DataAccess(IOptions<AppSettings> appSettings)
        {
            this._conString = appSettings.Value.MasterConnectionString;
        }

        public SqlConnection CreateConnection()
        {
            var connection = new SqlConnection(this._conString);
            connection.Open();
            return connection;
        }

    }
}
