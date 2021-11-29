using System;
using System.Collections.Generic;

namespace example.DataBase.Models
{
    public partial class payment
    {
        public ushort payment_id { get; set; }
        public ushort customer_id { get; set; }
        public byte staff_id { get; set; }
        public int? rental_id { get; set; }
        public decimal amount { get; set; }
        public DateTime payment_date { get; set; }
        public DateTime? last_update { get; set; }

        public virtual customer customer { get; set; } = null!;
        public virtual rental? rental { get; set; }
        public virtual staff staff { get; set; } = null!;
    }
}
