using BookWorlds.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWorlds.Services.Models
{
    public class BookServiceModel
    {
        public BookServiceModel()
        {
            this.Categories = new List<string>();
            this.Images = new List<Image>();
        }

        [Required]
        [MaxLength(300)]
        public string Title {  get; set; }
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }
        public ICollection<string> Categories { get; set; }

        public string AuthorName { get; set; }
        public string UserEmail { get; set; }

        public ICollection<Image> Images { get; set; }
    }
}
