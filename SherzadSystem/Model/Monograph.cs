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
    
    public partial class Monograph
    {
        public int Mid { get; set; }
        public int UniqueId { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public System.DateTime CreationDate { get; set; }
        public string remarks { get; set; }
        public Nullable<decimal> totalPrice { get; set; }
        public Nullable<decimal> totalDiscount { get; set; }
        public Nullable<decimal> totalRecived { get; set; }
        public int PersonId { get; set; }
        public Nullable<int> UniversityId { get; set; }
        public Nullable<int> FacultyId { get; set; }
        public Nullable<int> DepartmentId { get; set; }
    
        public virtual Departments Departments { get; set; }
        public virtual Faculties Faculties { get; set; }
        public virtual PersonInformation PersonInformation { get; set; }
        public virtual Universities Universities { get; set; }
    }
}
