using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marketplace.Models.ItemViewModels
{
    public class BidItemViewModel
    {
        public Bid Bid { get; set; }

        public Item Item { get; set; }

        public User User { get; set; }
    }
}
