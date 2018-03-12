using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryMVC.Models.ViewModels
{
    public class CheckInViewModel
    {
        public DateTime TimeCheckedIn { get; set; }
        public int BookId { get; set; }
        public int PatronId { get; set; }
        public string PatronName { get; set; }
        public string BookTitle { get; set; }
    }
}