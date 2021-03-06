﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CompanyDirectoryDFEntities : DbContext
    {
        public CompanyDirectoryDFEntities()
            : base("name=CompanyDirectoryDFEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Directory> Directories { get; set; }
        public virtual DbSet<DirectoryEmployee> DirectoryEmployees { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<PhoneList> PhoneLists { get; set; }
        public virtual DbSet<PhoneListName> PhoneListNames { get; set; }
        public virtual DbSet<PhoneListType> PhoneListTypes { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<WebLocation> WebLocations { get; set; }
        public virtual DbSet<WebURL> WebURLs { get; set; }
        public virtual DbSet<WebURLWebLocation> WebURLWebLocations { get; set; }
        public virtual DbSet<EmployeeSkill> EmployeeSkills { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
    }
}
