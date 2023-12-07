using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mvc_entity.Models;

namespace mvc_entity.Controllers
{
    public class tb_jogadorController : Controller
    {
        private webappcarEntities db = new webappcarEntities();

        // GET: tb_jogador
        public ActionResult Index()
        {
            var tb_jogador = db.tb_jogador.Include(t => t.tb_times);
            return View(tb_jogador.ToList());
        }

        // GET: tb_jogador/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_jogador tb_jogador = db.tb_jogador.Find(id);
            if (tb_jogador == null)
            {
                return HttpNotFound();
            }
            return View(tb_jogador);
        }

        // GET: tb_jogador/Create
        public ActionResult Create()
        {
            ViewBag.time_jogador = new SelectList(db.tb_times, "id_time", "nome_time");
            return View();
        }

        // POST: tb_jogador/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_jogador,time_jogador,nome_jogador")] tb_jogador tb_jogador)
        {
            if (ModelState.IsValid)
            {
                db.tb_jogador.Add(tb_jogador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.time_jogador = new SelectList(db.tb_times, "id_time", "nome_time", tb_jogador.time_jogador);
            return View(tb_jogador);
        }

        // GET: tb_jogador/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_jogador tb_jogador = db.tb_jogador.Find(id);
            if (tb_jogador == null)
            {
                return HttpNotFound();
            }
            ViewBag.time_jogador = new SelectList(db.tb_times, "id_time", "nome_time", tb_jogador.time_jogador);
            return View(tb_jogador);
        }

        // POST: tb_jogador/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_jogador,time_jogador,nome_jogador")] tb_jogador tb_jogador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_jogador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.time_jogador = new SelectList(db.tb_times, "id_time", "nome_time", tb_jogador.time_jogador);
            return View(tb_jogador);
        }

        // GET: tb_jogador/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_jogador tb_jogador = db.tb_jogador.Find(id);
            if (tb_jogador == null)
            {
                return HttpNotFound();
            }
            return View(tb_jogador);
        }

        // POST: tb_jogador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_jogador tb_jogador = db.tb_jogador.Find(id);
            db.tb_jogador.Remove(tb_jogador);
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
