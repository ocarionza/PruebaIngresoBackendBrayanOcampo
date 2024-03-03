using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dto
{
    public class ResponseDto
    {
        public List<JourneyDto> Journeys { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }

        public ResponseDto(List<JourneyDto> JourneyDto, string message, string status)
        {
            Journeys = JourneyDto;
            Message = message;
            Status = status;
        }
    }
}
