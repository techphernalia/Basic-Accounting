using Accounting.Model.Abstract;
using Accounting.Model.Concrete;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Accounting.UI.Infrastructure
{
    public class NInjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NInjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<ILedgerRepository>().To<EFLedgerRepository>();
        }
    }
}