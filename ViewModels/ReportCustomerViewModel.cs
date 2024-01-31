using BogsyVideoStore.Models;

namespace BogsyVideoStore.ViewModels
{
    public class ReportCustomerViewModel
    {
        public IEnumerable<Rental> Rentals { get; set; }
        public string Name { get; set; }
    }
}
