using gpbaTestExaple.Interfaces;
using gpbaTestExaple.Models;

namespace gpbaTestExaple.Implementations.Services
{
    public class OfferService : IOfferService
    {
        private readonly IOfferRepository _offerRepository;

        public OfferService(IOfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
        }

        public async Task<Offer> CreateOfferAsync(Offer offer)
        {
            try
            {
                return await _offerRepository.AddAsync(offer);
            }
            catch (Exception ex)
            {
                throw new Exception($"При добавлении оффера возникла ошибка: {ex.Message}");
            }
        }

        public async Task<List<Offer>> SearchOffersAsync(string query)
        {
            try
            {
                return await _offerRepository.SearchAsync(query);
            }
            catch (Exception ex)
            {
                throw new Exception($"При поиске оффера возникла ошибка: {ex.Message}");
            }
        }

        public async Task<List<Supplier>> GetPopularSuppliersAsync()
        {
            try
            {
                return await _offerRepository.GetPopularSuppliersAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"При поиске оффера возникла ошибка: {ex.Message}");
            }
        }
    }
}
