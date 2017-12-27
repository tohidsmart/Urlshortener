using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Models;

namespace UrlShortener
{
    public interface IUrlComponent
    {
        UrlModel ShortenUrl(string url);
        UrlModel RetreiveUrl(string encodedUrl);

    }
}
