namespace Exercice.Exercice4.Domain.Entities
{
    public class Customer
    {
        public string? Name {get;set;}
        public long DeliverCEP {get;set;}

        public Customer(string name, long cep)
        {
            this.Name = name;
            this.DeliverCEP = cep;
        }
    }
}