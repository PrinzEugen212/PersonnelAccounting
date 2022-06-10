using System.ComponentModel.DataAnnotations.Schema;

namespace PersAccounting.Models.Employees
{
    [Table("DepartmentHeads")]
    public class DepartmentHead : Person
    {
        public string? Department { get; set; }
    }
}
