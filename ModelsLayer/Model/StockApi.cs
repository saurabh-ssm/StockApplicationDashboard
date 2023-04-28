﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.Model
{
    public class StockApi
    {
        [Key]
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public int StockPrize { get; set; }
    }
}
