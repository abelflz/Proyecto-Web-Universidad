using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Universidad.Tanda;

namespace Universidad.Controllers
{
    public class TandaController : Controller
    {
        // GET: Tanda
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string Tanda)
        {
            WebService3SoapClient cliente = new WebService3SoapClient();
            ViewBag.Result = cliente.SeleccionTanda(Tanda);
            return View();
        }
    }
}