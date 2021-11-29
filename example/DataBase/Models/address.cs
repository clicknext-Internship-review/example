using System;
using System.Collections.Generic;

namespace example.DataBase.Models
{
    public partial class address
    {
        public address()
        {
            customers = new HashSet<customer>();
            staff = new HashSet<staff>();
            stores = new HashSet<store>();
        }

        public ushort address_id { get; set; }
        public string address1 { get; set; } = null!;
        public string? address2 { get; set; }
        public string district { get; set; } = null!;
        public ushort city_id { get; set; }
        public string? postal_code { get; set; }
        public string phone { get; set; } = null!;
        public DateTime last_update { get; set; }

        public virtual city city { get; set; } = null!;
        public virtual ICollection<customer> customers { get; set; }
        public virtual ICollection<staff> staff { get; set; }
        public virtual ICollection<store> stores { get; set; }
    }
}
