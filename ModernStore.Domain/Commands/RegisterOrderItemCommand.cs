using ModernStore.Shared.Commands;
using System;

namespace ModernStore.Domain.Commands
{
    public class RegisterOrderItemCommand: ICommad
    {
        public Guid Product { get; set; }
        public int Quantity { get; set; }

    }
}
