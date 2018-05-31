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
    public class LongaMetragemsController : Controller
    {
        private ExercicioLabEntities db = new ExercicioLabEntities();

        // GET: LongaMetragems
        public ActionResult Index()
        {
            var longaMetragem = db.LongaMetragem.Include(l => l.Filme);
            return View(longaMetragem.ToList());
        }

        // GET: LongaMetragems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LongaMetragem longaMetragem = db.LongaMetragem.Find(id);
            if (longaMetragem == null)
            {
                return HttpNotFound();
            }
            return View(longaMetragem);
        }

        // GET: LongaMetragems/Create
        public ActionResult Create()
        {
            ViewBag.idFilme = new SelectList(db.Filme, "id", "id");
            return View();
        }

        // POST: LongaMetragems/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,idFilme,categoria")] LongaMetragem longaMetragem)
        {
            if (ModelState.IsValid)
            {
                db.LongaMetragem.Add(longaMetragem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idFilme = new SelectList(db.Filme, "id", "id", longaMetragem.idFilme);
            return View(longaMetragem);
        }

        // GET: LongaMetragems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LongaMetragem longaMetragem = db.LongaMetragem.Find(id);
            if (longaMetragem == null)
            {
                return HttpNotFound();
            }
            ViewBag.idFilme = new SelectList(db.Filme, "id", "id", longaMetragem.idFilme);
            return View(longaMetragem);
        }

        // POST: LongaMetragems/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,idFilme,categoria")] LongaMetragem longaMetragem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(longaMetragem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idFilme = new SelectList(db.Filme, "id", "id", longaMetragem.idFilme);
            return View(longaMetragem);
        }

        // GET: LongaMetragems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LongaMetragem longaMetragem = db.LongaMetragem.Find(id);
            if (longaMetragem == null)
            {
                return HttpNotFound();
            }
            return View(longaMetragem);
        }

        // POST: LongaMetragems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LongaMetragem longaMetragem = db.LongaMetragem.Find(id);
            db.LongaMetragem.Remove(longaMetragem);
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
