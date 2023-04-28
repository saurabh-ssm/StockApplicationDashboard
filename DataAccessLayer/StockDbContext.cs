using Microsoft.EntityFrameworkCore;
using ModelsLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class StockDbContext:DbContext
    {
        public StockDbContext(DbContextOptions<StockDbContext> options):base(options)
        {

        }
        public DbSet<StockApi> Stocks { get; set; }
    }
}
