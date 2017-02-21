using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Universidad.DAL;
using Universidad.Models;
using System.Data.SqlClient;
using PagedList;

namespace Universidad.Controllers
{
    public class EstudianteController : Controller
    {
        private UniversityContext db = new UniversityContext();

        // GET: Estudiante
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if(searchString!= null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var Estudiante = from s in db.Estudiante select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                Estudiante = Estudiante.Where(s => s.Nombre.Contains(searchString) || s.Apellido.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    Estudiante = Estudiante.OrderByDescending(s => s.Nombre);
                    break;
                case "Date":
                    Estudiante = Estudiante.OrderBy(s => s.Fecha_Inscripccion);
                    break;
                case "date_desc":
                    Estudiante = Estudiante.OrderByDescending(s => s.Fecha_Inscripccion);
                    break;
                default:
                    Estudiante = Estudiante.OrderBy(s => s.Nombre);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);        
            return View(Estudiante.ToPagedList(pageNumber, pageSize));
        }

        // GET: Estudiante/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudiante estudiante = db.Estudiante.Find(id);
            if (estudiante == null)
            {
                return HttpNotFound();
            }
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=ABEL-PC;Initial Catalog=Uni2;Integrated Security=True";
                con.Open();

                string query = "select SUM(Creditos) from Estudiantes e inner join Inscripcions i inner join Cursoes c on c.Codigo = i.CodigoCurso on i.Matricula = e.Matricula where e.Matricula = '"+id+"' ";
                SqlCommand cmd = new SqlCommand(query, con);

                int totalCredito = Convert.ToInt32(cmd.ExecuteScalar());
                ViewBag.Credito = totalCredito;
            }
            catch (Exception)
            {

            }
            return View(estudiante);
        }

        // GET: Estudiante/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estudiante/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Matricula,Nombre,Apellido,Correo,Fecha_Inscripccion")] Estudiante estudiante)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Estudiante.Add(estudiante);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }catch(DataException /* dex */)
            {
                //Log error(Uncomment dex to add a log)
                ModelState.AddModelError("", "No se pudo guardar. Intenta de nuevo, si el problema persiste comuníquese con el administrador del sistema");
            }
            return View(estudiante);
        }

        // GET: Estudiante/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudiante estudiante = db.Estudiante.Find(id);
            if (estudiante == null)
            {
                return HttpNotFound();
            }
            return View(estudiante);
        }

        // POST: Estudiante/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var EstudianteEditar = db.Estudiante.Find(id);

            if (TryUpdateModel(EstudianteEditar, "", new string[] { "Matricula", "Nombre", "Apellido", "Correo", "Fecha_Inscripccion" }))
            {
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (DataException)
                {
                    ModelState.AddModelError("", "No se pudo guardar. Intenta de nuevo, si el problema persiste comuníquese con el administrador del sistema");
                }
            }
            return View(EstudianteEditar);
        }

        // GET: Estudiante/Delete/5
        public ActionResult Delete(int? id, bool? guardarError=false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (guardarError.GetValueOrDefault())
            {
                ViewBag.Error = "No se pudo guardar. Intenta de nuevo, si el problema persiste comuníquese con el administrador del sistema";
            }
            Estudiante estudiante = db.Estudiante.Find(id);
            if (estudiante == null)
            {
                return HttpNotFound();
            }
            return View(estudiante);
        }

        // POST: Estudiante/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Estudiante estudiante = db.Estudiante.Find(id);
                db.Estudiante.Remove(estudiante);
                db.SaveChanges();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id, guardarError = true });
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
