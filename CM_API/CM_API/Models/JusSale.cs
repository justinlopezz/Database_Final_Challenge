//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CM_API.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class JusSale
    {
        public System.DateTime DateOrdered { get; set; }
        public decimal Price { get; set; }
        public string RecordID { get; set; }
        public int CustNo { get; set; }
        public string InterestCode { get; set; }
    
        public virtual JusCustomer JusCustomer { get; set; }
        public virtual JusRecord JusRecord { get; set; }
    }
}
