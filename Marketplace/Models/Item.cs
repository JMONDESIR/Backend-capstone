using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Marketplace.Models
{
    public class Item
    {
        public int ItemId { get; set; }

        public Category Category { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public User Seller { get; set; }

        public string SellerId { get; set; }

        public Status Status { get; set; }

        [Display(Name = "Status")]
        public int StatusId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        [Range(0.01, 10000)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Price")]
        public double ListPrice { get; set; }

        public string ImagePath { get; set; }
    }
}
