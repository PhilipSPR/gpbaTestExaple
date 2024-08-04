using gpbaTestExaple.Data;
using gpbaTestExaple.Interfaces;
using gpbaTestExaple.Models;
using Microsoft.EntityFrameworkCore;

namespace gpbaTestExaple.Implementations
{
    public class OfferRepository : IOfferRepository
    {
        private readonly ApplicationDbContext _context;

        public OfferRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Offer> AddAsync(Offer offer)
        {
            _context.Offers.Add(offer);
            await _context.SaveChangesAsync();
            return offer;
        }

        public async Task<List<Offer>> SearchAsync(string query)
        {
            int supplerId; 
            int.TryParse(query, out supplerId);
            return await _context.Offers
                .Include(o => o.SupplierId)
                .Where(o => o.Brand.Contains(query) || o.Model.Contains(query) || o.SupplierId == supplerId)
                .ToListAsync();
        }

        public async Task<List<Supplier>> GetPopularSuppliersAsync()
        {
            return await _context.Suppliers
                .Include(s => s.Name)
                .OrderByDescending(s => s.Name.Count())
                .Take(3)
                .ToListAsync();
        }
    
    }
}
