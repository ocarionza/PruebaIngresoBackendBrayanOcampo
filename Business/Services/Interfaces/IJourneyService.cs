using Business.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfaces
{
    public interface IJourneyService
    {
        public Task<ResponseDto> getJourney(ParamsDto request);

        public string test(string origin, string destination);
    }
}
