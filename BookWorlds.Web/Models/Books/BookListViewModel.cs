using BookWorlds.Web.Models.Images;

namespace BookWorlds.Web.Models.Books
{
    public class BookListViewModel
    {
        public BookListViewModel()
        {
            Categories = new List<string>();
            Images = new List<ImageViewModel>();
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<string> Categories { get; set; }

        public string AuthorName { get; set; }
        public string UserEmail { get; set; }

        public ICollection<ImageViewModel> Images { get; set; }
    }
}
