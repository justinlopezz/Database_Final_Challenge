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
    
    public partial class JusCustomer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public JusCustomer()
        {
            this.JusSales = new HashSet<JusSale>();
        }
    
        public int CustNo { get; set; }
        public string CustName { get; set; }
        public string CustAddress { get; set; }
        public int CustPcode { get; set; }
        public string InterestCode { get; set; }
    
        public virtual JusInterest JusInterest { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JusSale> JusSales { get; set; }
    }
}
