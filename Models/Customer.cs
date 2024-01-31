using BogsyVideoStore.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace BogsyVideoStore.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Phone(ErrorMessage = "Invalid Contact Number")]
        public string ContactNo { get; set; }
        public Sex Sex { get; set; }

    }
}
