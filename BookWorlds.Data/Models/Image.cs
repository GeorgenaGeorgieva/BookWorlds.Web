using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWorlds.Data.Models
{
    public class Image
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Url { get; set; }
        public bool IsDeleted { get; set; }

        public Book Book { get; set; }
        public int? BookId { get; set; }
    }
}
