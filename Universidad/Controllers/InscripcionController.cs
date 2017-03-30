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

namespace Universidad.Controllers
{
    public class InscripcionController : Controller
    {
        private UniversityContext db = new UniversityContext();

        // GET: Inscripcion
        public ActionResult Index()
        {
            var inscripcion = db.Inscripcion.Include(i => i.Curso).Include(i => i.Estudiante).Include(i => i.Profesor);
            return View(inscripcion.ToList());
        }

        // GET: Inscripcion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscripcion inscripcion = db.Inscripcion.Find(id);
            if (inscripcion == null)
            {
                return HttpNotFound();
            }
            return View(inscripcion);
        }

        // GET: Inscripcion/Create
        public ActionResult Create()
        {
            ViewBag.CodigoCurso = new SelectList(db.Curso, "Codigo", "Nombre");
            ViewBag.Matricula = new SelectList(db.Estudiante, "Matricula", "Nombre");
            ViewBag.CedulaProfesor = new SelectList(db.Profesor, "cedula", "Nombre");
            return View();
        }

        // POST: Inscripcion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CedulaProfesor,CodigoCurso,Matricula,Nota")] Inscripcion inscripcion)
        {
            if (ModelState.IsValid)
            {
                db.Inscripcion.Add(inscripcion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodigoCurso = new SelectList(db.Curso, "Codigo", "Nombre", inscripcion.CodigoCurso);
            ViewBag.Matricula = new SelectList(db.Estudiante, "Matricula", "Nombre", inscripcion.Matricula);
            ViewBag.CedulaProfesor = new SelectList(db.Profesor, "cedula", "Nombre", inscripcion.CedulaProfesor);
            return View(inscripcion);
        }

        // GET: Inscripcion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscripcion inscripcion = db.Inscripcion.Find(id);
            if (inscripcion == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodigoCurso = new SelectList(db.Curso, "Codigo", "Nombre", inscripcion.CodigoCurso);
            ViewBag.Matricula = new SelectList(db.Estudiante, "Matricula", "Nombre", inscripcion.Matricula);
            ViewBag.CedulaProfesor = new SelectList(db.Profesor, "cedula", "Nombre", inscripcion.CedulaProfesor);
            return View(inscripcion);
        }

        // POST: Inscripcion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CedulaProfesor,CodigoCurso,Matricula,Nota")] Inscripcion inscripcion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inscripcion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodigoCurso = new SelectList(db.Curso, "Codigo", "Nombre", inscripcion.CodigoCurso);
            ViewBag.Matricula = new SelectList(db.Estudiante, "Matricula", "Nombre", inscripcion.Matricula);
            ViewBag.CedulaProfesor = new SelectList(db.Profesor, "cedula", "Nombre", inscripcion.CedulaProfesor);
            return View(inscripcion);
        }

        // GET: Inscripcion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscripcion inscripcion = db.Inscripcion.Find(id);
            if (inscripcion == null)
            {
                return HttpNotFound();
            }
            return View(inscripcion);
        }

        // POST: Inscripcion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inscripcion inscripcion = db.Inscripcion.Find(id);
            db.Inscripcion.Remove(inscripcion);
            db.SaveChanges();
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
