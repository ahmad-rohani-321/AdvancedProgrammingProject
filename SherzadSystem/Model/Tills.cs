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
    
    public partial class Tills
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tills()
        {
            this.JournalEntry = new HashSet<JournalEntry>();
        }
    
        public int Tid { get; set; }
        public string TillName { get; set; }
        public decimal TillValue { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JournalEntry> JournalEntry { get; set; }
    }
}
