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
    public class PhoneListsController : Controller
    {
        private CompanyDirectoryDFEntities db = new CompanyDirectoryDFEntities();

        // GET: PhoneLists
        public ActionResult Index()
        {
            var phoneLists = db.PhoneLists.Include(p => p.Directory).Include(p => p.Employee).Include(p => p.PhoneListName);
            return View(phoneLists.ToList());
        }

        // GET: PhoneLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhoneList phoneList = db.PhoneLists.Find(id);
            if (phoneList == null)
            {
                return HttpNotFound();
            }
            return View(phoneList);
        }

        // GET: PhoneLists/Create
        public ActionResult Create()
        {
            ViewBag.DirectoryID = new SelectList(db.Directories, "ID", "Name");
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "FirstName");
            ViewBag.PhoneListNameID = new SelectList(db.PhoneListNames, "ID", "Name");
            return View();
        }

        // POST: PhoneLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PhoneListNameID,EmployeeID,DirectoryID")] PhoneList phoneList)
        {
            if (ModelState.IsValid)
            {
                db.PhoneLists.Add(phoneList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DirectoryID = new SelectList(db.Directories, "ID", "Name", phoneList.DirectoryID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "FirstName", phoneList.EmployeeID);
            ViewBag.PhoneListNameID = new SelectList(db.PhoneListNames, "ID", "Name", phoneList.PhoneListNameID);
            return View(phoneList);
        }

        // GET: PhoneLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhoneList phoneList = db.PhoneLists.Find(id);
            if (phoneList == null)
            {
                return HttpNotFound();
            }
            ViewBag.DirectoryID = new SelectList(db.Directories, "ID", "Name", phoneList.DirectoryID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "FirstName", phoneList.EmployeeID);
            ViewBag.PhoneListNameID = new SelectList(db.PhoneListNames, "ID", "Name", phoneList.PhoneListNameID);
            return View(phoneList);
        }

        // POST: PhoneLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PhoneListNameID,EmployeeID,DirectoryID")] PhoneList phoneList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phoneList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DirectoryID = new SelectList(db.Directories, "ID", "Name", phoneList.DirectoryID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "FirstName", phoneList.EmployeeID);
            ViewBag.PhoneListNameID = new SelectList(db.PhoneListNames, "ID", "Name", phoneList.PhoneListNameID);
            return View(phoneList);
        }

        // GET: PhoneLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhoneList phoneList = db.PhoneLists.Find(id);
            if (phoneList == null)
            {
                return HttpNotFound();
            }
            return View(phoneList);
        }

        // POST: PhoneLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhoneList phoneList = db.PhoneLists.Find(id);
            db.PhoneLists.Remove(phoneList);
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
