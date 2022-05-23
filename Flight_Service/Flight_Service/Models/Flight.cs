namespace Flight_Service.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public string AirLine { get; set; } = string.Empty;
        public string Gate { get; set; } = string.Empty;
        public int PassengerLimit { get; set; }
        //public int PilotLimit { get; set; }
        //public bool isCommercial { get; set; }

        public ICollection<Passenger>? Passengers { get; set; } = new List<Passenger>();
        //public ICollection<BookingInformation>? Passengers { get; set; } = new List<BookingInformation>(); 
        public int TotalPassengers => Passengers.Count;


        //public ICollection<Pilot>? Pilots { get; set; } = new List<Pilot>();
        //public int TotalPilot => Pilots.Count;

        public string DepartureAirport { get; set; } = string.Empty;
        public string ArrivalAirport { get; set; } = string.Empty;

        public DateTime DepartureDateTime { get; set; } = new DateTime();
        public DateTime ArrivalDateTime { get; set; } = new DateTime();

        //public TimeOnly DepartTime { get; set; } = new TimeOnly();
        //public TimeOnly ArrivalTime { get; set; } = new TimeOnly();

        

        }
}
