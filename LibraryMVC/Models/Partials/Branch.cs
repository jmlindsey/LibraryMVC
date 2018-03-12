using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryMVC.Models
{
    [MetadataType(typeof(Branch_MetaData))]
    public partial class Branch
    {
    }

    public class Branch_MetaData
    {
        [Display(Name = "Branch ID")]
        public int BranchId { get; set; }
        
        [Display(Name = "Library Name")]
        public string LibraryName { get; set; }

        [Display(Name = "Library Address")]
        public string LibraryAddress { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

    }

}