using FluentValidator;
using ModernStore.Domain.Commands.Inputs;
using ModernStore.Domain.Commands.Results;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Shared.Commands;

namespace ModernStore.Domain.Commands.Handlers
{
    public class OrderCommandHandler : Notifiable, ICommandHandler<RegisterOrderCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderCommandHandler(ICustomerRepository customerRepository, IProductRepository productRepository,IOrderRepository orderRepository)
        {
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        public ICommandResult Handle(RegisterOrderCommand command)
        {
            // Intancia o cliente (Lendo do repositório)
            var customer = _customerRepository.GetById(command.Customer);

            // Gera um novo pedido
            var order = new Order(customer, command.DeliveryFee, command.Discount);

            // Adiciona os itens no pedido
            foreach (var item in command.Items)
            {
                var product = _productRepository.GetById(item.Product);
                order.AddItem(new OrderItem(product, item.Quantity));
            }

            // Adiciona as notificações do pedido no Handler
            AddNotifications(order.Notifications);

            // Persiste no banco
            if (IsValid()) _orderRepository.Save(order);

            // Retorna algo
            return new RegisterOrderCommandResult(order.Number);
        }
    }
}
