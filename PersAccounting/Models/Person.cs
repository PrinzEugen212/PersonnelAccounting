using System;

namespace PersAccounting.Models
{
    public abstract class Person
    {
        public virtual int Id { get; set; }
        public virtual string? Name { get; set; }
        public virtual string? Surname { get; set; }
        public virtual string? Patronymic { get; set; }
        public virtual DateTime BirthDate { get; set; }
        public virtual string? Gender { get; set; }
    }
}
