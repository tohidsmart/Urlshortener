using System.Web.Mvc;
using UrlShortener.Models;

namespace UrlShortener.Controllers
{
    public class HomeController : Controller
    {
        private IDataAccessComponent _dataAccessComponent;
        private IUrlComponent _urlComponent;
        private IConfigProvider _configProvider;

        public HomeController()
        {
            _configProvider = new ConfigProvider();
            _dataAccessComponent = new DataAccessComponent(_configProvider);
            _urlComponent = new UrlComponent(_dataAccessComponent);
        }
        public HomeController(IDataAccessComponent dataAccessComponent, IUrlComponent urlComponent)
        {
            _dataAccessComponent = dataAccessComponent;
            _urlComponent = urlComponent;
        }

        
        public ActionResult Index(string shortUrl)
        {
            if (string.IsNullOrEmpty(shortUrl))
            {
                return View();
            }
            UrlModel urlModel = _urlComponent.RetreiveUrl(shortUrl);

            return Redirect(urlModel.OriginalUrl);
        }


    }
}
