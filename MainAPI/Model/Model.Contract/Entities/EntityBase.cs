using ModelContract.Interfaces;
using System;

namespace ModelContract.Entities
{
    public abstract class EntityBase : IEntity
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
