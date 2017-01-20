using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

public static partial class Extensions
{
    private static IServiceCollection Replace(IServiceCollection collection, Type serviceType, Func<IServiceProvider, object> implementationFactory,
        ServiceLifetime lifetime)
    {
        var descriptor = new ServiceDescriptor(serviceType, implementationFactory, lifetime);
        collection.Replace(descriptor);
        return collection;
    }

    private static IServiceCollection Replace(IServiceCollection collection, Type serviceType, Type implementationType, ServiceLifetime lifetime)
    {
        var descriptor = new ServiceDescriptor(serviceType, implementationType, lifetime);
        collection.Replace(descriptor);
        return collection;
    }
}