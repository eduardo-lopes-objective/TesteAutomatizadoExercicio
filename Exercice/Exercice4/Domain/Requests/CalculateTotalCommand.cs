using Exercice.Exercice4.Domain.Entities;

namespace Exercice.Exercice4.Domain.Rrequests
{
    public class CalculateTotalCommand
    {
        public ShoppingCart? ShoppingCart { get; set; }
    }

    public class CalculateTotalResponse : Response<int>
    {
        public decimal Total { get; set; }
    }
}