using Corporation.Business.Abstract;
using Corporation.Core.Concrete;
using Corporation.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Corporation.Business.Concrete
{
    public class EmpManager : IEmpService
    {
        IEmpDal _empDal;

        public EmpManager(IEmpDal empDal)
        {
            _empDal = empDal;
        }

        public List<Employee> GetAll(Expression<Func<Employee, bool>> filter = null)
        {
            return _empDal.GetAll(filter);
        }

        public Employee Get(Expression<Func<Employee, bool>> filter)
        {
            return _empDal.Get(filter);
        }
        

        public void Add(Employee entity)
        {
            _empDal.Add(entity);
        }

        public void Update(Employee entity)
        {
            _empDal.Update(entity);
        }

        public void Delete(Employee entity)
        {
            _empDal.Delete(entity);
        }
    }
}
