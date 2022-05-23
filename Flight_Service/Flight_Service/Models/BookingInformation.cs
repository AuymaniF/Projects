using Flight_Service.Data;
using System.ComponentModel.DataAnnotations;

namespace Flight_Service.Models
{
    public class BookingInformation
    {
        public int Id { get; set; }

        public int FlightId { get; set; }
        public int PassengerId { get; set; }
        public int ReservationNumber { get; set; }
        public Flight? Flight { get; set; }

        public Passenger? Passenger { get; set; }

        public static BookingInformation AddPassengerToFlight(FlightContext ctx, int flightId, int passengerId)
        {
            Random random = new Random();
            var passAdd = new BookingInformation()
            {
                FlightId = flightId,
                Flight = ctx.Flights.Find(flightId) ?? new Flight(),
                PassengerId = passengerId,
                Passenger = ctx.Passengers.Find(passengerId) ?? new Passenger(),
                ReservationNumber = random.Next(0, 10000)
            };
            ctx.SaveChanges();

            return passAdd;
        }
    }
}
