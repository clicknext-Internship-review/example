using System;
using System.Collections.Generic;

namespace example.DataBase.Models
{
    public partial class category
    {
        public category()
        {
            film_categories = new HashSet<film_category>();
        }

        public byte category_id { get; set; }
        public string name { get; set; } = null!;
        public DateTime last_update { get; set; }

        public virtual ICollection<film_category> film_categories { get; set; }
    }
}
