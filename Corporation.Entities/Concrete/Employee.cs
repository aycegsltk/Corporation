using Corporation.Core.Abstract;
using System;

namespace Corporation.Core.Concrete
{
    public class Employee : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public int RankId { get; set; }
        public override string ToString() =>
            $"{Id,-5} {FirstName,-15} {LastName,-15} {Salary,-15} {RankId,-5}";
    }
}
