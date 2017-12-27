using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UrlShortener.Models
{
    public class UrlModel
    {
        public string OriginalUrl { get; set; }
        public string ShortenUrl { get; set; }
        public string ShortenRedirectUrl { get; set; }
    }
}