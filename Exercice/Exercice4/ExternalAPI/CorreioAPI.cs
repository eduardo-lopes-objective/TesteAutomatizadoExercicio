namespace Exercice.Exercice4.ExternalAPI
{
    public interface ICorreioAPI
    {
        Task<int> CalculateFrete(long cep);

    }

    public class CorreioAPI : ICorreioAPI
    {
        public Task<int> CalculateFrete(long cep)
        {
            Random random = new();

            return Task.FromResult(random.Next(0, 99));
        }
    }
}