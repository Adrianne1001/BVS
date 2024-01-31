using BogsyVideoStore.Data;
using BogsyVideoStore.Interfaces;
using BogsyVideoStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BogsyVideoStore.Repositories
{
    public class VideoRepository : IVideoRepository
    {
        private readonly AppDbContext _context;

        public VideoRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Video>> GetAllAlphabetically()
        {
            return await _context.Videos.OrderBy(v => v.Title).ToListAsync();
        }

        public async Task<Video> GetByIdAsync(int id)
        {
            return await _context.Videos.FirstOrDefaultAsync(i => i.Id == id);
        }
        public async Task<Video> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Videos.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }
        public bool Add(Video video)
        {
            _context.Add(video);
            return Save();
        }
        public bool Update(Video video)
        {
            _context.Update(video);
            return Save();
        }

        public bool Delete(Video video)
        {
            _context.Remove(video);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public int SumQtyTotal()
        {
            return _context.Videos.Sum(v => v.QtyTotal);
        }

        public int SumQtyIn()
        {
            return _context.Videos.Sum(v => v.QtyIn);
        }
    }
}
