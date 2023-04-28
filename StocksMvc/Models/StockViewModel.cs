using MessagePack;
using System.ComponentModel.DataAnnotations;

namespace StocksMvc.Models
{
    public class StockViewModel
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public int StockPrize { get; set; }
    }
}
