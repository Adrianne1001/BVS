using BogsyVideoStore.Data.Enum;

namespace BogsyVideoStore.ViewModels
{
    public class EditVideoViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public VideoType VideoType { get; set; }
        public Genre Genre { get; set; }
        public RentDuration RentDuration { get; set; }
        public int QtyTotal { get; set; }
    }
}
