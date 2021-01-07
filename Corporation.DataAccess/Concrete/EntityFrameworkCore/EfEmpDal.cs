using Corporation.Core.Concrete;
using Corporation.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Corporation.DataAccess.Concrete.EntityFrameworkCore
{
    public class EfEmpDal : 
        EfRepositoryBase<Employee,CorporationDBContext>,
        IEmpDal
    {
        public List<Employee> GetAll()
        {
            throw new NotImplementedException();
        }

        public Employee Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
