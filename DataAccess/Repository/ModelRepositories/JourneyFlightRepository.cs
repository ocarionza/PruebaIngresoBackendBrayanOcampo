using DataAccess.Repository.Interfaces;
using PruebaIngresoBackend.Repository;
using PruebaIngresoBackend.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.ModelRepositories
{
    public class JourneyFlightRepository : IGenericRepository<JourneyFlight>
    {
        private readonly NewshoreAirDbContext _dbcontext;

        public JourneyFlightRepository(NewshoreAirDbContext context)
        {
            _dbcontext = context;
        }

        public async Task<bool> Delete(JourneyFlight model)
        {
            try
            {
                _dbcontext.JourneyFlights.Remove(model);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<IQueryable<JourneyFlight>> GetAll()
        {
            try
            {
                IQueryable<JourneyFlight> QueryJourneyFlights = _dbcontext.JourneyFlights;
                return QueryJourneyFlights;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<JourneyFlight> GetById(Guid id)
        {
            try
            {
                return await _dbcontext.JourneyFlights.FindAsync(id);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<JourneyFlight> Insert(JourneyFlight model)
        {
            try
            {
                _dbcontext.JourneyFlights.Add(model);
                await _dbcontext.SaveChangesAsync();
                return model;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<List<JourneyFlight>> InsertList(List<JourneyFlight> model)
        {
            try
            {
                _dbcontext.JourneyFlights.AddRange(model);
                await _dbcontext.SaveChangesAsync();
                return model;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<JourneyFlight> Update(JourneyFlight model)
        {
            try
            {
                _dbcontext.JourneyFlights.Update(model);
                await _dbcontext.SaveChangesAsync();
                return model;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
