using BookWorlds.Data.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace BookWorlds.Data.Models
{
    public class Book
    {
        public Book()
        {
            this.Images = new List<Image>();
            this.Comments = new List<Comment>();
            this.Categories = new List<BookCategory>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(300)]
        public string Title { get; set; }
        
        [Required]
        [MaxLength (1000)]
        public string Description { get; set; }
        public bool IsАvailable { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<BookCategory> Categories { get; set; }

        public Author Author { get; set; }
        public int AuthorId { get; set; }

        public User User { get; set; }
        public string UserId { get; set; }

        public Auction? Auction { get; set; }

        public ICollection<Image> Images { get; set; }
        public ICollection<Comment> Comments { get; set; }

    }
}
