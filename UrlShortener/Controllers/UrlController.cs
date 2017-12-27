using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UrlShortener.Models;
using System;

namespace UrlShortener.Controllers
{

    [RoutePrefix("api")]
    public class UrlController : ApiController
    {
        private string IP => ((HttpContextWrapper)Request.Properties["MS_HttpContext"]).Request.UserHostAddress;
        private string Host => ((HttpContextWrapper)Request.Properties["MS_HttpContext"]).Request.Url.Host;
        private int Port => ((HttpContextWrapper)Request.Properties["MS_HttpContext"]).Request.Url.Port;

        private string Protocol => (((HttpContextWrapper)Request.Properties["MS_HttpContext"]).Request.Url.Scheme == Uri.UriSchemeHttps) ? "https" : "http";

        public UrlController()
        {

        }
        private IUrlComponent urlComponent;
        public UrlController(IUrlComponent urlComponent)
        {
            this.urlComponent = urlComponent;
        }


        [Route("UrlShrinker")]
        [HttpGet]
        public HttpResponseMessage Get(string shortenUrl)
        {
            var originalUrlModel = urlComponent.RetreiveUrl(shortenUrl);
            if (string.IsNullOrEmpty(originalUrlModel.OriginalUrl))
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, shortenUrl);
            }
            return Request.CreateResponse(HttpStatusCode.Accepted, originalUrlModel);
        }

        [Route("UrlShrinker")]
        [HttpPost]
        public UrlModel Post([FromBody]string url)
        {
            var shortenUrlModel = urlComponent.ShortenUrl(url);
            shortenUrlModel.ShortenRedirectUrl = $"{Protocol}://{Host}:{Port}/{shortenUrlModel.ShortenUrl}";
            return shortenUrlModel;
        }






    }
}