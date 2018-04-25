using ModernStore.Shared.Commands;
using System;

namespace ModernStore.Domain.Commads.Results
{
    public class RegisterCustomerCommadResult: ICommadResult
    {
        public RegisterCustomerCommadResult() { }
        
        public RegisterCustomerCommadResult(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
