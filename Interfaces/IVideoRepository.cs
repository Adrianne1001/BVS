using BogsyVideoStore.Models;

namespace BogsyVideoStore.Interfaces
{
    public interface IVideoRepository
    {
        Task<IEnumerable<Video>> GetAllAlphabetically();
        Task<Video> GetByIdAsync(int id);
        Task<Video> GetByIdAsyncNoTracking(int id);
        int SumQtyTotal();
        int SumQtyIn();
        bool Add(Video video);
        bool Update(Video video);
        bool Delete(Video video);
        bool Save();
    }
}
