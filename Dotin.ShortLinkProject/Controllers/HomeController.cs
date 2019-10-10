using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Dotin.ShortLinkProject.Business.BusinessHandler;
using Dotin.ShortLinkProject.Common.DtoModel;
using Newtonsoft.Json;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;

namespace Dotin.ShortLinkProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult NotFound()
        {
            ViewBag.Title = "404 Not Found";

            return View();
        }
        [HttpPost]
        public string GenerateCode(string url)
        {
            UrlHandler handler = new UrlHandler();
            string ip = Request.UserHostAddress;
            UrlModelDto dtoModel = new UrlModelDto()
            {
                MainLink = url,
                CreateIp = ip
            };
            string code = handler.GenerateCode(dtoModel);
            if (handler.HasException)
            {
                var message = string.Format("Error in Server");
                HttpError err = new HttpError(message);
                return JsonConvert.SerializeObject(err);
            }
            else
            {
                return code;
            }
        }
        [HttpGet]
        public RedirectResult RedirectLink(string code)
        {
            if (code == null)
            {
                return Redirect("NotFound");
            }
            UrlHandler urlHandler = new UrlHandler();
            UrlModelDto url = urlHandler.GetUrlAddress(code);
            return Redirect(url != null ? url.MainLink : code);
        }

    }
}
