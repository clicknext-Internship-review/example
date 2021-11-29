using System;
using System.Collections.Generic;

namespace example.DataBase.Models
{
    public partial class store
    {
        public store()
        {
            customers = new HashSet<customer>();
            inventories = new HashSet<inventory>();
            staff = new HashSet<staff>();
        }

        public byte store_id { get; set; }
        public byte manager_staff_id { get; set; }
        public ushort address_id { get; set; }
        public DateTime last_update { get; set; }

        public virtual address address { get; set; } = null!;
        public virtual staff manager_staff { get; set; } = null!;
        public virtual ICollection<customer> customers { get; set; }
        public virtual ICollection<inventory> inventories { get; set; }
        public virtual ICollection<staff> staff { get; set; }
    }
}
