using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Business.Dto
{
    public class ParamsDto
    {
        [JsonPropertyName("origin")]
        public string Origin { get; set; }

        [JsonPropertyName("destination")]
        public string Destination { get; set; }

        [JsonPropertyName("number_of_flights")]
        public int? NumberOfFlights { get; set; }

        public ParamsDto(String origin, String destination, int number_of_flights)
        {
            Origin = origin;
            Destination = destination;
            NumberOfFlights = number_of_flights;   
        }
    }
}
