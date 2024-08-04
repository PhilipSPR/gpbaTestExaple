using gpbaTestExaple.Models;

namespace gpbaTestExaple.Interfaces
{
    public interface ISupplierRepository
    {
        Task<Supplier> AddAsync(Supplier supplier);
        Task<List<Supplier>> GetAllAsync();
    }
}
