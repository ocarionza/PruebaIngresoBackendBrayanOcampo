using Azure;
using Business.Dto;
using Business.Services.Interfaces;
using DataAccess.Repository.Interfaces;
using DataAccess.Repository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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
        public async Task<ResponseDto> getJourney(ParamsDto request)
        {
            try
            {
                var journeydb = await _journeyRepo.GetAll();
                var search = journeydb.Where(x => x.Origin.Equals(request.Origin) && x.Destination.Equals(request.Destination));
                List<JourneyDto> journeys = new List<JourneyDto>();

                if (!search.IsNullOrEmpty())
                {
                    foreach (var journey in search)
                    {
                        JourneyDto journeydto = new JourneyDto(new List<FlightDto>(), journey.Origin, journey.Destination, journey.Price);

                        var journeyflightdb = await _journeyflightRepo.GetAll();
                        var journeyflightSearch = journeyflightdb.Where(x => x.JourneyId == journey.JourneyId)
                                                               .ToListAsync();

                        foreach (var journeyflight in await journeyflightSearch)
                        {
                            var flightdb = await _flightRepo.GetAll();
                            var flightSearch = flightdb.Where(x => x.FligthId == journeyflight.FligthId).ToListAsync();

                            foreach (var flight in await flightSearch)
                            {
                                var transportdb = await _transportRepo.GetAll();
                                var transporSearch = transportdb.Where(x => x.TransportId == flight.TransportId)
                                                               .ToListAsync();

                                foreach (var transport in await transporSearch)
                                {
                                    TransportDto transportdto = new TransportDto(transport.FligthCarrier, transport.FligthCarrierNumber);
                                    FlightDto flightDto = new FlightDto(transportdto, flight.Origin, flight.Destination, flight.Price);
                                    journeydto.Flights.Add(flightDto);
                                }
                            }
                        }
                        journeys.Add(journeydto);
                    }
                }
                else
                {
                    List<ResponseFligthDto> ResponseFligths = await ApiData();
                    //List<ResponseFligthDto> search = ResponseFligths.Where(f => f.DepartureStation == request.Origin && f.ArrivalStation == request.Destination).ToList();

                    List<FlightDto> flights = new List<FlightDto>();
                    foreach (var route in ResponseFligths)
                    {
                        FlightDto fly = new FlightDto(new TransportDto(route.FlightCarrier, route.FlightNumber), route.DepartureStation, route.ArrivalStation, route.Price);
                        flights.Add(fly);
                    }

                    journeys = CalculateRoutes(flights, request.Origin, request.Destination);

                    foreach (var route in journeys)
                    {
                        var JourneyDB = await _journeyRepo.Insert(new Journey()
                        {
                            Origin = route.Origin,
                            Destination = route.Destination,
                            Price = route.Price,
                        });
                        foreach (var flight in route.Flights)
                        {
                            var TransportDb = await _transportRepo.Insert(new Transport()
                            {
                                FligthCarrier = flight.Transport.FlightCarrier,
                                FligthCarrierNumber = flight.Transport.FlightNumber,
                            });
                            var FlightDb = await _flightRepo.Insert(new Fligth()
                            {
                                TransportId = TransportDb.TransportId,
                                Origin = flight.Origin,
                                Destination = flight.Destination,
                                Price = flight.Price,
                            });
                            var FlightJourneyDb = await _journeyflightRepo.Insert(new JourneyFlight()
                            {
                                FligthId = FlightDb.FligthId,
                                JourneyId = JourneyDB.JourneyId,
                            });
                        }
                    }
                }
                if (journeys.Count != 0)
                {
                    ResponseDto response = new ResponseDto(journeys, "The query has been successfully completed", "Sucess");
                    return response;
                }
                else
                {
                    ResponseDto response = new ResponseDto([], $"No results found with these parameters | Origin: {request.Origin} | Destination: {request.Destination}", "Failture");
                    return response;
                }
            }
            catch (Exception e)
            {
                ResponseDto response = new ResponseDto([], $"An error ocurred | Error: {e.Message}", "Failture");
                return response;
            }
     
        }

        public static List<JourneyDto> CalculateRoutes(List<FlightDto> flights, string origin, string destination, List<string> visited = null)
        {
            try
            {
                if (visited == null)
                    visited = new List<string>();

                List<JourneyDto> journeys = new List<JourneyDto>();

                foreach (FlightDto flight in flights)
                {
                    if (flight.Origin == origin && !visited.Contains(flight.Origin))
                    {
                        visited.Add(flight.Origin);

                        if (flight.Destination == destination)
                        {
                            List<FlightDto> fly = new List<FlightDto>() { flight };
                            JourneyDto journey = new JourneyDto(fly, origin, destination, flight.Price);
                            journeys.Add(journey);
                        }
                        else
                        {
                            List<JourneyDto> nextRoute = CalculateRoutes(flights, flight.Destination, destination, visited);

                            if (nextRoute != null && nextRoute.Count > 0)
                            {
                                List<FlightDto> fly = new List<FlightDto>() { flight };
                                JourneyDto journey = new JourneyDto(fly, flight.Origin, destination, flight.Price + nextRoute.Sum(x => x.Price));
                                journey.Flights.AddRange(nextRoute.SelectMany(x => x.Flights));
                                journeys.Add(journey);
                            }
                        }
                        visited.Remove(flight.Origin);
                    }
                }

                return journeys;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string test(string origin, string destination)
        {
            return "Ruta de vuelo de " + origin + " a " + destination;
        }

        public async Task<List<ResponseFligthDto>> ApiData()
        {
            try
            {
                List<ResponseFligthDto> ResponseFligths = new List<ResponseFligthDto>();
                //var httpclient = new HttpClient();
                //var response = await httpclient.GetAsync("https://recruiting-api.newshore.es/api/flights/2");

                //if (response.IsSuccessStatusCode)
                //{
                string data = "[{\"DepartureStation\":\"MZL\",\"ArrivalStation\":\"CAL\",\"FlightCarrier\":\"AV\",\"FlightNumber\":\"8020\",\"Price\":1000},{\"DepartureStation\":\"BOG\",\"ArrivalStation\":\"CAL\",\"FlightCarrier\":\"AV\",\"FlightNumber\":\"8040\",\"Price\":2000},{\"DepartureStation\":\"MZL\",\"ArrivalStation\":\"BOG\",\"FlightCarrier\":\"AV\",\"FlightNumber\":\"8041\",\"Price\":2000},{\"DepartureStation\":\"BOG\",\"ArrivalStation\":\"CAL\",\"FlightCarrier\":\"AV\",\"FlightNumber\":\"8042\",\"Price\":3000},{\"DepartureStation\":\"BOG\",\"ArrivalStation\":\"CTG\",\"FlightCarrier\":\"AV\",\"FlightNumber\":\"8043\",\"Price\":1000},{\"DepartureStation\":\"MED\",\"ArrivalStation\":\"BOG\",\"FlightCarrier\":\"AV\",\"FlightNumber\":\"8044\",\"Price\":2000},{\"DepartureStation\":\"BOG\",\"ArrivalStation\":\"MAD\",\"FlightCarrier\":\"AV\",\"FlightNumber\":\"8045\",\"Price\":5000},{\"DepartureStation\":\"MAD\",\"ArrivalStation\":\"BOG\",\"FlightCarrier\":\"AV\",\"FlightNumber\":\"8046\",\"Price\":5000},{\"DepartureStation\":\"MED\",\"ArrivalStation\":\"PER\",\"FlightCarrier\":\"AV\",\"FlightNumber\":\"8046\",\"Price\":1000},{\"DepartureStation\":\"MZL\",\"ArrivalStation\":\"PER\",\"FlightCarrier\":\"AV\",\"FlightNumber\":\"8047\",\"Price\":1000},{\"DepartureStation\":\"CAL\",\"ArrivalStation\":\"BOG\",\"FlightCarrier\":\"AV\",\"FlightNumber\":\"8048\",\"Price\":2000},{\"DepartureStation\":\"PER\",\"ArrivalStation\":\"MZL\",\"FlightCarrier\":\"AV\",\"FlightNumber\":\"8049\",\"Price\":2000},{\"DepartureStation\":\"BOG\",\"ArrivalStation\":\"MZL\",\"FlightCarrier\":\"AV\",\"FlightNumber\":\"8049\",\"Price\":2000},{\"DepartureStation\":\"BOG\",\"ArrivalStation\":\"MIA\",\"FlightCarrier\":\"AV\",\"FlightNumber\":\"8050\",\"Price\":6000},{\"DepartureStation\":\"MIA\",\"ArrivalStation\":\"BOG\",\"FlightCarrier\":\"AV\",\"FlightNumber\":\"8051\",\"Price\":6000}]";
                    List<ResponseFligthDto> Fligths = JsonConvert.DeserializeObject<List<ResponseFligthDto>>(data);
                    if (Fligths.Count > 0)
                    {
                        ResponseFligths.AddRange(Fligths);
                    }
                //}
                //else
                //{
                    //Console.WriteLine($"No se pudo realizar la petición: bad");
                //}
                return ResponseFligths;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
