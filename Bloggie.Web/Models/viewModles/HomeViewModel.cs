using Bloggie.Web.Models.Domain;

namespace Bloggie.Web.Models.viewModles
{
    public class HomeViewModel
    {
        public IEnumerable<BlogPost> blogPosts { get; set; }
        public IEnumerable<Tag> tags { get; set; }
    }
}
