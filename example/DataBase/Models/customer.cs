using System;
using System.Collections.Generic;

namespace example.DataBase.Models
{
    public partial class customer
    {
        public customer()
        {
            payments = new HashSet<payment>();
            rentals = new HashSet<rental>();
        }

        public ushort customer_id { get; set; }
        public byte store_id { get; set; }
        public string first_name { get; set; } = null!;
        public string last_name { get; set; } = null!;
        public string? email { get; set; }
        public ushort address_id { get; set; }
        public bool? active { get; set; }
        public DateTime create_date { get; set; }
        public DateTime? last_update { get; set; }

        public virtual address address { get; set; } = null!;
        public virtual store store { get; set; } = null!;
        public virtual ICollection<payment> payments { get; set; }
        public virtual ICollection<rental> rentals { get; set; }
    }
}
