﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EdBoxPremium.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<School_Attendance> School_Attendance { get; set; }
        public virtual DbSet<School_AttendanceSession> School_AttendanceSession { get; set; }
        public virtual DbSet<School_SubSchool> School_SubSchool { get; set; }
        public virtual DbSet<School_SubSchoolDepartment> School_SubSchoolDepartment { get; set; }
        public virtual DbSet<Student_RegistrationData> Student_RegistrationData { get; set; }
        public virtual DbSet<System_Setting> System_Setting { get; set; }
        public virtual DbSet<Administration_AccessCredential> Administration_AccessCredential { get; set; }
        public virtual DbSet<Administration_AccessCredentialRole> Administration_AccessCredentialRole { get; set; }
        public virtual DbSet<Student_ProfileData> Student_ProfileData { get; set; }
        public virtual DbSet<School_Course> School_Course { get; set; }
        public virtual DbSet<Student_CourseRegistration> Student_CourseRegistration { get; set; }
        public virtual DbSet<Administration_RegistrationSessionManifest> Administration_RegistrationSessionManifest { get; set; }
        public virtual DbSet<Administration_RegistrationSessionManifestItems> Administration_RegistrationSessionManifestItems { get; set; }
    }
}
