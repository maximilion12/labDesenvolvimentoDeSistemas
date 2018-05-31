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
    public class ProdutorsController : Controller
    {
        private ExercicioLabEntities db = new ExercicioLabEntities();

        // GET: Produtors
        public ActionResult Index()
        {
            return View(db.Produtor.ToList());
        }

        // GET: Produtors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produtor produtor = db.Produtor.Find(id);
            if (produtor == null)
            {
                return HttpNotFound();
            }
            return View(produtor);
        }

        // GET: Produtors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produtors/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nome,email,telefone")] Produtor produtor)
        {
            if (ModelState.IsValid)
            {
                db.Produtor.Add(produtor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(produtor);
        }

        // GET: Produtors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produtor produtor = db.Produtor.Find(id);
            if (produtor == null)
            {
                return HttpNotFound();
            }
            return View(produtor);
        }

        // POST: Produtors/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nome,email,telefone")] Produtor produtor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produtor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produtor);
        }

        // GET: Produtors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produtor produtor = db.Produtor.Find(id);
            if (produtor == null)
            {
                return HttpNotFound();
            }
            return View(produtor);
        }

        // POST: Produtors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produtor produtor = db.Produtor.Find(id);
            db.Produtor.Remove(produtor);
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
