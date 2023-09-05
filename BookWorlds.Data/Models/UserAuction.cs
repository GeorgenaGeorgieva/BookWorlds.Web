using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace BookWorlds.Data.Models
{
    public class UserAuction
    {
        public string UserId { get; set; }
        public int AuctionId { get; set; }

        public User User { get; set; }
        public Auction Auction { get; set;}
    }
}
