using DataAccess.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dto
{
    public class FlightDto
    {
        public string Origin { get; set; }

        public string Destination { get; set; }

        public double Price { get; set; }

        public TransportDto Transport { get; set; }

        public FlightDto(TransportDto transport, string origin, string destination, double price)
        {
            Transport = transport;
            Origin = origin;
            Destination = destination;
            Price = price;
        }
    }
}
