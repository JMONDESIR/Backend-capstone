using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Marketplace.Models
{
    public class Bid
    {
        public int BidId { get; set; }

        public Item Item { get; set; }

        [Display(Name = "Item")]
        public int ItemId { get; set; }

        [Display(Name = "User")]
        public User User { get; set; }

        public string UserId { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:C}")]

        [Display(Name = "Bid")]
        public double Offer { get; set; }

        public string Comment { get; set; }
        public DateTime When { get; set; }
    }
}
