using Corporation.Business.Abstract;
using Corporation.Business.Concrete;
using Corporation.DataAccess.Abstract;
using Corporation.DataAccess.Concrete.EntityFrameworkCore;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace Corporation.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRankService>().To<RankManager>().InSingletonScope();
            Bind<IRankDal>().To<EfRankDal>().InSingletonScope();
            Bind<IEmpService>().To<EmpManager>().InSingletonScope();
            Bind<IEmpDal>().To<EfEmpDal>().InSingletonScope();
        }
    }
}
