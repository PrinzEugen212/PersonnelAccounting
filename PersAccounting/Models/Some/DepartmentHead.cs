using System.ComponentModel.DataAnnotations.Schema;

namespace PersAccounting.Models
{
    [Table("DepartmentHeads")]
    public class DepartmentHead : Person
    {
        public string? Department { get; set; }
    }
}
