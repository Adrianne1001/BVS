using BogsyVideoStore.Models;

namespace BogsyVideoStore.Interfaces
{
    public interface IRentalRepository
    {
        Task<IEnumerable<Rental>> GetAll();
        Task<IEnumerable<Rental>> GetAllByCustomer(string name);
        Task<Rental> GetByIdAsync(int id);
        Task<Rental> GetByIdAsyncNoTracking(int id);
        bool Add(Rental rental);
        bool Update(Rental rental);
        bool Delete(Rental rental);
        bool Save();
    }
}
