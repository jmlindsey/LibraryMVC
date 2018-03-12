using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryMVC.Models.ViewModels
{
    public class PatronViewModel
    {
        public int PatronId { get; set; }

        [Display(Name = "Patron Name")]
        public string PatronName { get; set; }
        public Nullable<int> PreferenceBranchId { get; set; }
        [Display(Name = "Preference Branch")]
        public string PreferenceBranchName { get; set; }
        public string Address { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        public DateTime[] CheckoutDates { get; set; }
        [Display(Name = "Checkout History")]
        public string[] CheckoutTitles { get; set; }
        [Display(Name = "Books Currently Rented")]
        public string[] BooksCurrentlyRentedTitles { get; set; }
        public int[] BooksCurrentlyRentedIds { get; set; }

    }
}