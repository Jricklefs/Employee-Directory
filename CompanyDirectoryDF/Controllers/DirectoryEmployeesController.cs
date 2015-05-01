using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CompanyDirectoryDF.Models;
using CompanyDirectoryDF.ViewModel;

namespace CompanyDirectoryDF.Controllers
{
    public class DirectoryEmployeesController : Controller
    {
        private CompanyDirectoryDFEntities db = new CompanyDirectoryDFEntities();


        // GET: DirectoryEmployees
        public ActionResult Index()
        {
            int directoryId = 1;// Just defaults to Eagletm for now. 

            var viewModel = new DirectoryIndexViewModel();
            
            viewModel.DirectoryEmployees = db.DirectoryEmployees
                .Include(d => d.Directory)
                .Include(d => d.Employee)
                .Where(c => c.DirectoryID == directoryId);
            viewModel.Address = db.Addresses
                .First(a => a.DirectoryID == directoryId);
            //viewModel.Departments = db.Departments
            //    .Include(x => x.Directory)
            //    .Where(c => c.DirectoryID == directoryId);
            //viewModel.PhoneLists = db.PhoneLists.Include(p => p.Employee)
            //    .Include(p => p.Directory)
            //    .Include(p => p.PhoneListTypeID)
            //    .Where(c => c.DirectoryID == directoryId);
            //viewModel.WebURLWebLocations = db.WebURLWebLocations
            //    .Include(p => p.WebURL)
            //    .Include(p => p.WebLocation)
            //    .Include(p => p.Directory)
            //    .Where(c => c.DirectoryID == directoryId);

            return View(viewModel);
        }

        // GET: DirectoryEmployees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DirectoryEmployee directoryEmployee = db.DirectoryEmployees.Find(id);
            if (directoryEmployee == null)
            {
                return HttpNotFound();
            }
            return View(directoryEmployee);
        }

        // GET: DirectoryEmployees/Create
        public ActionResult Create()
        {
            ViewBag.DirectoryID = new SelectList(db.Directories, "ID", "Name");
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "FirstName");
            return View();
        }

        // POST: DirectoryEmployees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,EmployeeID,DirectoryID")] DirectoryEmployee directoryEmployee)
        {
            if (ModelState.IsValid)
            {
                db.DirectoryEmployees.Add(directoryEmployee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DirectoryID = new SelectList(db.Directories, "ID", "Name", directoryEmployee.DirectoryID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "FirstName", directoryEmployee.EmployeeID);
            return View(directoryEmployee);
        }

        // GET: DirectoryEmployees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DirectoryEmployee directoryEmployee = db.DirectoryEmployees.Find(id);
            if (directoryEmployee == null)
            {
                return HttpNotFound();
            }
            ViewBag.DirectoryID = new SelectList(db.Directories, "ID", "Name", directoryEmployee.DirectoryID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "FirstName", directoryEmployee.EmployeeID);
            return View(directoryEmployee);
        }

        // POST: DirectoryEmployees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,EmployeeID,DirectoryID")] DirectoryEmployee directoryEmployee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(directoryEmployee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DirectoryID = new SelectList(db.Directories, "ID", "Name", directoryEmployee.DirectoryID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "FirstName", directoryEmployee.EmployeeID);
            return View(directoryEmployee);
        }

        // GET: DirectoryEmployees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DirectoryEmployee directoryEmployee = db.DirectoryEmployees.Find(id);
            if (directoryEmployee == null)
            {
                return HttpNotFound();
            }
            return View(directoryEmployee);
        }

        // POST: DirectoryEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DirectoryEmployee directoryEmployee = db.DirectoryEmployees.Find(id);
            db.DirectoryEmployees.Remove(directoryEmployee);
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
