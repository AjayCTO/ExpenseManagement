//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AngularJSAuthentication.API
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public User()
        {
            this.Asset = new HashSet<Asset>();
        }
    
        public short UserID { get; set; }
        public Nullable<short> ProjectID { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
        public Nullable<System.DateTime> LastLogin { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    
        public virtual Project Project { get; set; }
        public virtual ICollection<Asset> Asset { get; set; }
    }
}
