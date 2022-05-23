using Flight_Service.Data;
using System.ComponentModel.DataAnnotations;

namespace Flight_Service.Models
{
    public class BookingInformation
    {
        public int Id { get; set; }
        public int PassengerId { get; set; }
        public int FlightId { get; set; }
        public int ReservationNumber { get; set; }
        public Flight? Flight { get; set; } = new Flight();

        public Passenger? Passenger { get; set; } = new Passenger();

        public static BookingInformation AddPassengerToFlight(FSContext ctx, int flightId, int passengerId)
        {
            Random random = new Random();
            var passAdd = new BookingInformation()
            {
                FlightId = flightId,
                Flight = ctx.Flights.Find(flightId),
                PassengerId = passengerId,
                Passenger = ctx.Passengers.Find(passengerId),
                ReservationNumber = random.Next()
            };
            ctx.SaveChanges();

            return passAdd;

        }
    }
}
