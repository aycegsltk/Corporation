using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Corporation.Business.Abstract;
using Corporation.Core.Concrete;
using Corporation.DataAccess.Abstract;

namespace Corporation.Business.Concrete
{
    public class RankManager : IRankService
    {
        IRankyDal _categoryDal;

        public RankManager(IRankyDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Rank> GetAll(Expression<Func<Rank, bool>> filter = null)
        {
            return _categoryDal.GetAll(filter);
        }

        public Rank Get(Expression<Func<Rank, bool>> filter)
        {
            return _categoryDal.Get(filter);
        }

        public void Add(Rank entity)
        {
            _categoryDal.Add(entity);
        }

        public void Update(Rank entity)
        {
            _categoryDal.Update(entity);
        }

        public void Delete(Rank entity)
        {
            _categoryDal.Delete(entity);
        }
    }
}