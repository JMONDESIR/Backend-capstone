using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Marketplace.Models
{
    public class Message
    {
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }
        [Required]
        public string Text { get; set; }

        public DateTime When { get; set; }

        public String UserId { get; set; }

        public virtual User Sender { get; set; }

    }
}
