using System;
using System.Collections.Generic;
using System.Text;
using Corporation.Core.Concrete;
using Corporation.DataAccess.Abstract;

namespace Corporation.DataAccess.Concrete.EntityFrameworkCore
{
    public class EfRankDal : EfRepositoryBase<Rank, CorporationDBContext>, IRankyDal
    {

    }
}
