using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Dtos
{
    public class CreateCommentDto
    {
        [Required] public Guid? PostId { get; set; }
        [Required] [StringLength(30)] public string Author { get; set; }

        [Required] [StringLength(120)] public string Content { get; set; }
    }
}