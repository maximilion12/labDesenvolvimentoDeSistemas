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
    public class AtorsController : Controller
    {
        private ExercicioLabEntities db = new ExercicioLabEntities();

        // GET: Ators
        public ActionResult Index()
        {
            return View(db.Ator.ToList());
        }

        // GET: Ators/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ator ator = db.Ator.Find(id);
            if (ator == null)
            {
                return HttpNotFound();
            }
            return View(ator);
        }

        // GET: Ators/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ators/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nome,email,telefone")] Ator ator)
        {
            if (ModelState.IsValid)
            {
                db.Ator.Add(ator);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ator);
        }

        // GET: Ators/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ator ator = db.Ator.Find(id);
            if (ator == null)
            {
                return HttpNotFound();
            }
            return View(ator);
        }

        // POST: Ators/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nome,email,telefone")] Ator ator)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ator).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ator);
        }

        // GET: Ators/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ator ator = db.Ator.Find(id);
            if (ator == null)
            {
                return HttpNotFound();
            }
            return View(ator);
        }

        // POST: Ators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ator ator = db.Ator.Find(id);
            db.Ator.Remove(ator);
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
