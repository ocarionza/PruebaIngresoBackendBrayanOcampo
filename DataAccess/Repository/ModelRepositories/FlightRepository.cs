using DataAccess.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using PruebaIngresoBackend.Repository;
using PruebaIngresoBackend.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.ModelRepositories
{
    public class FlightRepository : IGenericRepository<Fligth>
    {
        private readonly NewshoreAirDbContext _dbcontext;

        public FlightRepository(NewshoreAirDbContext context)
        {
            _dbcontext = context;
        }

        public async Task<bool> Delete(Fligth model)
        {
            try
            {
                _dbcontext.Fligths.Remove(model);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<IQueryable<Fligth>> GetAll()
        {
            try
            {
                IQueryable<Fligth> QueryFlights = _dbcontext.Fligths;
                return QueryFlights;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<Fligth> GetById(Guid id)
        {
            try
            {
                return await _dbcontext.Fligths.FindAsync(id);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<Fligth> Insert(Fligth model)
        {
            try
            {
                _dbcontext.Fligths.Add(model);
                await _dbcontext.SaveChangesAsync();
                return model;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<List<Fligth>> InsertList(List<Fligth> model)
        {
            try
            {
                _dbcontext.Fligths.AddRange(model);
                await _dbcontext.SaveChangesAsync();
                return model;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<Fligth> Update(Fligth model)
        {
            try
            {
                _dbcontext.Fligths.Update(model);
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
