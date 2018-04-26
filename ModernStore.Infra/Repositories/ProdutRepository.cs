using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Infra.Context;
using System;
using System.Linq;

namespace ModernStore.Infra.Repositories
{
    public class ProdutRepository : IProtuctRepository
    {
        private readonly ModernStoreDataContext _context;

        public ProdutRepository(ModernStoreDataContext context)
        {
            _context = context;
        }

        public Product Get(Guid id)
        {
            return _context
                .Products
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
}
