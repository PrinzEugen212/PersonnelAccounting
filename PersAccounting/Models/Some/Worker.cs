﻿using System.ComponentModel.DataAnnotations.Schema;

namespace PersAccounting.Models
{
    [Table("Workers")]
    public class Worker : Person
    {
        public int? HeadId { get; set; }
        public DepartmentHead? Head { get; set; }
    }
}
