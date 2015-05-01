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
using System.Web.UI;

namespace CompanyDirectoryDF.Controllers
{
    public class EmergencyListController : Controller
    {
       
        private CompanyDirectoryDFEntities db = new CompanyDirectoryDFEntities();
        // GET: EmergencyList
      
        // GET: PhoneLists
        public ActionResult Index()
        {
            var phoneLists = db.PhoneLists
                .Include(p => p.Directory)
                .Include(p => p.Employee)
                .Include(p => p.PhoneListName);

            var phoneList = phoneLists.ToList();

            List<EmergencyList> listOfEmoLists = new List<EmergencyList>();

            var prevList = "";
            EmergencyList el = new EmergencyList();
            

            foreach (PhoneList pl in phoneList)
            {
                if (listOfEmoLists.Count == 0) 
                {
                    AddNewEmergencyList(ref listOfEmoLists, pl);
                }
                else
                {
                    bool addNewList = true;
                    foreach (EmergencyList EmoListItem in listOfEmoLists)
                    {
                        if(pl.PhoneListNameID == EmoListItem.EmergencyListID)
                        {
                          EmoListItem.EmployeesInEmergencyList.Add(pl.Employee);
                          addNewList = false;
                          break;
                        }
                    }
                    if(addNewList)
                        AddNewEmergencyList(ref listOfEmoLists, pl);

                }
           }
            return View(listOfEmoLists);
        }

        private static void AddNewEmergencyList(ref List<EmergencyList> listOfEmergencyContacts, PhoneList pl){
            EmergencyList el = new EmergencyList();

            el.EmergencyListID = pl.PhoneListNameID;
            el.EmergencyListName = pl.PhoneListName.Name;
            el.EmployeesInEmergencyList.Add(pl.Employee);

            listOfEmergencyContacts.Add(el);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var phoneLists = db.PhoneLists
                  .Include(p => p.Directory)
                  .Include(p => p.Employee)
                  .Include(p => p.PhoneListName)
                  .Where(p => p.PhoneListName.ID == id);

            var phoneList = phoneLists.ToList();
            List<EmergencyList> listOfEmoLists = new List<EmergencyList>();

            var prevList = "";
            EmergencyList el = new EmergencyList();
            List<Employee> empList = new List<Employee>();
            foreach (PhoneList pl in phoneList)
            {
                if (prevList != pl.PhoneListNameID.ToString())
                {
                    if (prevList != "")
                        listOfEmoLists.Add(el);

                    el = new EmergencyList();


                    ViewBag.AddToPhoneListId = pl.ID;
                    el.PhonelistID = pl.ID;
                    el.EmergencyListID = id;
                    el.EmergencyListName = pl.PhoneListName.Name;
                    el.EmployeesInEmergencyList.Add(pl.Employee);
                    
                    prevList = pl.PhoneListNameID.ToString();
                }
                else
                {
                    el.EmployeesInEmergencyList.Add(pl.Employee);
                }
            }
            listOfEmoLists.Add(el);



            return View(listOfEmoLists);
        }
        
        [HttpPost] //This should be a post with a Security Token. 
        public ActionResult Delete(string hdnValue, string phonelistId, string EmergencyListID )
        {
            //PhoneList phoneList = db.PhoneLists.Where(c => c.EmployeeID == Convert.ToInt32(hdnValue));
            PhoneList phoneList = db.PhoneLists.Find(Convert.ToInt32(hdnValue));
            int empId = Convert.ToInt32(hdnValue);
            int emgListType = Convert.ToInt32(EmergencyListID);
            List<PhoneList> dddd = db.PhoneLists.Where(x => x.EmployeeID == empId).Where(x => x.PhoneListNameID == emgListType).ToList();// This is not the best way to do this. Should refactor the ViewModel. 
        
            db.PhoneLists.Remove(dddd[0]);
            db.SaveChanges();
            return RedirectToAction("Edit", new { id = Convert.ToInt32(EmergencyListID) });
        }

        public ActionResult Add(int? listId)
        {
            PhoneList phlist = new PhoneList();
            phlist.PhoneListNameID = listId;
            phlist.DirectoryID = 1;

            //ViewBag.DirectoryID = new SelectList(db.Directories, "ID", "Name");
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "FullName");
            //ViewBag.PhoneListNameID = new SelectList(db.PhoneListNames, "ID", "Name");

            return View(phlist);
        }

        public ActionResult Create() 
        {
            PhoneListObj plo = new PhoneListObj();
            plo.EmployeesWithInclude_List = new List<EmployesWithInclude>();

            var empsList  = db.Employees.ToList();        
            foreach (var emp in empsList)
            {
                plo.EmployeesWithInclude_List.Add(new EmployesWithInclude()
                    {
                        FirstName = emp.FirstName,
                        ID = emp.ID,
                        Include = false
                    }
                    );
                           
            }
           plo.PhoneListTypes = new SelectList(db.PhoneListTypes.ToList(), "Id", "Type");
           return View(plo);
        }

        [HttpPost]
        public ActionResult Create(PhoneListObj plo){

            PhoneListName pln = new PhoneListName();

          
            pln.TypeID = 2;
            pln.Name = "DeleteMe";
            db.PhoneListNames.Add(pln);
            db.SaveChanges();


            ViewBag["Status"] = "PassFail";
            return View(plo);
        }




        // POST: PhoneLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(PhoneList phoneList)
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
      
    }
}

//http://dotnetslackers.com/articles/aspnet/Understanding-ASP-NET-MVC-Model-Binding.aspx