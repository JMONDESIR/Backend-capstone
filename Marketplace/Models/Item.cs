using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marketplace.Models
{
    public class Item
    {
        public int ItemId { get; set; }

        public Category Category { get; set; }

        public int CategoryId { get; set; }

        public User Seller { get; set; }

        public string SellerId { get; set; }

        public Status Status { get; set; }

        public int StatusId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public double ListPrice { get; set; }
    }
}
