using Business.Dto;
using Business.Services.Interfaces;
using DataAccess.Repository.Interfaces;
using DataAccess.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class JourneyService : IJourneyService
    {
        private readonly IGenericRepository<Journey> _journeyRepo;
        private readonly IGenericRepository<Fligth> _flightRepo;
        private readonly IGenericRepository<JourneyFlight> _journeyflightRepo;
        private readonly IGenericRepository<Transport> _transportRepo;
        public JourneyService(IGenericRepository<Journey> journeyRepo, IGenericRepository<Fligth> flightRepo, IGenericRepository<JourneyFlight> journeyflightRepo, IGenericRepository<Transport> transportRepo)
        {
            _journeyRepo = journeyRepo;
            _flightRepo = flightRepo;
            _journeyflightRepo = journeyflightRepo;
            _transportRepo = transportRepo;
        }
        public Task<ResponseDto> getJourney(ParamsDto request)
        {
            throw new NotImplementedException();
        }

        public string test(string origin, string destination)
        {
            return "Ruta de vuelo de " + origin + " a " + destination;
        }

    }
}
