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
    public class EmployeeDirectoryController : Controller
    {
       
        private CompanyDirectoryDFEntities db = new CompanyDirectoryDFEntities();
        // GET: Directory
        public ActionResult Index()
        {
            int directoryId = 1;// Just defaults to Eagletm for now. 

            var viewModel = new DirectoryIndexViewModel();

            viewModel.DirectoryEmployees = db.DirectoryEmployees
                .Include(d => d.Directory)
                .Include(d => d.Employee)
                .OrderBy(x => x.Employee.FirstName)
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

        // GET: Directory/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Directory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Directory/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Directory/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Directory/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Directory/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Directory/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
