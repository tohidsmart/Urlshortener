using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener
{
    using StackExchange.Redis;

    public interface IConfigProvider
    {
        string GetConnectionString();
    }
}
