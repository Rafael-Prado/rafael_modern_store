using ModernStore.Shared;
using System;

namespace ModernStore.Domain.Entities
{
    public class Product : Entity
    {
        public Product(string title, decimal price, int quantityOnHand)
        {
            Title = title;
            Price = price;
            QuantityOnHand = quantityOnHand;
        }

        public string Title { get; private set; }
        public decimal Price { get; set; }
        public int QuantityOnHand { get; private set; }

        public void DecreaseQuantity(int quantity) => QuantityOnHand -= quantity;
    }   
}
