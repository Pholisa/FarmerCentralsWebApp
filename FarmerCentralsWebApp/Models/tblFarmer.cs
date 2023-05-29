//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FarmerCentralsWebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class tblFarmer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblFarmer()
        {
            this.tblProducts = new HashSet<tblProduct>();
        }
    
        public int farmerId { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Farmer Name")]
        public string farmerName { get; set; }

        [Display(Name = "Password")]
        [StringLength(30, MinimumLength = 8)]
        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Password)]
        public string password { get; set; }


        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Contact")]
        public string contact { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Address")]
        public string address { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Email Address")]
        public string emailAddress { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblProduct> tblProducts { get; set; }

    }
}
