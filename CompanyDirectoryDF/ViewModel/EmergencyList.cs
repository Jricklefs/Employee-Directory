using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CompanyDirectoryDF.Models;

namespace CompanyDirectoryDF.ViewModel
{
    public class EmergencyList
    {
        public EmergencyList()
        {
            EmployeesInEmergencyList = new List<Employee>();
        }

        public string MyValue { get; set; }
        public int? EmergencyListID { get; set; }
        public int?  PhonelistID { get; set; }


        public virtual string EmergencyListName { get; set; }
        public virtual List<Employee> EmployeesInEmergencyList { get; set; }
        public virtual List<PhoneList> PhoneListRecord { get; set; }
    }
}