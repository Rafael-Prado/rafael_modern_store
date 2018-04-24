using ModernStore.Shared.Commands;
using System;
using System.Collections.Generic;

namespace ModernStore.Domain.Commands
{
    public class RegisterOrderCommad: ICommad
    {
        public Guid Customer { get; set; }
        public decimal DeliveryFee { get; set; }
        public decimal Discount { get; set; }
        public IEnumerable<RegisterOrderItemCommand> Items { get; set; }
    }
}
