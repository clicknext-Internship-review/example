using System;
using System.Collections.Generic;

namespace example.DataBase.Models
{
    public partial class country
    {
        public country()
        {
            cities = new HashSet<city>();
        }

        public ushort country_id { get; set; }
        public string country1 { get; set; } = null!;
        public DateTime last_update { get; set; }

        public virtual ICollection<city> cities { get; set; }
    }
}
