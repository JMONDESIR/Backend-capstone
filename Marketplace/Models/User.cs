using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Marketplace.Models
{
    public class User : IdentityUser
    {
        public User ()
        {
            Messages = new HashSet<Message>();
        }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [NotMapped]
        [Display(Name = "User Name")]
        public string FullName => $"{FirstName} {LastName}";

        public string ImagePath { get; set; }
        public virtual ICollection<Item> Item { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
    }
}
