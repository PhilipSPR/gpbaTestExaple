using gpbaTestExaple.Interfaces;
using gpbaTestExaple.Models;

namespace gpbaTestExaple.Implementations.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<Supplier> CreateSupplierAsync(Supplier supplier)
        {
            return await _supplierRepository.AddAsync(supplier);
        }

        public async Task<List<Supplier>> GetAllSuppliersAsync()
        {
            return await _supplierRepository.GetAllAsync();
        }
    }
}
