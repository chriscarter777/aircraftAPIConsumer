using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using System.Web.Mvc;
using AircraftAPIConsumer.DAL;

namespace AircraftAPIConsumer.DAL
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kern)
        {
            kernel = kern;
            AddBindings();
        }

        public IEnumerable<object> GetServices(Type svcType)
        {
            return kernel.GetAll(svcType);
        }

        public object GetService(Type svcType)
        {
            return kernel.TryGet(svcType);
        }

        private void AddBindings()
        {
            kernel.Bind<IAircraftRepository>().To<AircraftRepository>();
        }
    }
}