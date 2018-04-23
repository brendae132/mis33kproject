using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FinalProject_Team12.Models
{
    public class OrderDetail
    {
        public Int32 OrderDetailID { get; set; }
        [Range(1, 1000, ErrorMessage = "quantity must be between 1 and 1000")]
        [Required(ErrorMessage = "Quantity is required.")]
        [Display(Name = "Quantity")]
        public Int32 Quantity { get; set; }

        [Display(Name = "Product Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal ProductPrice { get; set; }

        [Display(Name = "Extended Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal ExtendedPrice { get; set; }

        //navigational properties
        public virtual Order Order { get; set; }
        public virtual Screening Screening { get; set; }
        public virtual List<AppUser> AppUser { get; set; }
    }
}