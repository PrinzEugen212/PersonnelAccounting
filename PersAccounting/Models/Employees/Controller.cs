using System.ComponentModel.DataAnnotations.Schema;

namespace PersAccounting.Models.Employees
{
    [Table("Controllers")]
    public class Controller : Person
    {
        public int? HeadId { get; set; }
        public DepartmentHead? Head { get; set; }
    }
}
