﻿using FluentValidator;
using ModernStore.Shared.Entities;

namespace ModernStore.Domain.Entities
{
    public class OrderItem : Entity
    {
        #region Constructors
        public OrderItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
            Price = Product.Price;

            Validations();

            product.DecreaseQuantity(quantity);
        }
        #endregion

        #region Attributes
        public Product Product { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }
        #endregion

        #region Methods
        public decimal Total() => Price * Quantity;

        private void Validations()
        {
            new ValidationContract<OrderItem>(this)
                .IsGreaterThan(x => x.Quantity, 1)
                .IsGreaterThan(x => x.Product.QuantityOnHand, Quantity + 1, "Não existe em estoque!");
        }
        #endregion
    }
}
