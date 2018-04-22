
using FluentValidator;
using System;

namespace ModernStore.Shared
{
    public abstract class Entity: Notifiable
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id {get; private set; }
    }
}