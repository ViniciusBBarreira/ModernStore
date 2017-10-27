using ModernStore.Shared.Entities;

namespace ModernStore.Domain.Entities
{
    public class Product : Entity
    {
        #region Constructors
        public Product(string title, decimal price, int quantityOnHand, string image)
        {
            Title = title;
            Price = price;
            QuantityOnHand = quantityOnHand;
            Image = image;
        }
        #endregion

        #region Attributes
        public string Title { get; private set; }
        public decimal Price { get; private set; }
        public int QuantityOnHand { get; private set; }
        public string Image { get; private set; }
        #endregion

        #region Methods
        public void DecreaseQuantity(int quantity) => QuantityOnHand -= quantity;
        #endregion
    }
}
