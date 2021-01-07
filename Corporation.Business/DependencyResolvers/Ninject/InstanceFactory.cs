using Ninject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Corporation.Business.DependencyResolvers.Ninject
{
    public class InstanceFactory
    {
        public static T GetInstance<T>()
        {
            return new StandardKernel(new BusinessModule()).Get<T>();
        }
    }
}
