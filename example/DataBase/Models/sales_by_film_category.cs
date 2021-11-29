using System;
using System.Collections.Generic;

namespace example.DataBase.Models
{
    public partial class sales_by_film_category
    {
        public string category { get; set; } = null!;
        public decimal? total_sales { get; set; }
    }
}
