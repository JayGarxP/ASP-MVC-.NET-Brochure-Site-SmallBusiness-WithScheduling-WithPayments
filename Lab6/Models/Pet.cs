using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.ComponentModel.DataAnnotations; //need for Display()
using System.ComponentModel.DataAnnotations.Schema;
//This is dataAnnotation for decoration.

namespace Lab6.Models
{
    public class Pet
    {
        [Key]
        public int PetID { get; set; }

        //[Required] //Creator is determined programmatically from logged in ApplicationUser
        public string Creator { get; set; }

        [Display(Name = "Nickname")]
        [Required]
        public string NickName { get; set; }

        [Display(Name = "Species")]
        public int Species { get; set; }

        [NotMapped]
        public int MerchantSkill { get; set; }

        //Each Pet entity can have multiple users at same time.
        public virtual List<User> Users { get; set; }

    }

}