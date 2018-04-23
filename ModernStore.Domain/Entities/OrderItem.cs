using FluentValidator;
using ModernStore.Shared;

namespace ModernStore.Domain.Entities
{
    public class OrderItem: Entity
    {
        public OrderItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
            Price = product.Price;

            new ValidationContract<OrderItem>(this)
                .IsGreaterThan(x => x.Quantity, 1);
               
        }

        public Product Product { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }

        public decimal Total() => Price * Quantity;
    }
}
