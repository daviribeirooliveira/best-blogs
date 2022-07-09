using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Entities
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        [Key] public Guid Id { get; }

        public DateTime CreationDate { get; set; }
    }
}