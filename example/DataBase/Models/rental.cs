using System;
using System.Collections.Generic;

namespace example.DataBase.Models
{
    public partial class rental
    {
        public rental()
        {
            payments = new HashSet<payment>();
        }

        public int rental_id { get; set; }
        public DateTime rental_date { get; set; }
        public uint inventory_id { get; set; }
        public ushort customer_id { get; set; }
        public DateTime? return_date { get; set; }
        public byte staff_id { get; set; }
        public DateTime last_update { get; set; }

        public virtual customer customer { get; set; } = null!;
        public virtual inventory inventory { get; set; } = null!;
        public virtual staff staff { get; set; } = null!;
        public virtual ICollection<payment> payments { get; set; }
    }
}
