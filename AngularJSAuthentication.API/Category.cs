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
    
    public partial class Category
    {
        public Category()
        {
            this.Expense = new HashSet<Expense>();
        }
    
        public short CategoryID { get; set; }
        public Nullable<short> ProjectID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    
        public virtual Project Project { get; set; }
        public virtual ICollection<Expense> Expense { get; set; }
    }
}
