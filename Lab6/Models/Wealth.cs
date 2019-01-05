using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab6.Models
{
    public class Wealth
    {
        [Key]
        public int WealthID { get; set; } 

        [Display(Name = "$$$ Cash")]
        [Required]
        public double Cash { get; set; }

        //Store
        //Items


    }
}