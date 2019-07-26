using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marketplace.Models
{
    public class Messages
    {
        public int Id { get; set; }

        public User Sender { get; set; }

        public User Reciever { get; set; }

        public string SenderId { get; set; }

        public string RecieverId { get; set; }

        public string Text { get; set; }
    }
}
