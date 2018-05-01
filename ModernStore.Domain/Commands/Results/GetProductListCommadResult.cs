using ModernStore.Shared.Commands;
using System;

namespace ModernStore.Domain.Commands.Results
{
    public class GetProductListCommadResult: ICommadResult
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public decimal price { get; set; }

    }
}
