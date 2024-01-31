using BogsyVideoStore.Data;
using BogsyVideoStore.Interfaces;
using BogsyVideoStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BogsyVideoStore.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _context.Customers.FirstOrDefaultAsync(i => i.Id == id);
        }

        public int Count()
        {
            return _context.Customers.Count();
        }
        public bool Add(Customer customer)
        {
            _context.Add(customer);
            return Save();
        }

        public bool Update(Customer customer)
        {
            _context.Update(customer);
            return Save();
        }
        public bool Delete(Customer customer)
        {
            _context.Remove(customer);
            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
