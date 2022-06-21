namespace Exercice.Exercice4.Domain.Entities
{
    public class ShoppingCart
    {
        public Customer Customer { get; private set; }
        public List<ShoppingCartItem> ShoppingCartItemList { get; private set; }

        public ShoppingCart(Customer customer, List<ShoppingCartItem> shoppingCartItems)
        {
            this.Customer = customer;

            this.ShoppingCartItemList = shoppingCartItems;
        }
    }
}