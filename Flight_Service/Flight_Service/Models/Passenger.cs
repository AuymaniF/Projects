using System.ComponentModel.DataAnnotations;

namespace Flight_Service.Models
{
    public class Passenger
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string Job { get; set; } = string.Empty;
        [Required]
        public string email { get; set; } = string.Empty;
        [Required]
        public int Age { get; set; }

        //Booking/ Conformation multiple per person?
        //public BookingInformation? BookingInfo { get; set; }
        public ICollection<BookingInformation>? Confirmation { get; set; }

        //public Flight? Flight { get; set; }
        public ICollection<Flight>? Flights { get; set; }
    }
}
