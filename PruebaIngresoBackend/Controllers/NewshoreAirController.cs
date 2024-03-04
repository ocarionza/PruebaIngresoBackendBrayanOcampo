using Business.Dto;
using Business.Services;
using Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaIngresoBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewshoreAirController : ControllerBase
    {
        private readonly IJourneyService _journeyService;

        public NewshoreAirController(IJourneyService journeyService)
        {
            _journeyService = journeyService;
        }

        [HttpGet("journey")]
        public async Task<ResponseDto> GetJourney([FromQuery] string origin, [FromQuery] string destination, [FromQuery] int number_of_flights)
        {
            try
            {
                ParamsDto request = new ParamsDto(origin, destination, number_of_flights);

                ResponseDto result = await _journeyService.getJourney(request);

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
