using Dapper;
using ModernStore.Domain.Commands.Results;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Infra.Context;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ModernStore.Infra.Repositories
{
    public class ProdutRepository : IProtuctRepository
    {
        private const string ConnectionString = @"Server=localhost\SQLEXPRESS;Database=modernStore;Trusted_Connection=True";
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
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                return conn
                    .Query<GetProductListCommadResult>(query);
            }
        }
    }
}

