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
    public class FilmesController : Controller
    {
        private ExercicioLabEntities db = new ExercicioLabEntities();

        // GET: Filmes
        public ActionResult Index()
        {
            var filme = db.Filme.Include(f => f.Diretor).Include(f => f.Documentario).Include(f => f.Produtor);
            return View(filme.ToList());
        }

        // GET: Filmes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filme filme = db.Filme.Find(id);
            if (filme == null)
            {
                return HttpNotFound();
            }
            return View(filme);
        }

        // GET: Filmes/Create
        public ActionResult Create()
        {
            ViewBag.idDireto = new SelectList(db.Diretor, "id", "nome");
            ViewBag.id = new SelectList(db.Documentario, "id", "assunto");
            ViewBag.idProdutor = new SelectList(db.Produtor, "id", "nome");
            return View();
        }

        // POST: Filmes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,verba,dtGravacaoInicio,dtGravacaoFim,idDireto,idProdutor")] Filme filme)
        {
            if (ModelState.IsValid)
            {
                db.Filme.Add(filme);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idDireto = new SelectList(db.Diretor, "id", "nome", filme.idDireto);
            ViewBag.id = new SelectList(db.Documentario, "id", "assunto", filme.id);
            ViewBag.idProdutor = new SelectList(db.Produtor, "id", "nome", filme.idProdutor);
            return View(filme);
        }

        // GET: Filmes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filme filme = db.Filme.Find(id);
            if (filme == null)
            {
                return HttpNotFound();
            }
            ViewBag.idDireto = new SelectList(db.Diretor, "id", "nome", filme.idDireto);
            ViewBag.id = new SelectList(db.Documentario, "id", "assunto", filme.id);
            ViewBag.idProdutor = new SelectList(db.Produtor, "id", "nome", filme.idProdutor);
            return View(filme);
        }

        // POST: Filmes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,verba,dtGravacaoInicio,dtGravacaoFim,idDireto,idProdutor")] Filme filme)
        {
            if (ModelState.IsValid)
            {
                db.Entry(filme).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idDireto = new SelectList(db.Diretor, "id", "nome", filme.idDireto);
            ViewBag.id = new SelectList(db.Documentario, "id", "assunto", filme.id);
            ViewBag.idProdutor = new SelectList(db.Produtor, "id", "nome", filme.idProdutor);
            return View(filme);
        }

        // GET: Filmes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filme filme = db.Filme.Find(id);
            if (filme == null)
            {
                return HttpNotFound();
            }
            return View(filme);
        }

        // POST: Filmes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Filme filme = db.Filme.Find(id);
            db.Filme.Remove(filme);
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
