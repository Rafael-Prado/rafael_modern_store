using FluentValidator;
using ModernStore.Domain.Commands;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Shared.Commands;

namespace ModernStore.Domain.CommandHandler
{
    public class OrderCommadHandler : Notifiable,
        ICommandHandler<RegisterOrderCommad>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IProtuctRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderCommadHandler(ICustomerRepository customerRepository, 
            IProtuctRepository productRepository, 
            IOrderRepository orderRepository)
        {
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        public void Handle(RegisterOrderCommad commad)
        {
            var customer = _customerRepository.Get(commad.Customer);
            var order = new Order(customer, commad.DeliveryFee, commad.Discount);

            foreach (var item in commad.Items)
            {
                var product = _productRepository.Get(item.Product);
                order.AddItem(new OrderItem(product, item.Quantity));
            }

            AddNotifications(order.Notifications);

            if (order.IsValid())
            {
                _orderRepository.Save(order);
            }
        }
    }
}
