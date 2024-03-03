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
        public JourneyService(IGenericRepository<Journey> journeyRepo)
        {
         _journeyRepo = journeyRepo;
        }



    }
}
