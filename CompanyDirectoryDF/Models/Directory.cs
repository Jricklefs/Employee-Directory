//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CompanyDirectoryDF.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Directory
    {
        public Directory()
        {
            this.Addresses = new HashSet<Address>();
            this.Departments = new HashSet<Department>();
            this.DirectoryEmployees = new HashSet<DirectoryEmployee>();
            this.PhoneLists = new HashSet<PhoneList>();
            this.WebURLWebLocations = new HashSet<WebURLWebLocation>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<DirectoryEmployee> DirectoryEmployees { get; set; }
        public virtual ICollection<PhoneList> PhoneLists { get; set; }
        public virtual ICollection<WebURLWebLocation> WebURLWebLocations { get; set; }
    }
}