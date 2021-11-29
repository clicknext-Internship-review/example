using System;
using System.Collections.Generic;

namespace example.DataBase.Models
{
    public partial class inventory
    {
        public inventory()
        {
            rentals = new HashSet<rental>();
        }

        public uint inventory_id { get; set; }
        public ushort film_id { get; set; }
        public byte store_id { get; set; }
        public DateTime last_update { get; set; }

        public virtual film film { get; set; } = null!;
        public virtual store store { get; set; } = null!;
        public virtual ICollection<rental> rentals { get; set; }
    }
}
