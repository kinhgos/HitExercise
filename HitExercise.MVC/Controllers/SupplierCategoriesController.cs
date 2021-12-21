using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HitExercise.DataAccess.Core.Entities;
using HitExercise.DataAccess.Persistence;

namespace HitExercise.MVC.Controllers
{
    [Authorize]
    public class SupplierCategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SupplierCategories
        public ActionResult Index()
        {
            return View(db.SupplierCategories.ToList());
        }

        // GET: SupplierCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupplierCategory supplierCategory = db.SupplierCategories.Find(id);
            if (supplierCategory == null)
            {
                return HttpNotFound();
            }
            return View(supplierCategory);
        }

        // GET: SupplierCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SupplierCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title")] SupplierCategory supplierCategory)
        {
            if (ModelState.IsValid)
            {
                db.SupplierCategories.Add(supplierCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(supplierCategory);
        }

        // GET: SupplierCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupplierCategory supplierCategory = db.SupplierCategories.Find(id);
            if (supplierCategory == null)
            {
                return HttpNotFound();
            }
            return View(supplierCategory);
        }

        // POST: SupplierCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title")] SupplierCategory supplierCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supplierCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(supplierCategory);
        }

        // GET: SupplierCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupplierCategory supplierCategory = db.SupplierCategories.Find(id);
            if (supplierCategory == null)
            {
                return HttpNotFound();
            }
            return View(supplierCategory);
        }

        // POST: SupplierCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SupplierCategory supplierCategory = db.SupplierCategories.Find(id);
            db.SupplierCategories.Remove(supplierCategory);
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
