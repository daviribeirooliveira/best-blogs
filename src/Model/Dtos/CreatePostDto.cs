using System.ComponentModel.DataAnnotations;

namespace Model.Dtos
{
    public class CreatePostDto
    {
        [Required] [StringLength(30)] public string Title { get; set; }

        [Required] [StringLength(1200)] public string Content { get; set; }
    }
}