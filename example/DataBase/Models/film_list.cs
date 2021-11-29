using System;
using System.Collections.Generic;

namespace example.DataBase.Models
{
    public partial class film_list
    {
        public ushort? FID { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public string category { get; set; } = null!;
        public decimal? price { get; set; }
        public ushort? length { get; set; }
        public string? rating { get; set; }
        public string? actors { get; set; }
    }
}
