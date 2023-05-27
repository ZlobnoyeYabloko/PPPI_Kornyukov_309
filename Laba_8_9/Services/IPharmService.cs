using Laba_7.Models;

namespace Laba_7.Services
{
        public interface IPharmService
        {
            Task<IEnumerable<Pharma>> GetAllAsync();
            Task<Pharma> GetByIdAsync(int id);
            Task<Pharma> AddAsync(Pharma pharma);
            Task UpdateAsync(Pharma pharma);
            Task DeleteAsync(int id);
        }
}
