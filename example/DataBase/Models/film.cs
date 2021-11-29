using System;
using System.Collections.Generic;

namespace example.DataBase.Models
{
    public partial class film
    {
        public film()
        {
            film_actors = new HashSet<film_actor>();
            film_categories = new HashSet<film_category>();
            inventories = new HashSet<inventory>();
        }

        public ushort film_id { get; set; }
        public string title { get; set; } = null!;
        public string? description { get; set; }
        public short? release_year { get; set; }
        public byte language_id { get; set; }
        public byte? original_language_id { get; set; }
        public byte rental_duration { get; set; }
        public decimal rental_rate { get; set; }
        public ushort? length { get; set; }
        public decimal replacement_cost { get; set; }
        public string? rating { get; set; }
        public DateTime last_update { get; set; }

        public virtual language language { get; set; } = null!;
        public virtual language? original_language { get; set; }
        public virtual ICollection<film_actor> film_actors { get; set; }
        public virtual ICollection<film_category> film_categories { get; set; }
        public virtual ICollection<inventory> inventories { get; set; }
    }
}
