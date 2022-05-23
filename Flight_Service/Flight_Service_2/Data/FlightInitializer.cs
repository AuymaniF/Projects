using Flight_Service.Models;
using Microsoft.EntityFrameworkCore;

namespace Flight_Service.Data
{
    public class FlightInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {

            using (var context = new FSContext(serviceProvider.GetRequiredService<DbContextOptions<FSContext>>()))
            {
                //context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                if (!context.Flights.Any())
                {
                    var flightsToAdd = new Flight[]
                    {
						new Flight{ AirLine = "Taquan Air", Gate = "D", PassengerLimit = 508, DepartureAirport = "Bajaur Agency", ArrivalAirport = "Vienna", DepartureDateTime = DateTime.Today, ArrivalDateTime = DateTime.Today },
						new Flight{AirLine = "Taquan Air",Gate = "A",PassengerLimit = 449,DepartureAirport = "Silvassa",ArrivalAirport = "Bellville",DepartureDateTime = DateTime.Today, ArrivalDateTime = DateTime.Today},
						new Flight{ AirLine = "Wagner Airways", Gate = "D", PassengerLimit = 555, DepartureAirport = "Sagay", ArrivalAirport = "Voronezh", DepartureDateTime = DateTime.Today, ArrivalDateTime = DateTime.Today },
						new Flight{ AirLine = "United Express", Gate = "E", PassengerLimit = 494, DepartureAirport = "Schwaz", ArrivalAirport = "Ödemiş", DepartureDateTime = DateTime.Today, ArrivalDateTime = DateTime.Today},
						new Flight{ AirLine = "Superior Aviation", Gate = "B", PassengerLimit = 534, DepartureAirport = "Camponogara", ArrivalAirport = "Sapele", DepartureDateTime = DateTime.Today, ArrivalDateTime = DateTime.Today}
					};

                    context.Flights.AddRange(flightsToAdd);
                    context.SaveChanges();
                }

                if (!context.Passengers.Any())
                {
                    var PassengersToAdd = new Passenger[]
                    {
                        new Passenger{ FirstName = "Haley", LastName = "Blanchard", Job = "IT", email = "lectus.convallis@icloud.edu", Age = 30},
                        new Passenger{ FirstName = "Keelie", LastName = "Barlow", Job = "Developer", email = "volutpat@outlook.net", Age = 76},
                        new Passenger{ FirstName = "Salvador", LastName = "Rose", Job = "Developer", email = "enim@yahoo.couk", Age = 51},
                        new Passenger{ FirstName = "Cooper", LastName = "Burks", Job = "CEO", email = "lorem.ipsum.dolor@icloud.edu", Age = 40},
                        new Passenger{ FirstName = "Sawyer", LastName = "Sweeney", Job = "Developer", email = "erat@outlook.net", Age = 28},
                        new Passenger{ FirstName = "Anastasia", LastName = "Schwartz", Job = "Event Planner", email = "eget.massa@google.ca", Age = 66},
                        new Passenger{ FirstName = "Adrienne", LastName = "Carr", Job = "Event Planner", email = "ut.odio.vel@yahoo.net", Age = 20 }
                    };
                    context.Passengers.AddRange(PassengersToAdd);
                    context.SaveChanges();
                }
            };

        }

    }
}
