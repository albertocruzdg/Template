using System;

namespace SomeApplication.Business.Model
{
    public abstract class Entity
    {
        public Entity() => this.Id = Guid.NewGuid();

        public Guid Id { get; set; }
    }
}