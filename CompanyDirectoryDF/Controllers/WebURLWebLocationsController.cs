using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CompanyDirectoryDF.Models;

namespace CompanyDirectoryDF.Controllers
{
    public class WebURLWebLocationsController : Controller
    {
        private CompanyDirectoryDFEntities db = new CompanyDirectoryDFEntities();

        // GET: WebURLWebLocations
        public ActionResult Index()
        {
            int directoryId = 1;// Just defaults to Eagletm for now. 
            var webURLWebLocations = db.WebURLWebLocations.Include(w => w.Directory).Include(w => w.WebLocation).Include(w => w.WebURL);
            return View(webURLWebLocations.ToList());
        }

        // GET: WebURLWebLocations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WebURLWebLocation webURLWebLocation = db.WebURLWebLocations.Find(id);
            if (webURLWebLocation == null)
            {
                return HttpNotFound();
            }
            return View(webURLWebLocation);
        }

        // GET: WebURLWebLocations/Create
        public ActionResult Create()
        {
            ViewBag.DirectoryID = new SelectList(db.Directories, "ID", "Name");
            ViewBag.WebLocationID = new SelectList(db.WebLocations, "ID", "Location");
            ViewBag.WebURLID = new SelectList(db.WebURLs, "ID", "URL");
            return View();
        }

        // POST: WebURLWebLocations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WebLocationID,WebURLID,DirectoryID,ID")] WebURLWebLocation webURLWebLocation)
        {
            if (ModelState.IsValid)
            {
                db.WebURLWebLocations.Add(webURLWebLocation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DirectoryID = new SelectList(db.Directories, "ID", "Name", webURLWebLocation.DirectoryID);
            ViewBag.WebLocationID = new SelectList(db.WebLocations, "ID", "Location", webURLWebLocation.WebLocationID);
            ViewBag.WebURLID = new SelectList(db.WebURLs, "ID", "URL", webURLWebLocation.WebURLID);
            return View(webURLWebLocation);
        }

        // GET: WebURLWebLocations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WebURLWebLocation webURLWebLocation = db.WebURLWebLocations.Find(id);
            if (webURLWebLocation == null)
            {
                return HttpNotFound();
            }
            ViewBag.DirectoryID = new SelectList(db.Directories, "ID", "Name", webURLWebLocation.DirectoryID);
            ViewBag.WebLocationID = new SelectList(db.WebLocations, "ID", "Location", webURLWebLocation.WebLocationID);
            ViewBag.WebURLID = new SelectList(db.WebURLs, "ID", "URL", webURLWebLocation.WebURLID);
            return View(webURLWebLocation);
        }

        // POST: WebURLWebLocations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WebLocationID,WebURLID,DirectoryID,ID")] WebURLWebLocation webURLWebLocation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(webURLWebLocation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DirectoryID = new SelectList(db.Directories, "ID", "Name", webURLWebLocation.DirectoryID);
            ViewBag.WebLocationID = new SelectList(db.WebLocations, "ID", "Location", webURLWebLocation.WebLocationID);
            ViewBag.WebURLID = new SelectList(db.WebURLs, "ID", "URL", webURLWebLocation.WebURLID);
            return View(webURLWebLocation);
        }

        // GET: WebURLWebLocations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WebURLWebLocation webURLWebLocation = db.WebURLWebLocations.Find(id);
            if (webURLWebLocation == null)
            {
                return HttpNotFound();
            }
            return View(webURLWebLocation);
        }

        // POST: WebURLWebLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WebURLWebLocation webURLWebLocation = db.WebURLWebLocations.Find(id);
            db.WebURLWebLocations.Remove(webURLWebLocation);
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
