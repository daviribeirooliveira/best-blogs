// ReSharper disable CollectionNeverUpdated.Global

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities
{
    public class Post : Entity
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
        }

        [Required] [StringLength(30)] public string Title { get; set; }

        [Required] [StringLength(1200)] public string Content { get; set; }

        [InverseProperty(nameof(Comment.Post))]
        public ICollection<Comment> Comments { get; set; }
    }
}