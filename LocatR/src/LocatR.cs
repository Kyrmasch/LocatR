
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Configuration;
using System.IO.Ports;
using System.Reflection;
using System.Security.Policy;
using System.ComponentModel;
using Unity.Lifetime;
using LocatR;
using Microsoft.Practices.Unity;

namespace LocatR
{
    public class LocatR : ILocatR
    {
        private readonly IUnityContainer _container;
        public LocatR(IUnityContainer container)
        {
            _container = container;

            var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                .Where(p => p.GetInterfaces().Where(
                        x => x.GetInterfaces().Any(
                            b => b == typeof(IBaseRequestHandler)
                            )
                        ).Any());


            var hendlers = types.Where(a => !a.IsAbstract && !a.IsInterface)                    
                    .Select(a => new { RType = a, RService = a.GetInterfaces().ToList() })
                    .ToList();

            foreach (var handle in hendlers)
            {
                _container.RegisterType(
                    handle.RService.FirstOrDefault(),
                    handle.RType,
                    handle.RType.Name
                );
            }
        }

        public async Task SendCommand<T1>(T1 responce, CancellationToken cancellationToken = default)
        {
            IEnumerable<IRequestHandler<T1>> instances = _container.ResolveAll<IRequestHandler<T1>>();
            foreach (IRequestHandler<T1> instance in instances)
                await instance.Handle(responce, default);
        }

        public async Task<T2> SendQuery<T1, T2>(T1 responce, CancellationToken cancellationToken = default(CancellationToken))
        {
            IEnumerable<IRequestHandler<T1, T2>> instances = _container.ResolveAll<IRequestHandler<T1, T2>>();
            if (instances.Any())
                return await instances.LastOrDefault().Handle(responce, default);

            return default(T2);
        }

    }
}
