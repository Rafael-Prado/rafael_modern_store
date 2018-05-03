using ModernStore.Domain.Commands.Results;
using ModernStore.Domain.Entities;
using System;

namespace ModernStore.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Customer Get(Guid id);
        Customer GetByUserId(Guid id);
        Customer Get(string document);
        Customer GetUser(string userName);
        bool DocumentExists(string document);
        void Update(Customer customer);
        void Save(Customer customer);

        GetCustomerCommadResult GetUserName(string userName);

    } 
}
