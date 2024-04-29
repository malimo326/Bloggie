using System.ComponentModel.DataAnnotations;

namespace Bloggie.Web.Models.viewModles
{
    public class AddTagRequest
    {
        [Required]
        public string Name { get; set; }
        [Required] 
        public string DisplayName { get; set; }
    }
}
