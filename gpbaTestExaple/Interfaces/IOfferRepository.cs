using gpbaTestExaple.Models;

namespace gpbaTestExaple.Interfaces
{
    public interface IOfferRepository
    {
        Task<Offer> AddAsync(Offer offer);
        Task<List<Offer>> SearchAsync(string query);
        Task<List<Supplier>> GetPopularSuppliersAsync();
    }
}
