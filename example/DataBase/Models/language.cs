using System;
using System.Collections.Generic;

namespace example.DataBase.Models
{
    public partial class language
    {
        public language()
        {
            filmlanguages = new HashSet<film>();
            filmoriginal_languages = new HashSet<film>();
        }

        public byte language_id { get; set; }
        public string name { get; set; } = null!;
        public DateTime last_update { get; set; }

        public virtual ICollection<film> filmlanguages { get; set; }
        public virtual ICollection<film> filmoriginal_languages { get; set; }
    }
}
