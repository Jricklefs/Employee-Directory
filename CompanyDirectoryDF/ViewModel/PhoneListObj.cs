using CompanyDirectoryDF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompanyDirectoryDF.ViewModel
{


    public class PhoneListObj
    {
        public virtual SelectList PhoneListTypes { get; set; }
        public virtual string NewPhoneListName { get; set; }
        public virtual ICollection<EmployesWithInclude> EmployeesWithInclude_List{ get; set; }


    }
}