using Laba_7.Models;

namespace Laba_7.Services
{
    public interface ISalesService
    {
        Task<IEnumerable<Sales>> GetAllAsync();
        Task<Sales> GetByIdAsync(int id);
        Task<Sales> AddAsync(Sales sale);
        Task UpdateAsync(Sales sale);
        Task DeleteAsync(int id);
    }
}
