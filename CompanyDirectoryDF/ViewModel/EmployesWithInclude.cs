using CompanyDirectoryDF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace CompanyDirectoryDF.ViewModel
{
    public class EmployesWithInclude : Employee
    {
        public bool Include { get; set; }
    }
}