using System;
using System.Collections.Generic;

namespace example.DataBase.Models
{
    public partial class customer_list
    {
        public ushort ID { get; set; }
        public string? name { get; set; }
        public string address { get; set; } = null!;
        public string? zip_code { get; set; }
        public string phone { get; set; } = null!;
        public string city { get; set; } = null!;
        public string country { get; set; } = null!;
        public string notes { get; set; } = null!;
        public byte SID { get; set; }
    }
}
