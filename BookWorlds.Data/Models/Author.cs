using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWorlds.Data.Models
{
    public class Author
    {
        public Author() => this.Books = new HashSet<Book>();

        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Autobiography { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
