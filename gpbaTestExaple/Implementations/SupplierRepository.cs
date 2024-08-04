using gpbaTestExaple.Data;
using gpbaTestExaple.Interfaces;
using gpbaTestExaple.Models;
using Microsoft.EntityFrameworkCore;

namespace gpbaTestExaple.Implementations
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly ApplicationDbContext _context;

        public SupplierRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Supplier> AddAsync(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();
            return supplier;
        }

        public async Task<List<Supplier>> GetAllAsync()
        {
            return await _context.Suppliers.ToListAsync();
        }
    }
}
