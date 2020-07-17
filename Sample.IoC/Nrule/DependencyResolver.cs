using Microsoft.Extensions.DependencyInjection;
using NRules.Extensibility;
using System;

namespace Sample.IoC.Nrule
{
    public class DependencyResolver : IDependencyResolver
    {
        private readonly IServiceProvider _container;

        public DependencyResolver(IServiceProvider serviceProvider)
        {
            _container = serviceProvider;
        }
        public object Resolve(IResolutionContext context, Type serviceType)
        {
            return _container.GetRequiredService(serviceType);
        }
    }
}
