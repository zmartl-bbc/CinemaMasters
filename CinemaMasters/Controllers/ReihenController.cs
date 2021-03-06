﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CinemaMasters.Models;

namespace CinemaMasters.Controllers
{
    public class ReihenController : Controller
    {
        private CinemaMastersEntities db = new CinemaMastersEntities();

        // GET: Reihen
        public ActionResult Index()
        {
            var reihe = db.Reihe.Include(r => r.Kinosaal);
            return View(reihe.ToList());
        }

        // GET: Reihen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reihe reihe = db.Reihe.Find(id);
            if (reihe == null)
            {
                return HttpNotFound();
            }
            return View(reihe);
        }

        // GET: Reihen/Create
        public ActionResult Create()
        {
            ViewBag.KinosaalId = new SelectList(db.Kinosaal, "Id", "Name");
            return View();
        }

        // POST: Reihen/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,KinosaalId,Reihennummer")] Reihe reihe)
        {
            if (ModelState.IsValid)
            {
                db.Reihe.Add(reihe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KinosaalId = new SelectList(db.Kinosaal, "Id", "Name", reihe.KinosaalId);
            return View(reihe);
        }

        // GET: Reihen/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reihe reihe = db.Reihe.Find(id);
            if (reihe == null)
            {
                return HttpNotFound();
            }
            ViewBag.KinosaalId = new SelectList(db.Kinosaal, "Id", "Name", reihe.KinosaalId);
            return View(reihe);
        }

        // POST: Reihen/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,KinosaalId,Reihennummer")] Reihe reihe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reihe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KinosaalId = new SelectList(db.Kinosaal, "Id", "Name", reihe.KinosaalId);
            return View(reihe);
        }

        // GET: Reihen/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reihe reihe = db.Reihe.Find(id);
            if (reihe == null)
            {
                return HttpNotFound();
            }
            return View(reihe);
        }

        // POST: Reihen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reihe reihe = db.Reihe.Find(id);
            db.Reihe.Remove(reihe);
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
