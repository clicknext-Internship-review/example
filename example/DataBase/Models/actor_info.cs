using System;
using System.Collections.Generic;

namespace example.DataBase.Models
{
    public partial class actor_info
    {
        public ushort actor_id { get; set; }
        public string first_name { get; set; } = null!;
        public string last_name { get; set; } = null!;
        public string? film_info { get; set; }
    }
}
