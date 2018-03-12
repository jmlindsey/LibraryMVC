//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Patron
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Patron()
        {
            this.Books = new HashSet<Book>();
            this.CheckoutEvents = new HashSet<CheckoutEvent>();
        }
    
        public int PatronId { get; set; }
        public string UserId { get; set; }
        public Nullable<int> PreferenceBranchId { get; set; }
        public string PatronName { get; set; }
        public string Address { get; set; }
        public string PatronEmail { get; set; }
        public string PhoneNumber { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Book> Books { get; set; }
        public virtual Branch Branch { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CheckoutEvent> CheckoutEvents { get; set; }
    }
}
