using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dto
{
    public class TransportDto
    {
        public string FlightCarrier { get; set; }

        public string FlightNumber { get; set; }

        public TransportDto(string flightCarrier, string flightNumber)
        {
            FlightCarrier = flightCarrier;
            FlightNumber = flightNumber;
        }
    }
}
