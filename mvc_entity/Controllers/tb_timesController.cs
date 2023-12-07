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
    public class tb_timesController : Controller
    {
        private webappcarEntities db = new webappcarEntities();

        // GET: tb_times
        public ActionResult Index()
        {
            return View(db.tb_times.ToList());
        }

        // GET: tb_times/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_times tb_times = db.tb_times.Find(id);
            if (tb_times == null)
            {
                return HttpNotFound();
            }
            return View(tb_times);
        }

        // GET: tb_times/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tb_times/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_time,nome_time,qtd_jogadores")] tb_times tb_times)
        {
            if (ModelState.IsValid)
            {
                db.tb_times.Add(tb_times);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_times);
        }

        // GET: tb_times/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_times tb_times = db.tb_times.Find(id);
            if (tb_times == null)
            {
                return HttpNotFound();
            }
            return View(tb_times);
        }

        // POST: tb_times/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_time,nome_time,qtd_jogadores")] tb_times tb_times)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_times).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_times);
        }

        // GET: tb_times/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_times tb_times = db.tb_times.Find(id);
            if (tb_times == null)
            {
                return HttpNotFound();
            }
            return View(tb_times);
        }

        // POST: tb_times/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_times tb_times = db.tb_times.Find(id);
            db.tb_times.Remove(tb_times);
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
