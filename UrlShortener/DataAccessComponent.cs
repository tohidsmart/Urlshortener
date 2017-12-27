using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Data.SqlClient;
using System.Data;

namespace UrlShortener
{
    public class DataAccessComponent : IDataAccessComponent
    {
        private readonly string _connectionString;

        public DataAccessComponent(IConfigProvider configProvider)
        {
            _connectionString = configProvider.GetConnectionString();
        }

        public string SaveShortenUrl(string key, string url)
        {
            var shortenUrl = string.Empty;
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var parameter = new
                {
                    ShortenUrl = key,
                    OriginalUrl = url
                };
                shortenUrl = sqlConnection.Query<string>("[dbo].[InsertShortenUrl]", parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            return shortenUrl;
        }

        public string RetreiveShortenUrl(string key)
        {
            var shortenUrl = string.Empty;
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                shortenUrl = sqlConnection.Query<string>("[dbo].[GetShortenUrl]", new { ShortenUrl = key }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            return shortenUrl;
        }
    }
}
