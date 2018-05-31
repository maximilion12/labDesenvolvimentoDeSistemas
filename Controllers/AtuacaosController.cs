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
    public class AtuacaosController : Controller
    {
        private ExercicioLabEntities db = new ExercicioLabEntities();

        // GET: Atuacaos
        public ActionResult Index()
        {
            var atuacao = db.Atuacao.Include(a => a.Ator).Include(a => a.Filme);
            return View(atuacao.ToList());
        }

        // GET: Atuacaos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atuacao atuacao = db.Atuacao.Find(id);
            if (atuacao == null)
            {
                return HttpNotFound();
            }
            return View(atuacao);
        }

        // GET: Atuacaos/Create
        public ActionResult Create()
        {
            ViewBag.idAtor = new SelectList(db.Ator, "id", "nome");
            ViewBag.idFilme = new SelectList(db.Filme, "id", "id");
            return View();
        }

        // POST: Atuacaos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,idAtor,idFilme")] Atuacao atuacao)
        {
            if (ModelState.IsValid)
            {
                db.Atuacao.Add(atuacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idAtor = new SelectList(db.Ator, "id", "nome", atuacao.idAtor);
            ViewBag.idFilme = new SelectList(db.Filme, "id", "id", atuacao.idFilme);
            return View(atuacao);
        }

        // GET: Atuacaos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atuacao atuacao = db.Atuacao.Find(id);
            if (atuacao == null)
            {
                return HttpNotFound();
            }
            ViewBag.idAtor = new SelectList(db.Ator, "id", "nome", atuacao.idAtor);
            ViewBag.idFilme = new SelectList(db.Filme, "id", "id", atuacao.idFilme);
            return View(atuacao);
        }

        // POST: Atuacaos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,idAtor,idFilme")] Atuacao atuacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(atuacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idAtor = new SelectList(db.Ator, "id", "nome", atuacao.idAtor);
            ViewBag.idFilme = new SelectList(db.Filme, "id", "id", atuacao.idFilme);
            return View(atuacao);
        }

        // GET: Atuacaos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atuacao atuacao = db.Atuacao.Find(id);
            if (atuacao == null)
            {
                return HttpNotFound();
            }
            return View(atuacao);
        }

        // POST: Atuacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Atuacao atuacao = db.Atuacao.Find(id);
            db.Atuacao.Remove(atuacao);
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
