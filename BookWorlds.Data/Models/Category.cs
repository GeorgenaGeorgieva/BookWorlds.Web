using BookWorlds.Data.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWorlds.Data.Models
{
    public class Category
    {
        public Category()
        {
            this.Books = new List<BookCategory>();
        }

        public int Id { get; set; }
        public Genre Name { get; set; }

        public ICollection<BookCategory> Books { get;}
    }
}
