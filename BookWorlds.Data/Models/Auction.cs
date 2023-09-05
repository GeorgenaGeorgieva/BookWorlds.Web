using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWorlds.Data.Models
{
    public class Auction
    {
        public Auction()
        {
            this.Buyers = new List<UserAuction>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string SellerEmail { get; set; }

        public Book Book { get; set; }
        public int BookId { get; set; }

        public ICollection<UserAuction> Buyers { get; set; }
    }
}
