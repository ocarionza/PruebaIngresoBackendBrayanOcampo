using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dto
{
    public class ResponseFligthDto
    {
        public string DepartureStation { get; set; }

        public string ArrivalStation { get; set; }

        public string FlightCarrier { get; set; }

        public string FlightNumber { get; set; }

        public double Price { get; set; }

        public ResponseFligthDto(string departureStation, string arrivalStation, string flightCarrier, string flightNumber, double price)
        {
            DepartureStation = departureStation;
            ArrivalStation = arrivalStation;
            FlightCarrier = flightCarrier;
            FlightNumber = flightNumber;
            Price = price;
        }
    }
}
