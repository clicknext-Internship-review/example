using System;
using System.Collections.Generic;

namespace example.DataBase.Models
{
    public partial class actor
    {
        public actor()
        {
            film_actors = new HashSet<film_actor>();
        }

        public ushort actor_id { get; set; }
        public string first_name { get; set; } = null!;
        public string last_name { get; set; } = null!;
        public DateTime last_update { get; set; }

        public virtual ICollection<film_actor> film_actors { get; set; }
    }
}
