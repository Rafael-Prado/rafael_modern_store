﻿using Dapper;
using ModernStore.Domain.Commands.Results;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Infra.Context;
using ModernStore.Shared;
using System;
using System.Data.Entity;
using System.Data.SqlClient;
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

        public Customer GetUser(string userName)
        {
            return _context
                .Customers
                .Include(x => x.User)
                .AsNoTracking()
                .FirstOrDefault(x => x.User.UserName == userName);
        }


        public GetCustomerCommadResult GetUserName(string userName)
        {
            
            //    return _context.Customers
            //        .Include(x => x.User)
            //        .AsNoTracking()
            //        .Select(x => new GetCustomerCommadResult
            //    {
            //        Name = x.Name.ToString(),
            //        Document = x.Document.Number,
            //        Active = x.User.Active,
            //        Email = x.Email.Address,
            //        Password = x.User.Password,
            //        UserName = x.User.Password
            //    }).FirstOrDefault(x => x.UserName == userName);

        var query = "SELECT * FROM [GetCustomerInfoView] WHERE [Active]=1 AND [Username]=@username";
            using (var conn = new SqlConnection(Runtime.ConnectionString))
            {
                conn.Open();
                return conn
                    .Query<GetCustomerCommadResult>(query,
                    new { username = userName })
                    .FirstOrDefault();
            }

        }

        
    }
}  
    


