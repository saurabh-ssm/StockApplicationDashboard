using ModelsLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.IRepository
{
    public interface IStockRepository
    {
        Task<IEnumerable<StockApi>> GetStockPrices();
        //Task<IEnumerable<StockApi>> GetAllAsync();
        //Task<StockApi> GetByIdAsync(int id);
        Task<StockApi> AddAsync(StockApi stockApi);
        Task<StockApi> UpdateAsync(int id,StockApi stockApi);
        Task<StockApi> DeleteAsync(int id);


    }
}
