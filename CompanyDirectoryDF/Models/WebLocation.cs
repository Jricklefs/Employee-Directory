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
    
    public partial class WebLocation
    {
        public WebLocation()
        {
            this.WebURLWebLocations = new HashSet<WebURLWebLocation>();
        }
    
        public int ID { get; set; }
        public string Location { get; set; }
    
        public virtual ICollection<WebURLWebLocation> WebURLWebLocations { get; set; }
    }
}
