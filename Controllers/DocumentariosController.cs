using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Exercicio.Models;

namespace Exercicio.Controllers
{
    public class DocumentariosController : Controller
    {
        private ExercicioLabEntities db = new ExercicioLabEntities();

        // GET: Documentarios
        public ActionResult Index()
        {
            var documentario = db.Documentario.Include(d => d.Filme);
            return View(documentario.ToList());
        }

        // GET: Documentarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Documentario documentario = db.Documentario.Find(id);
            if (documentario == null)
            {
                return HttpNotFound();
            }
            return View(documentario);
        }

        // GET: Documentarios/Create
        public ActionResult Create()
        {
            ViewBag.id = new SelectList(db.Filme, "id", "id");
            return View();
        }

        // POST: Documentarios/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,idFilme,assunto")] Documentario documentario)
        {
            if (ModelState.IsValid)
            {
                db.Documentario.Add(documentario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id = new SelectList(db.Filme, "id", "id", documentario.id);
            return View(documentario);
        }

        // GET: Documentarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Documentario documentario = db.Documentario.Find(id);
            if (documentario == null)
            {
                return HttpNotFound();
            }
            ViewBag.id = new SelectList(db.Filme, "id", "id", documentario.id);
            return View(documentario);
        }

        // POST: Documentarios/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,idFilme,assunto")] Documentario documentario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(documentario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id = new SelectList(db.Filme, "id", "id", documentario.id);
            return View(documentario);
        }

        // GET: Documentarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Documentario documentario = db.Documentario.Find(id);
            if (documentario == null)
            {
                return HttpNotFound();
            }
            return View(documentario);
        }

        // POST: Documentarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Documentario documentario = db.Documentario.Find(id);
            db.Documentario.Remove(documentario);
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
