using BogsyVideoStore.Data;
using BogsyVideoStore.Interfaces;
using BogsyVideoStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BogsyVideoStore.Repositories
{
    public class RentalRepository : IRentalRepository
    {
        private readonly AppDbContext _context;

        public RentalRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Rental>> GetAll()
        {
            return await _context.Rentals.Include(c => c.Customer).Include(v => v.Video).ToListAsync();
        }

        public async Task<Rental> GetByIdAsync(int id)
        {
            return await _context.Rentals.Include(c => c.Customer).Include(v => v.Video).FirstOrDefaultAsync(i => i.Id == id);
        }
        public async Task<Rental> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Rentals.Include(c => c.Customer).Include(v => v.Video).AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }
        public async Task<IEnumerable<Rental>> GetAllByCustomer(string name)
        {
            return await _context.Rentals.Include(c => c.Customer).Include(v => v.Video).Where(n => n.Customer.Name.Contains(name)).ToListAsync();
        }

        public bool Add(Rental rental)
        {
            _context.Add(rental);
            return Save();
        }
        public bool Update(Rental rental)
        {
            _context.Update(rental);
            return Save();
        }

        public bool Delete(Rental rental)
        {
            _context.Remove(rental);
            return Save(); ;
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

    }
}
