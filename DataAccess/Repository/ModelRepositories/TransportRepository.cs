using DataAccess.Repository.Interfaces;
using DataAccess.Repository;
using DataAccess.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.ModelRepositories
{
    public class TransportRepository : IGenericRepository<Transport>
    {
        private readonly NewshoreAirDbContext _dbcontext;

        public TransportRepository(NewshoreAirDbContext context)
        {
            _dbcontext = context;
        }

        public async Task<bool> Delete(Transport model)
        {
            try
            {
                _dbcontext.Transports.Remove(model);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<IQueryable<Transport>> GetAll()
        {
            try
            {
                IQueryable<Transport> QueryTransports = _dbcontext.Transports;
                return QueryTransports;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<Transport> GetById(Guid id)
        {
            try
            {
                return await _dbcontext.Transports.FindAsync(id);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<Transport> Insert(Transport model)
        {
            try
            {
                _dbcontext.Transports.Add(model);
                await _dbcontext.SaveChangesAsync();
                return model;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<List<Transport>> InsertList(List<Transport> model)
        {
            try
            {
                _dbcontext.Transports.AddRange(model);
                await _dbcontext.SaveChangesAsync();
                return model;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<Transport> Update(Transport model)
        {
            try
            {
                _dbcontext.Transports.Update(model);
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
