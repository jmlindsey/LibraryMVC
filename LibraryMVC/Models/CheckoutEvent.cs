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
    
    public partial class CheckoutEvent
    {
        public int CheckoutEventId { get; set; }
        public System.DateTime DateTimeCheckedOut { get; set; }
        public int PatronId { get; set; }
        public int BookId { get; set; }
    
        public virtual Book Book { get; set; }
        public virtual Patron Patron { get; set; }
    }
}
