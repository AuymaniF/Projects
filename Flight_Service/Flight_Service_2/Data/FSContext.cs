using Flight_Service.Models;
using Microsoft.EntityFrameworkCore;


namespace Flight_Service.Data
{
    public class FSContext : DbContext
    {
        public FSContext()
        {

        }

        public FSContext(DbContextOptions<FSContext> options) : base(options)
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

            //modelbuilder.Entity<BookingInformation>()
            //    .HasOne<Passenger>()
            //    .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
