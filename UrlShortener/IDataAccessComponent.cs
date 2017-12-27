using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener
{
    public interface IDataAccessComponent
    {
        string SaveShortenUrl(string key, string value);
        string RetreiveShortenUrl(string key);
    }
}
