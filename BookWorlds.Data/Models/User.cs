using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace BookWorlds.Data.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            this.Books = new List<Book>();
            this.Commnets = new List<Comment>();
            this.Auctions = new List<UserAuction>();
        }

        [Required]
        [EmailAddress]
        [MaxLength(255)]
        public override string Email { get; set; }

        public ICollection<Book> Books { get; set; }
        public ICollection<Comment> Commnets { get; set; }
        public ICollection<UserAuction> Auctions { get; set; }
    }
}
