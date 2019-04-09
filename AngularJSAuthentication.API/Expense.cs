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
    
    public partial class Expense
    {
        public short ExpenseID { get; set; }
        public Nullable<short> ProjectID { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<short> AssetID { get; set; }
        public Nullable<short> CategoryID { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public string Description { get; set; }
        public string Refrence { get; set; }
        public Nullable<bool> IsApproved { get; set; }
        public string ReceiptPath { get; set; }
    
        public virtual Project Project { get; set; }
        public virtual Asset Asset { get; set; }
        public virtual Category Category { get; set; }
    }
}
