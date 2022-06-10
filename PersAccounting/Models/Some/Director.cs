using System.ComponentModel.DataAnnotations.Schema;

namespace PersAccounting.Models
{
    [Table("Directors")]
    public class Director : Person
    {
        public string? Post { get; set; }
    }
}
