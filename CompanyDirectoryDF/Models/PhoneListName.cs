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
    
    public partial class PhoneListName
    {
        public PhoneListName()
        {
            this.PhoneLists = new HashSet<PhoneList>();
        }
    
        public int ID { get; set; }
        public Nullable<int> TypeID { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<PhoneList> PhoneLists { get; set; }
        public virtual PhoneListType PhoneListType { get; set; }
    }
}
