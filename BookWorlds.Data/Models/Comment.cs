using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWorlds.Data.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Commentator { get; set; }

        [Required]
        [MaxLength(250)]
        public string Content { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public bool IsDeleted { get; set; }

        public User User { get; set; }
        public string UserId { get; set; }

        public Book Book { get; set; }
        public int BookId { get; set; }
    }
}
