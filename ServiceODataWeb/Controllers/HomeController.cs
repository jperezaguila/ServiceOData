using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServiceODataWeb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var serviceUri = new Uri(ConfigurationManager.AppSettings["ODataUri"]);
            var context = new ServiceReference1.TallerEntities(serviceUri);
            var query = from p in context.Clientes.Expand("Vehiculos") select p;
            var result = query.ToList();
            return View(result);
        }
    }
}