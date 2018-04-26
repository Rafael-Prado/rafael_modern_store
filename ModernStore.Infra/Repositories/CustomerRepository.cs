using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Infra.Context;
using System;
using System.Data.Entity;
using System.Linq;

namespace ModernStore.Infra.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ModernStoreDataContext _context;
        public CustomerRepository(ModernStoreDataContext context)
        {
            _context = context;
        }

        public bool DocumentExists(string document)
        {
            return _context.Customers.Any(x => x.Document.Number == document);
        }

        public Customer Get(Guid id)
        {
            return _context
                .Customers
                .Include(x => x.User)
                .FirstOrDefault(x => x.Id == id);
        }

        public Customer Get(string document)
        {
            return _context
               .Customers
               .Include(x => x.User)
               .FirstOrDefault(x => x.Document.Number == document);
        }
        
        public void Save(Customer customer)
        {
            _context.Customers.Add(customer);
        }

        public void Update(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
        }

        public Customer GetByUserId(Guid id)
        {
            throw new NotImplementedException();
        }

    }
}
