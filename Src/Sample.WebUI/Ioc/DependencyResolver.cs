using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lib.SimpleCqrs.Extended;
using Ninject;

namespace Sample.WebUI.Ioc
{
    public class DependencyResolver : IDependencyResolver
    {
        private readonly IKernel _kernel;

        public DependencyResolver(IKernel kernel)
        {
            _kernel = kernel;
        }

        public T Get<T>()
        {
            return _kernel.Get<T>();
        }

        public IEnumerable<T> GetAll<T>()
        {
            return _kernel.GetAll<T>();
        }
    }
}