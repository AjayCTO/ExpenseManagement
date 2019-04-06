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
    
    public partial class Project
    {
        public Project()
        {
            this.Asset = new HashSet<Asset>();
            this.Category = new HashSet<Category>();
            this.Expense = new HashSet<Expense>();
            this.Incoming = new HashSet<Incoming>();
            this.User = new HashSet<User>();
        }
    
        public short ProjectID { get; set; }
        public string Name { get; set; }
        public string BillingMethod { get; set; }
        public string CustomerName { get; set; }
        public Nullable<decimal> TotalCost { get; set; }
    
        public virtual ICollection<Asset> Asset { get; set; }
        public virtual ICollection<Category> Category { get; set; }
        public virtual ICollection<Expense> Expense { get; set; }
        public virtual ICollection<Incoming> Incoming { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
