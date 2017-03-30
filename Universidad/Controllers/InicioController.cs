using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Universidad.Controllers
{
    public class InicioController : Controller
    {
        // GET: Inicio
        public ActionResult Index()
        {
            return View("Index");
        }
        [HttpPost]
        [ActionName("Index")]
        public ActionResult IndexPost(string cuenta, string clave) {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=ABEL-PC;Initial Catalog=Uni2;Integrated Security=True";
            con.Open();

            string query = "select COUNT(USERNAME) from LOGIN where USERNAME = '" + cuenta + "' and PASSWORD = '" + clave + "'";
            SqlCommand cmd = new SqlCommand(query, con);

            int verificar = Convert.ToInt32(cmd.ExecuteScalar());

            if (string.IsNullOrEmpty(cuenta) || string.IsNullOrEmpty(clave))
            {
                ViewBag.User = "Debe llenar todos los campos";
                con.Close();
                return View("~/Views/Shared/Error.cshtml");
            }
            else
            {
                if (verificar == 0)
                {
                    ViewBag.User = "Contraseña o usuario erróneo";
                    con.Close();
                    return View("~/Views/Shared/Error.cshtml");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
        }
    }
}