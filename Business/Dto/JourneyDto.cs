using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dto
{
    public class JourneyDto
    {
        
        public string Origin { get; set; }

        public string Destination { get; set; }

        public double Price { get; set; }

        public List<FlightDto> Flights { get; set; }

        public JourneyDto(List<FlightDto> flights, string origin, string destination, double price)
        {
            Flights = flights;
            Origin = origin;
            Destination = destination;
            Price = price;
        }
    }
}
