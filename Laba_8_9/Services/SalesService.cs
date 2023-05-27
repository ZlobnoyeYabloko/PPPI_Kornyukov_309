using Laba_7.Models;

namespace Laba_7.Services
{
    public class SalesService : ISalesService
    {
        private readonly List<Sales> _sales = new();

        public SalesService()
        {
            _sales.AddRange(new List<Sales>
            {
                new Sales { Id = 1, price = 100, PharmId = 1 },
                new Sales { Id = 2, price = 100, PharmId= 2},
                new Sales { Id = 3, price = 110, PharmId= 2},
                new Sales { Id = 4, price = 100, PharmId = 10 },
                new Sales { Id = 5, price = 150, PharmId= 9},
                new Sales { Id = 6, price = 50, PharmId= 8},
                new Sales { Id = 7, price = 110, PharmId= 7},
                new Sales { Id = 8, price = 75, PharmId = 6 },
                new Sales { Id = 9, price = 115, PharmId= 4},
                new Sales { Id = 10, price = 60, PharmId= 5}

            });
        }

        public async Task<IEnumerable<Sales>> GetAllAsync()
        {
            return _sales;
        }

        public async Task<Sales> GetByIdAsync(int id)
        {
            return _sales.FirstOrDefault(c => c.Id == id);
        }

        public async Task<Sales> AddAsync(Sales sale)
        {
            _sales.Add(sale);
            return sale;
        }

        public async Task UpdateAsync(Sales sale)
        {
            var existingSale = _sales.FirstOrDefault(c => c.Id == sale.Id);
            if (existingSale != null)
            {
                existingSale.price = sale.price;
                existingSale.PharmId = sale.PharmId;
            }
        }

        public async Task DeleteAsync(int id)
        {
            var sale = _sales.FirstOrDefault(c => c.Id == id);
            if (sale != null)
            {
                _sales.Remove(sale);
            }
        }
    }
}
