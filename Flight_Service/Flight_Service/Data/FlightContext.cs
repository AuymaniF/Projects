using Flight_Service.Models;
using Microsoft.EntityFrameworkCore;


namespace Flight_Service.Data
{
    public class FlightContext : DbContext
    {
        public FlightContext()
        {

        }

        public FlightContext(DbContextOptions<FlightContext> options) : base(options)
        {

        }

        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<BookingInformation> Bookings { get; set; }
        //public DbSet<Pilot> Pilots { get; set; }


        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Passenger>()
                .HasMany(p => p.Flights)
                .WithMany(c => c.Passengers)
                .UsingEntity<BookingInformation>();

            modelbuilder.Entity<Flight>()
                .HasMany(p => p.Passengers)
                .WithMany(c => c.Flights)
                .UsingEntity<BookingInformation>();

            modelbuilder.Entity<BookingInformation>()
                .HasOne<Passenger>()
                .WithMany(p => p.Confirmation)
                .HasForeignKey(p => p.PassengerId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
