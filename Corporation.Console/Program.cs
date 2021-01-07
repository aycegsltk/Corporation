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
            empService.GetAll().Join(rankService.GetAll(),
                e=>e.RankId,
                r=>r.RankId,
                (e,r)=>new
                {
                    Id=e.Id,
                    Name=e.Name,
                    Salary=e.Salary,
                    Rank=r.RankName
                }).ToList().ForEach(n=>System.Console.WriteLine($"{n.Id,-5}{n.Name,-15}{n.Salary,-10}{n.Rank,-10}"));
        }
    }
}
