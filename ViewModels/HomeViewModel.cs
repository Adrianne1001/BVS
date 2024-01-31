using BogsyVideoStore.Models;

namespace BogsyVideoStore.ViewModels
{
    public class HomeViewModel
    {
        public int TotalRegisteredCustomers { get; set; }
        public int TotalVideoStocks { get; set; }
        public int TotalVideoAvailable { get; set; }
        public IEnumerable<Rental> Rentals { get; set; }
    }
}
