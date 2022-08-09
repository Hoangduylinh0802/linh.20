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
    public class HoSoesController : Controller
    {
        private QLlutruhosoEntities db = new QLlutruhosoEntities();

        // GET: HoSoes
        public ActionResult Index()
        {
            var hoSoes = db.HoSoes.Include(h => h.NhanVien);
            return View(hoSoes.ToList());
        }

        // GET: HoSoes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoSo hoSo = db.HoSoes.Find(id);
            if (hoSo == null)
            {
                return HttpNotFound();
            }
            return View(hoSo);
        }

        // GET: HoSoes/Create
        public ActionResult Create()
        {
            ViewBag.MSNV = new SelectList(db.NhanViens, "MSNV", "HOTEN");
            return View();
        }

        // POST: HoSoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MSHS,MSNV,TENHS,NgayLapHS,SLHS")] HoSo hoSo)
        {
            if (ModelState.IsValid)
            {
                db.HoSoes.Add(hoSo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MSNV = new SelectList(db.NhanViens, "MSNV", "HOTEN", hoSo.MSNV);
            return View(hoSo);
        }

        // GET: HoSoes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoSo hoSo = db.HoSoes.Find(id);
            if (hoSo == null)
            {
                return HttpNotFound();
            }
            ViewBag.MSNV = new SelectList(db.NhanViens, "MSNV", "HOTEN", hoSo.MSNV);
            return View(hoSo);
        }

        // POST: HoSoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MSHS,MSNV,TENHS,NgayLapHS,SLHS")] HoSo hoSo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoSo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MSNV = new SelectList(db.NhanViens, "MSNV", "HOTEN", hoSo.MSNV);
            return View(hoSo);
        }

        // GET: HoSoes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoSo hoSo = db.HoSoes.Find(id);
            if (hoSo == null)
            {
                return HttpNotFound();
            }
            return View(hoSo);
        }

        // POST: HoSoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HoSo hoSo = db.HoSoes.Find(id);
            db.HoSoes.Remove(hoSo);
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
