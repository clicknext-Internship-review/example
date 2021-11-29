using System.ComponentModel.DataAnnotations;

namespace example.ViewModels
{
    public class BaseParam
    {
        [Required]
        public string first_name { get; set; }
        [Required]
        public string last_name { get; set; }

    }
    public class InsertParam : BaseParam { }
    public class UpdateParam : BaseParam { public int id { get; set; } }
}
