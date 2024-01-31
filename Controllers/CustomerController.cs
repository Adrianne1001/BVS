using BogsyVideoStore.Interfaces;
using BogsyVideoStore.Models;
using BogsyVideoStore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BogsyVideoStore.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IRentalRepository _rentalRepository;

        public CustomerController(ICustomerRepository customerRepository, IRentalRepository rentalRepository)
        {
            _customerRepository = customerRepository;
            _rentalRepository = rentalRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Customer> customers = await _customerRepository.GetAll();
            return View(customers);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View(customer);
            }

            _customerRepository.Add(customer);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            return View(customer);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View(customer);
            }
            _customerRepository.Update(customer);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Report(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            var rentals = await _rentalRepository.GetAllByCustomer(customer.Name);

            var reportVM = new ReportCustomerViewModel
            {
                Rentals = rentals,
                Name = customer.Name
            };

            foreach (var rental in reportVM.Rentals)
            {
                int daysOverdue = (int)(DateTime.Now - rental.RentDueDate).TotalDays;
                int dueFees = daysOverdue > 0 ? 5 * daysOverdue * rental.QtyRented : 0;
                int totalCharge = dueFees + rental.RentCharge;

                //Demo
                //int minutesOverdue = (int)(DateTime.Now - rental.RentDueDate).TotalMinutes;
                //int dueFees = 5 * minutesOverdue * rental.QtyRented;
                //int totalCharge = dueFees + rental.RentCharge;

                rental.DueFees = dueFees;
                rental.TotalCharge = totalCharge;
            }

            return View(reportVM);
        }



    }
}
