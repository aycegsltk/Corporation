using System;
using System.Linq;
using System.Threading.Tasks;
using Corporation.Business.Abstract;
using Corporation.Business.DependencyResolvers.Ninject;
using Corporation.Core.Concrete;
using Corporation.DataAccess.Concrete.ADONET;

namespace Corporation.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var empService = InstanceFactory.GetInstance<IEmpService>();
            var rankService = InstanceFactory.GetInstance<IRankService>();
           // empService.Add(new Employee() { Name = "Deniz Bora", RankId = 2, Salary = 15000 });
            empService.GetAll().Join(rankService.GetAll(),
                e=>e.RankId,
                r=>r.RankId,
                (e,r)=>new
                {
                    Id=e.Id,
                    FirstName=e.FirstName,
                    LastName=e.LastName,
                    Salary=e.Salary,
                    Rank=r.RankName
                }).ToList().ForEach(n=>System.Console.WriteLine($"{n.Id,-5}{n.FirstName,-30}{n.LastName,-30}{n.Salary,-15}{n.Rank,-10}"));
        }
    }
}
