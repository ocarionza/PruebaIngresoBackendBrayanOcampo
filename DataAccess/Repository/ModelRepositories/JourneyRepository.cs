using PruebaIngresoBackend.Repository.Models;
using PruebaIngresoBackend.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Repository.Interfaces;

namespace DataAccess.Repository.ModelRepositories
{
    public class JourneyRepository : IGenericRepository<Journey>
    {
        private readonly NewshoreAirDbContext _dbcontext;

        public JourneyRepository(NewshoreAirDbContext context)
        {
            _dbcontext = context;
        }

        public async Task<bool> Delete(Journey model)
        {
            try
            {
                _dbcontext.Journeys.Remove(model);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<IQueryable<Journey>> GetAll()
        {
            try
            {
                IQueryable<Journey> QueryJourneys = _dbcontext.Journeys;
                return QueryJourneys;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<Journey> GetById(Guid id)
        {
            try
            {
                return await _dbcontext.Journeys.FindAsync(id);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<Journey> Insert(Journey model)
        {
            try
            {
                _dbcontext.Journeys.Add(model);
                await _dbcontext.SaveChangesAsync();
                return model;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<List<Journey>> InsertList(List<Journey> model)
        {
            try
            {
                _dbcontext.Journeys.AddRange(model);
                await _dbcontext.SaveChangesAsync();
                return model;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<Journey> Update(Journey model)
        {
            try
            {
                _dbcontext.Journeys.Update(model);
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
