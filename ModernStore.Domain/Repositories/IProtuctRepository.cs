using ModernStore.Domain.Entities;
using System;

namespace ModernStore.Domain.Repositories
{
    public interface IProtuctRepository
    {
        Product Get(Guid id);
    }
}
