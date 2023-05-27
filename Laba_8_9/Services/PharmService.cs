using Laba_7.Models;
using System.Xml.Linq;

namespace Laba_7.Services
{
    public class PharmService : IPharmService
    {
        private readonly List<Pharma> _pharma = new();

        public PharmService()
        {
            _pharma.AddRange(new List<Pharma>
            {
                new Pharma { Id = 1, Name="Aspirin", Type="protivozastudne"},
                new Pharma { Id = 2, Name="Аспирин", Type="анальгетик"},
                new Pharma { Id = 3, Name="Ибупрофен", Type="противовоспалительное"},
                new Pharma { Id = 4, Name="Амоксициллин", Type="антибиотик"},
                new Pharma { Id = 5, Name="Левотироксин ", Type="гормональное "},
                new Pharma { Id = 6, Name="Метформин ", Type="антидиабетическое "},
                new Pharma { Id = 7, Name="Атенолол", Type="бета-адреноблокатор"},
                new Pharma { Id = 8, Name="Лоратадин", Type="антигистаминное"},
                new Pharma { Id = 9, Name="Симвастатин", Type="статин"},
                new Pharma { Id = 10, Name="Алпразолам", Type="анксиолитик"}
            });
        }

        public async Task<IEnumerable<Pharma>> GetAllAsync()
        {
            return _pharma;
        }

        public async Task<Pharma> GetByIdAsync(int id)
        {
            return _pharma.FirstOrDefault(a => a.Id == id);
        }

        public async Task<Pharma> AddAsync(Pharma pharm)
        {
            _pharma.Add(pharm);
            return pharm;
        }

        public async Task UpdateAsync(Pharma pharm)
        {
            var existingPharm = _pharma.FirstOrDefault(a => a.Id == pharm.Id);
            if (existingPharm != null)
            {
                existingPharm.Name = pharm.Name;
                existingPharm.Type = pharm.Type;
            }
        }

        public async Task DeleteAsync(int id)
        {
            var pharm = _pharma.FirstOrDefault(a => a.Id == id);
            if (pharm != null)
            {
                _pharma.Remove(pharm);
            }
        }
    }
}
