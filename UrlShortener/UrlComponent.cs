using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UrlShortener.Models;
using System.Numerics;

namespace UrlShortener
{

    public class UrlComponent : IUrlComponent
    {
        private readonly IDataAccessComponent dataComponent;
        private readonly Utility utility;
        public UrlComponent(IDataAccessComponent dataComponent)
        {
            this.dataComponent = dataComponent;
            this.utility = new Utility();
        }
        public UrlModel ShortenUrl(string url)
        {
            var inputUrlModel = new UrlModel();
            inputUrlModel.OriginalUrl = url;
            long number= this.utility.ConvertStringToNumberRepresentation(url);
            string base64Key = utility.Encode(number);
            UrlModel retreiveUrlModel = RetreiveUrl(base64Key);
            string shortenUrl = string.Empty;
            if (!string.IsNullOrEmpty(retreiveUrlModel.OriginalUrl) && inputUrlModel.OriginalUrl == retreiveUrlModel.OriginalUrl)
            {
                shortenUrl = retreiveUrlModel.ShortenUrl;

            }
            else
            {
                shortenUrl = this.dataComponent.SaveShortenUrl(base64Key, url);
            }
            inputUrlModel.ShortenUrl = shortenUrl;
            return inputUrlModel;
        }

        public UrlModel RetreiveUrl(string shortenUrl)
        {
            UrlModel urlModel = new UrlModel();
            urlModel.ShortenUrl = shortenUrl;
            string originalUrl = this.dataComponent.RetreiveShortenUrl(shortenUrl);
            if (!string.IsNullOrEmpty(originalUrl))
            {
                urlModel.OriginalUrl = originalUrl;
            }
            return urlModel;
        }
    }
}