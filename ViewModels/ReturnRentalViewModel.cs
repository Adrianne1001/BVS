using BogsyVideoStore.Data.Enum;
using BogsyVideoStore.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BogsyVideoStore.ViewModels
{
    public class ReturnRentalViewModel
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Customer")]
        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }
        [ForeignKey("Video")]
        public int VideoId { get; set; }
        public Video? Video { get; set; }
        public DateTime DateRented { get; set; }
        public DateTime DueDate { get; set; }
        public RentDuration RentDuration { get; set; }
        public int QtyRented { get; set; }
        public int OriginalCharge { get; set; }
        public int? DueFees { get; set; }
        public int TotalCharge { get; set; }
    }
}
