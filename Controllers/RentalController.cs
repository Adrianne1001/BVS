using BogsyVideoStore.Data.Enum;
using BogsyVideoStore.Interfaces;
using BogsyVideoStore.Models;
using BogsyVideoStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BogsyVideoStore.Controllers
{
    public class RentalController : Controller
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IVideoRepository _videoRepository;

        public RentalController(IRentalRepository rentalRepository, ICustomerRepository customerRepository, IVideoRepository videoRepository)
        {
            _rentalRepository = rentalRepository;
            _customerRepository = customerRepository;
            _videoRepository = videoRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Rental> rentals = await _rentalRepository.GetAll();
            return View(rentals);
        }
        public async Task<IActionResult> Rent()
        {
            var customers = await _customerRepository.GetAll();
            var customerSelectList = new SelectList(customers, "Id", "Name");
            ViewBag.CustomerSelectList = customerSelectList;

            var videos = await _videoRepository.GetAllAlphabetically();
            var videoSelectList = new SelectList(videos, "Id", "Title");
            ViewBag.VideoSelectList = videoSelectList;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Rent(Rental rental)
        {
            if (!ModelState.IsValid)
            {
                return View(rental);
            }
            var video = await _videoRepository.GetByIdAsyncNoTracking((int)rental.VideoId);
            video.QtyIn -= rental.QtyRented;
            video.QtyOut += rental.QtyRented;
            _videoRepository.Update(video);

            var rentalDetails = new Rental
            {
                DateRented = DateTime.Now,
                //RentDueDate = DateTime.Now.AddDays((int)video.rentDuration + 1),
                RentDueDate = DateTime.Now.AddMinutes((int)video.rentDuration + 1),
                QtyRented = rental.QtyRented,
                RentCharge = video.VideoType == VideoType.VCD ? 25 * rental.QtyRented : 50 * rental.QtyRented,
                CustomerId = rental.CustomerId,
                VideoId = rental.VideoId,
            };
            _rentalRepository.Add(rentalDetails);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Return(int id)
        {
            var rental = await _rentalRepository.GetByIdAsync(id);
            if (rental == null) return View("Error");

            int daysOverdue = (int)(DateTime.Now - rental.RentDueDate).TotalDays;
            decimal dueFees = daysOverdue > 0 ? 5 * daysOverdue * rental.QtyRented : 0;

            var returnVM = new ReturnRentalViewModel
            {
                Id = id,
                CustomerId = rental.CustomerId,
                Customer = rental.Customer,
                VideoId = rental.VideoId,
                Video = rental.Video,
                DateRented = rental.DateRented,
                RentDuration = rental.Video.rentDuration,
                DueDate = rental.RentDueDate,
                QtyRented = rental.QtyRented,
                OriginalCharge = rental.RentCharge,
                DueFees = (int)dueFees,
                TotalCharge = rental.RentCharge + (int)dueFees
            };
            return View(returnVM);
        }
        [HttpPost]
        public async Task<IActionResult> Return(int id, ReturnRentalViewModel returnVM)
        {

            var rental = await _rentalRepository.GetByIdAsync(id);
            if (rental == null)
            {
                return View("Error");
            }
            var videoDetails = await _videoRepository.GetByIdAsync(returnVM.VideoId);
            videoDetails.QtyIn += returnVM.QtyRented;
            videoDetails.QtyOut -= returnVM.QtyRented;

            _videoRepository.Update(videoDetails);
            _rentalRepository.Delete(rental);
            return RedirectToAction("Index");
        }



    }
}
