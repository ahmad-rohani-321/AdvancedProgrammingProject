//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SherzadSystem.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class JournalEntry
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public JournalEntry()
        {
            this.AccountEntry = new HashSet<AccountEntry>();
        }
    
        public int JEid { get; set; }
        public int Till { get; set; }
        public Nullable<decimal> credit { get; set; }
        public Nullable<decimal> debit { get; set; }
        public System.DateTime CreationDate { get; set; }
        public string remarks { get; set; }
        public int TransactionType { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AccountEntry> AccountEntry { get; set; }
        public virtual ERCodes ERCodes { get; set; }
        public virtual Tills Tills { get; set; }
    }
}
