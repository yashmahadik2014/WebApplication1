using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebApplication1.Entity
{
    public class Agreement
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        public List<SelectListItem> ProductGroupList { get; set; }

        [Required(ErrorMessage ="Select Product Group")]
        public int ProductGroupId { get; set; }

        public List<SelectListItem> ProductList { get; set; }

        [Required(ErrorMessage = "Select Product")]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Select Effective Date")]
        public DateTime EffectiveDate { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        [Required(ErrorMessage = "Select Expiration Date")]
        public DateTime Expiration { get; set; }
        public decimal ProductPrice { get; set; }
        [Required(ErrorMessage = "Enter Price")]
        public decimal NewPrice { get; set; }

        public string ProductDescription { get; set; }

        public string GroupDescription { get; set; }
    }
}
