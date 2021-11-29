using System;
using System.Collections.Generic;

namespace example.DataBase.Models
{
    public partial class staff
    {
        public staff()
        {
            payments = new HashSet<payment>();
            rentals = new HashSet<rental>();
        }

        public byte staff_id { get; set; }
        public string first_name { get; set; } = null!;
        public string last_name { get; set; } = null!;
        public ushort address_id { get; set; }
        public byte[]? picture { get; set; }
        public string? email { get; set; }
        public byte store_id { get; set; }
        public bool? active { get; set; }
        public string username { get; set; } = null!;
        public string? password { get; set; }
        public DateTime last_update { get; set; }

        public virtual address address { get; set; } = null!;
        public virtual store store { get; set; } = null!;
        public virtual store storeNavigation { get; set; } = null!;
        public virtual ICollection<payment> payments { get; set; }
        public virtual ICollection<rental> rentals { get; set; }
    }
}
