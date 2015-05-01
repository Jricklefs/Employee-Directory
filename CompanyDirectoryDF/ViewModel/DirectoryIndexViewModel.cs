using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CompanyDirectoryDF.Models;
using System.ComponentModel.DataAnnotations;

namespace CompanyDirectoryDF.ViewModel
{
    public class DirectoryIndexViewModel
    {

        public virtual IEnumerable<Directory> Directories { get; set; }
        public virtual Address Address { get; set; }
        public virtual Department Department { get; set; }
        public virtual Employee Employee { get; set; }

        public virtual IEnumerable<Department> Departments { get; set; }
        public virtual IEnumerable<PhoneList> PhoneLists { get; set; }
        public virtual IEnumerable<WebURLWebLocation> WebURLWebLocations { get; set; }
        public virtual IEnumerable<DirectoryEmployee> DirectoryEmployees { get; set; }

    }
}