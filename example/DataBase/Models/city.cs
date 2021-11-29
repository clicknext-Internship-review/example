using System;
using System.Collections.Generic;

namespace example.DataBase.Models
{
    public partial class city
    {
        public city()
        {
            addresses = new HashSet<address>();
        }

        public ushort city_id { get; set; }
        public string city1 { get; set; } = null!;
        public ushort country_id { get; set; }
        public DateTime last_update { get; set; }

        public virtual country country { get; set; } = null!;
        public virtual ICollection<address> addresses { get; set; }
    }
}
