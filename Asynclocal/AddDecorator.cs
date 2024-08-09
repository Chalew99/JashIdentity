using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#pragma warning disable CS8602 // Dereference of a possibly null reference.

namespace Asynclocal
{
    static class Wrapdecorator
    {

        internal static void AddDecorator<TService>(this IServiceCollection services)
        {
            var registration = services.LastOrDefault(x => x.ServiceType == typeof(TService));
            if (registration == null)
            {
                throw new InvalidOperationException("Service type: " + typeof(TService).Name + " not registered.");
            }
            if (services.Any(x => x.ServiceType == typeof(Decorator<TService>)))
            {
                throw new InvalidOperationException("Decorator already registered for type: " + typeof(TService).Name + ".");
            }

            services.Remove(registration);

            if (registration.ImplementationInstance != null)
            {
                var type = registration.ImplementationInstance.GetType();
                var innerType = typeof(Decorator<,>).MakeGenericType(typeof(TService), type);
                services.Add(new ServiceDescriptor(typeof(Decorator<TService>), innerType, ServiceLifetime.Transient));
                services.Add(new ServiceDescriptor(type, registration.ImplementationInstance));
            }
            else if (registration.ImplementationFactory != null)
            {
                services.Add(new ServiceDescriptor(typeof(Decorator<TService>), provider =>
                {
                    return new DisposableDecorator<TService>((TService) registration.ImplementationFactory(provider));
                }, registration.Lifetime));
            }
            else if (registration.ImplementationType != null)
            {

                var type = registration.ImplementationType;
                var innerType = typeof(Decorator<,>).MakeGenericType(typeof(TService), registration.ImplementationType);
                services.Add(new ServiceDescriptor(typeof(Decorator<TService>), innerType, ServiceLifetime.Transient));
                services.Add(new ServiceDescriptor(type, type, registration.Lifetime));

            }
            else
            {
                throw new InvalidOperationException("Invalid registration in DI for: " + typeof(TService).Name);
            }
        }
    }
}
