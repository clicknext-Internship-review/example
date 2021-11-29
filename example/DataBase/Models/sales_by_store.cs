using System;
using System.Collections.Generic;

namespace example.DataBase.Models
{
    public partial class sales_by_store
    {
        public string? store { get; set; }
        public string? manager { get; set; }
        public decimal? total_sales { get; set; }
    }
}
