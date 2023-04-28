using DataAccessLayer.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using ModelsLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly StockDbContext _db;
        public StockRepository(StockDbContext db)
        {
            _db = db;
        }

        public async Task<StockApi> AddAsync(StockApi stockApi)
        {
            var data=new StockApi()
            {
                Id=stockApi.Id,  
                CompanyName=stockApi.CompanyName,
                StockPrize=stockApi.StockPrize,
            };
            await _db.Stocks.AddAsync(data);    
            await _db.SaveChangesAsync();
            return data;
        }

        public async Task<StockApi> DeleteAsync(int id)
        {
            var data=await _db.Stocks.FirstOrDefaultAsync(x=>x.Id==id);
            if(id== null)
            {
                return null;
            }
            _db.Stocks.Remove(data);
            await _db.SaveChangesAsync();
            return data;
        }

        //public async Task<IEnumerable<StockApi>> GetAllAsync()
        //{
        //    var allstocks=await _db.Stocks.ToListAsync();
        //    return allstocks;
        //}

        //public async Task<StockApi> GetByIdAsync(int id)
        //{
        //    var data = await _db.Stocks.FirstOrDefaultAsync(x => x.Id == id);
        //    if(id==null)
        //    {
        //        return null;
        //    }
        //    return data;
        //}

        public async Task<IEnumerable<StockApi>> GetStockPrices()
        {
            var stockPrices = await _db.Stocks.FromSqlRaw("EXECUTE UpdateStockPrice").ToListAsync();

            return (stockPrices);
        }

        public async Task<StockApi> UpdateAsync(int id, StockApi stockApi)
        {
            var data=await _db.Stocks.FirstOrDefaultAsync(x=>x.Id== id);    
            if(id==null)
            {
                return null;
            }
            data.Id=stockApi.Id;
            data.CompanyName=stockApi.CompanyName;
            data.StockPrize=stockApi.StockPrize;    
            await _db.SaveChangesAsync();
            return data;

        }
    }
}
