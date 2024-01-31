using BogsyVideoStore.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace BogsyVideoStore.Models
{
    public class Video
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public Genre Genre { get; set; }
        public VideoType VideoType { get; set; }

        public RentDuration rentDuration { get; set; }
        public int QtyTotal { get; set; }
        public int QtyIn { get; set; }
        public int QtyOut { get; set; }
    }
}
