using System;
using System.Collections.Generic;
using System.Text;
using Corporation.Core.Concrete;

namespace Corporation.DataAccess.Abstract
{
    public interface IADORepository<T>
    {
        List<T> GetAll();
        T Get(int id);
    }
}
