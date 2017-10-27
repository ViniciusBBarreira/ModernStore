using ModernStore.Domain.Commands;
using ModernStore.Domain.Commands.Handlers;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace ModernStore
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = new RegisterOrderCommand
            {
                Customer = Guid.NewGuid(),
                DeliveryFee = 10,
                Discount = 10,
                Items = new List<RegisterOrderItemCommand>
                {
                    new RegisterOrderItemCommand
                    {
                        Product = Guid.NewGuid(),
                        Quantity=1
                    },
                    new RegisterOrderItemCommand
                    {
                        Product = Guid.NewGuid(),
                        Quantity=1
                    }
                }
            };

            GenerateOrder(new FakeCustomerRepository(), new FakeProductRepository(),
               new FakeOrderRepository(), command);

            Console.ReadKey();
        }

        public static void GenerateOrder(ICustomerRepository customerRepository, IProductRepository productRepository, IOrderRepository orderRepository, RegisterOrderCommand command)
        {
            var handler = new OrderCommandHandler(customerRepository, productRepository, orderRepository);

            handler.Handle(command);

            //Console.WriteLine($"Anterior {mouse.QuantityOnHand} mouse");
            //Console.WriteLine($"Anterior {mousePad.QuantityOnHand} mousePad");
            //Console.WriteLine($"Anterior {teclado.QuantityOnHand} teclado");
            //order.AddItem(new OrderItem(mouse, 2));
            //order.AddItem(new OrderItem(mousePad, 2));
            //order.AddItem(new OrderItem(teclado, 2));
            //Console.WriteLine($"Depois {mouse.QuantityOnHand} mouse");
            //Console.WriteLine($"Depois {mousePad.QuantityOnHand} mousePad");
            //Console.WriteLine($"Depois {teclado.QuantityOnHand} teclado");
        }

        public class FakeCustomerRepository : ICustomerRepository
        {
            public bool DocumentExists(string document)
            {
                throw new NotImplementedException();
            }

            public Customer GetAll()
            {
                throw new NotImplementedException();
            }

            public Customer GetByDocument(string document)
            {
                throw new NotImplementedException();
            }

            public Customer GetById(Guid id)
            {
                return new Customer(
                    new Name("Vinícius", "Barreira"),
                    new Email("viniciustes@gmail.com"),
                    new Document("90653661134"),
                    new User("viniciustes", "123456", "123456"));
            }

            public Customer GetByUserId(Guid id)
            {
                throw new NotImplementedException();
            }

            public void Save(Customer customer)
            {
                throw new NotImplementedException();
            }

            public void Update(Customer customer)
            {
                throw new NotImplementedException();
            }
        }

        public class FakeProductRepository : IProductRepository
        {
            public Product GetAll()
            {
                throw new NotImplementedException();
            }

            public Product GetById(Guid id)
            {
                return new Product("Mouse", 299, 50, "mouse.jpg");
            }

            public IEnumerable<Product> GetListByIds(List<Guid> ids)
            {
                throw new NotImplementedException();
            }
        }

        public class FakeOrderRepository : IOrderRepository
        {
            public void Save(Order order)
            {
            }
        }
    }
}
