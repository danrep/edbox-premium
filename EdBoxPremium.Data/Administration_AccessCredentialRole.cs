//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Administration_AccessCredentialRole
    {
        public int Id { get; set; }
        public int CredentialId { get; set; }
        public int PermissionId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
