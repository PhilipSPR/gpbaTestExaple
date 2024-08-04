using gpbaTestExaple.Models;

namespace gpbaTestExaple.Interfaces
{
    public interface IOfferService
    {
        Task<Offer> CreateOfferAsync(Offer offer);
        Task<List<Offer>> SearchOffersAsync(string query);
        Task<List<Supplier>> GetPopularSuppliersAsync();
    }
}
