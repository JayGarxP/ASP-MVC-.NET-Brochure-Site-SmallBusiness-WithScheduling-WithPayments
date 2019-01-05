using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations; //need for Display()
//This is dataAnnotation for decoration.

namespace Lab6.Models
{
    public class User
    {
        [Key]
        public int PersonID { get; set; } //accidentally named this horribly, auto-refactoring will not work at this point. :(

        //[Required]
        public string creator { get; set; }

        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Email Address")]
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address fam")]
        public string EmailAddress { get; set; }

        [Display(Name = "Lifetime Ranch Drank (Gallons)")]
        [Required]
        public float GalRanchConsumed { get; set; } //Guy Fieti Power Level


        //A user has Pets ??? Don't understand what the database really does from this
        public virtual List<Pet> MyPets { get; set; }

        public virtual Wealth MyWealth { get; set; }
    }

}