using System;
using System.Collections.Generic;

namespace example.DataBase.Models
{
    public partial class film_text
    {
        public short film_id { get; set; }
        public string title { get; set; } = null!;
        public string? description { get; set; }
    }
}
