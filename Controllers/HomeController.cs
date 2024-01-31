using BogsyVideoStore.Interfaces;
using BogsyVideoStore.Models;
using BogsyVideoStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BogsyVideoStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRentalRepository _rentalRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IVideoRepository _videoRepository;


        public HomeController(ILogger<HomeController> logger, IRentalRepository rentalRepository, ICustomerRepository customerRepository, IVideoRepository videoRepository)
        {
            _logger = logger;
            _rentalRepository = rentalRepository;
            _customerRepository = customerRepository;
            _videoRepository = videoRepository;
        }

        public async Task<IActionResult> Index()
        {

            var totalCustomers = _customerRepository.Count();
            var totalVideoStocks = _videoRepository.SumQtyTotal();
            var totalVideoAvailable = _videoRepository.SumQtyIn();
            var rentals = await _rentalRepository.GetAll();

            var homeVM = new HomeViewModel
            {
                TotalRegisteredCustomers = totalCustomers,
                TotalVideoStocks = totalVideoStocks,
                TotalVideoAvailable = totalVideoAvailable,
                Rentals = rentals

            };
            return View(homeVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}