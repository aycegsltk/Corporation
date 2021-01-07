using Corporation.Core.Abstract;
using System;

namespace Corporation.Core.Concrete
{
    public class Employee : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public int RankId { get; set; }
        public override string ToString() =>
            $"{Id,-5} {Name,-35} {Salary,-15}{RankId,-5}";
    }
}
