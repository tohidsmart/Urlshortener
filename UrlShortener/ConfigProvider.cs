using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UrlShortener
{
    using System.Configuration;
    using StackExchange.Redis;

    public class ConfigProvider : IConfigProvider
    {

      

      

        public string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["UrlDatabase"].ConnectionString;
        }



    }
}