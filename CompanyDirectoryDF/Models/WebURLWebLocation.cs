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
    
    public partial class WebURLWebLocation
    {
        public Nullable<int> WebLocationID { get; set; }
        public Nullable<int> WebURLID { get; set; }
        public Nullable<int> DirectoryID { get; set; }
        public int ID { get; set; }
    
        public virtual Directory Directory { get; set; }
        public virtual WebLocation WebLocation { get; set; }
        public virtual WebURL WebURL { get; set; }
    }
}
