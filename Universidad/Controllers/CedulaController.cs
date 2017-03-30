using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Universidad.Validacion;

namespace Universidad.Controllers
{
    public class CedulaController : Controller
    {
        // GET: Cedula
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string cedulaPersona) {
            WebService2SoapClient consumoCedula = new WebService2SoapClient();

            if (consumoCedula.ValidarCedula(cedulaPersona) == true)
            {
                ViewBag.Result = "Cédula es válida";
            }
            else
            {
                ViewBag.Result = "Cédula no es válida";
            }
            return View();
        }
    }
}