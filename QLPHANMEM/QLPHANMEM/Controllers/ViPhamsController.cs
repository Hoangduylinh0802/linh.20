using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLPHANMEM.Models;

namespace QLPHANMEM.Controllers
{
    public class ViPhamsController : Controller
    {
        private QLlutruhosoEntities db = new QLlutruhosoEntities();

        // GET: ViPhams
        public ActionResult Index()
        {
            var viPhams = db.ViPhams.Include(v => v.HoSo);
            return View(viPhams.ToList());
        }

        // GET: ViPhams/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViPham viPham = db.ViPhams.Find(id);
            if (viPham == null)
            {
                return HttpNotFound();
            }
            return View(viPham);
        }

        // GET: ViPhams/Create
        public ActionResult Create()
        {
            ViewBag.MSHS = new SelectList(db.HoSoes, "MSHS", "MSNV");
            return View();
        }

        // POST: ViPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MSVIPHAM,MSHS,TENVIPHAM,SLXEVIPHAM,SOTIENPHAT")] ViPham viPham)
        {
            if (ModelState.IsValid)
            {
                db.ViPhams.Add(viPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MSHS = new SelectList(db.HoSoes, "MSHS", "MSNV", viPham.MSHS);
            return View(viPham);
        }

        // GET: ViPhams/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViPham viPham = db.ViPhams.Find(id);
            if (viPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.MSHS = new SelectList(db.HoSoes, "MSHS", "MSNV", viPham.MSHS);
            return View(viPham);
        }

        // POST: ViPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MSVIPHAM,MSHS,TENVIPHAM,SLXEVIPHAM,SOTIENPHAT")] ViPham viPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(viPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MSHS = new SelectList(db.HoSoes, "MSHS", "MSNV", viPham.MSHS);
            return View(viPham);
        }

        // GET: ViPhams/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViPham viPham = db.ViPhams.Find(id);
            if (viPham == null)
            {
                return HttpNotFound();
            }
            return View(viPham);
        }

        // POST: ViPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ViPham viPham = db.ViPhams.Find(id);
            db.ViPhams.Remove(viPham);
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
