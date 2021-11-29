using System;
using System.Collections.Generic;

namespace example.DataBase.Models
{
    public partial class film_category
    {
        public ushort film_id { get; set; }
        public byte category_id { get; set; }
        public DateTime last_update { get; set; }

        public virtual category category { get; set; } = null!;
        public virtual film film { get; set; } = null!;
    }
}
