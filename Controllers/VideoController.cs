using BogsyVideoStore.Interfaces;
using BogsyVideoStore.Models;
using BogsyVideoStore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BogsyVideoStore.Controllers
{
    public class VideoController : Controller
    {
        private readonly IVideoRepository _videoRepository;

        public VideoController(IVideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Video> videos = await _videoRepository.GetAllAlphabetically();
            return View(videos);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Video video)
        {
            if (!ModelState.IsValid)
            {
                return View(video);
            }
            var videoDetails = new Video
            {
                Title = video.Title,
                Genre = video.Genre,
                VideoType = video.VideoType,
                rentDuration = video.rentDuration,
                QtyTotal = video.QtyTotal,
                QtyIn = video.QtyTotal,
                QtyOut = 0
            };
            _videoRepository.Add(videoDetails);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var video = await _videoRepository.GetByIdAsync(id);
            if (video == null) return View("Error");
            var clubVM = new EditVideoViewModel
            {
                Title = video.Title,
                VideoType = video.VideoType,
                Genre = video.Genre,
                RentDuration = video.rentDuration,
                QtyTotal = video.QtyTotal,
            };

            return View(clubVM);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditVideoViewModel editVideoVM)
        {
            if (!ModelState.IsValid)
            {
                return View(editVideoVM);
            }
            var videoDetails = await _videoRepository.GetByIdAsyncNoTracking(id);

            var video = new Video
            {
                Id = id,
                Title = editVideoVM.Title,
                VideoType = editVideoVM.VideoType,
                Genre = editVideoVM.Genre,
                rentDuration = editVideoVM.RentDuration,
                QtyTotal = editVideoVM.QtyTotal,
                QtyIn = (editVideoVM.QtyTotal - videoDetails.QtyTotal) + videoDetails.QtyIn,
                QtyOut = videoDetails.QtyOut,
            };
            _videoRepository.Update(video);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var video = await _videoRepository.GetByIdAsync(id);
            return View(video);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteVideo(int id)
        {
            var video = await _videoRepository.GetByIdAsync(id);
            _videoRepository.Delete(video);
            return RedirectToAction("Index");
        }
    }
}
