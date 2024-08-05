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
            return await _context.Offers
                .Join(
                    _context.Suppliers,
                    offer => offer.SupplierId,
                    supplier => supplier.Id,
                    (offer, supplier) => new { Offer = offer, Supplier = supplier }
                )
                .Where(result => result.Offer.Brand.Contains(query)
                    || result.Offer.Model.Contains(query)
                    || result.Supplier.Name.Contains(query))
                .Select(result => new
                {
                    result.Offer.Id,
                    result.Offer.Brand,
                    result.Offer.Model,
                    result.Offer.SupplierId,
                    SupplierName = result.Supplier.Name,
                    result.Offer.RegistrationDate
                })
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
