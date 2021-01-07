using Corporation.Core.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Corporation.DataAccess.Abstract
{
    public interface IEmpDal : 
        IEntityRepository<Employee>,IADORepository<Employee>
    {

    }
}
