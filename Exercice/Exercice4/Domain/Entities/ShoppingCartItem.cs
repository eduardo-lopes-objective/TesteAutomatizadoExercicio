namespace Exercice.Exercice4.Domain.Entities
{
    public class ShoppingCartItem
    {
        public Product Product { get; set; }
        public int Amount { get; set; }

        public ShoppingCartItem(Product product, int amount)
        {
            this.Product = product;
            this.Amount = amount;
        }
    }
}