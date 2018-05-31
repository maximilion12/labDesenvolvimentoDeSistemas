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
    public class DiretorsController : Controller
    {
        private ExercicioLabEntities db = new ExercicioLabEntities();

        // GET: Diretors
        public ActionResult Index()
        {
            return View(db.Diretor.ToList());
        }

        // GET: Diretors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diretor diretor = db.Diretor.Find(id);
            if (diretor == null)
            {
                return HttpNotFound();
            }
            return View(diretor);
        }

        // GET: Diretors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Diretors/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nome,endereço,telefone,email")] Diretor diretor)
        {
            if (ModelState.IsValid)
            {
                db.Diretor.Add(diretor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(diretor);
        }

        // GET: Diretors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diretor diretor = db.Diretor.Find(id);
            if (diretor == null)
            {
                return HttpNotFound();
            }
            return View(diretor);
        }

        // POST: Diretors/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nome,endereço,telefone,email")] Diretor diretor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diretor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(diretor);
        }

        // GET: Diretors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diretor diretor = db.Diretor.Find(id);
            if (diretor == null)
            {
                return HttpNotFound();
            }
            return View(diretor);
        }

        // POST: Diretors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Diretor diretor = db.Diretor.Find(id);
            db.Diretor.Remove(diretor);
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
