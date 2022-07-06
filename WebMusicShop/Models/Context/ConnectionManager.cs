﻿using System.Data.SqlClient;
using WebMusicShop.Models.Interfaces;

namespace WebMusicShop.Models.Context
{
    public class ConnectionManager : IConnectionManager
    {
        public static string _connStrName;
        private static SqlConnection connection;

        public ConnectionManager(IConfiguration configuration)
        {
            var connStr = configuration.GetConnectionString(_connStrName);
            connection = new SqlConnection(connStr);
        }

        public SqlConnection GetConnection(string connStrName)
        {
            _connStrName = connStrName;
            return connection;
        }
    }
}
