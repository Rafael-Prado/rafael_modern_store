using Dapper;
using ModernStore.Domain.Commands.Results;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Infra.Context;
using ModernStore.Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        public IEnumerable<GetProductListCommadResult> Get()
        {
            var query = "Select Id, Title, Price,[Image] from Product";
            using (var conn = new SqlConnection(Runtime.ConnectionString))
            {
                conn.Open();
                return conn
                    .Query<GetProductListCommadResult>(query);
            }
        }
    }
}

