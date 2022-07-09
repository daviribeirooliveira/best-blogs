using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Dtos
{
    public class UpdatePostDto
    {
        [Required] public Guid? Id { get; set; }

        [StringLength(30)] public string Title { get; set; }

        [StringLength(1200)] public string Content { get; set; }
    }
}