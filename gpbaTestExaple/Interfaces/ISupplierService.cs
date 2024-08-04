using gpbaTestExaple.Models;

namespace gpbaTestExaple.Interfaces
{
    public interface ISupplierService
    {
        Task<Supplier> CreateSupplierAsync(Supplier supplier);
        Task<List<Supplier>> GetAllSuppliersAsync();
    }
}
