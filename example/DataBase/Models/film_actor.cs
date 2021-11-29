using System;
using System.Collections.Generic;

namespace example.DataBase.Models
{
    public partial class film_actor
    {
        public ushort actor_id { get; set; }
        public ushort film_id { get; set; }
        public DateTime last_update { get; set; }

        public virtual actor actor { get; set; } = null!;
        public virtual film film { get; set; } = null!;
    }
}
