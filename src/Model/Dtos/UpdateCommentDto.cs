using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Dtos
{
    public class UpdateCommentDto
    {
        [Required] public Guid? Id { get; set; }
        [StringLength(30)] public string Author { get; set; }

        [StringLength(120)] public string Content { get; set; }
    }
}