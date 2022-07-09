using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities
{
    public class Comment : Entity
    {
        [Required] public Guid? PostId { get; set; }

        [Required] [StringLength(30)] public string Author { get; set; }

        [Required] [StringLength(120)] public string Content { get; set; }

        [ForeignKey(nameof(PostId))]
        [InverseProperty("Comments")]
        public Post Post { get; set; }
    }
}