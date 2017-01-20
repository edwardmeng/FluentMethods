using System;
using Microsoft.Extensions.DependencyInjection;

public static partial class Extensions
{
    /// <summary>
    ///     Removes the first service with the same service type if exists.
    ///     and adds a transient service of the type specified in <paramref name="serviceType" />
    ///     with an implementation of the type specified in <paramref name="implementationType" /> to the specified
    ///     <see cref="IServiceCollection" />.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection" /> to replace the service to.</param>
    /// <param name="serviceType">The type of the service to register.</param>
    /// <param name="implementationType">The implementation type of the service.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    public static IServiceCollection ReplaceTransient(this IServiceCollection services, Type serviceType, Type implementationType)
    {
        if (services == null)
            throw new ArgumentNullException(nameof(services));
        if (serviceType == null)
            throw new ArgumentNullException(nameof(serviceType));
        if (implementationType == null)
            throw new ArgumentNullException(nameof(implementationType));
        return Replace(services, serviceType, implementationType, ServiceLifetime.Transient);
    }

    /// <summary>
    ///     Removes the first service with the same service type if exists.
    ///     and adds a transient service of the type specified in <paramref name="serviceType" />
    ///     a factory specified in <paramref name="implementationFactory" /> to the specified
    ///     <see cref="IServiceCollection" />.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection" /> to replace the service to.</param>
    /// <param name="serviceType">The type of the service to register.</param>
    /// <param name="implementationFactory">The factory that creates the service.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    public static IServiceCollection ReplaceTransient(this IServiceCollection services, Type serviceType,
        Func<IServiceProvider, object> implementationFactory)
    {
        if (services == null)
            throw new ArgumentNullException(nameof(services));
        if (serviceType == null)
            throw new ArgumentNullException(nameof(serviceType));
        if (implementationFactory == null)
            throw new ArgumentNullException(nameof(implementationFactory));
        return Replace(services, serviceType, implementationFactory, ServiceLifetime.Transient);
    }

    /// <summary>
    ///     Removes the first service with the same service type if exists.
    ///     and adds a transient service of the type specified in <paramref name="serviceType" /> to the specified
    ///     <see cref="IServiceCollection" />.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection" /> to replace the service to.</param>
    /// <param name="serviceType">The type of the service to register.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    public static IServiceCollection ReplaceTransient(this IServiceCollection services, Type serviceType)
    {
        if (services == null)
            throw new ArgumentNullException(nameof(services));
        if (serviceType == null)
            throw new ArgumentNullException(nameof(serviceType));
        return services.ReplaceTransient(serviceType, serviceType);
    }

    /// <summary>
    ///     Removes the first service with the same <typeparamref name="TService" /> if exists.
    ///     and adds a transient service of the type specified in with an implementation type specified
    ///     in using the factory specified in <paramref name="implementationFactory" /> to the specified
    ///     <see cref="IServiceCollection" />.
    /// </summary>
    /// <typeparam name="TService">The type of the service to add.</typeparam>
    /// <typeparam name="TImplementation">The type of the implementation to use.</typeparam>
    /// <param name="services">The <see cref="IServiceCollection" /> to replace the service to.</param>
    /// <param name="implementationFactory">The factory that creates the service.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    public static IServiceCollection ReplaceTransient<TService, TImplementation>(this IServiceCollection services,
        Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService
    {
        if (services == null)
            throw new ArgumentNullException(nameof(services));
        if (implementationFactory == null)
            throw new ArgumentNullException(nameof(implementationFactory));
        return services.ReplaceTransient(typeof(TService), implementationFactory);
    }

    /// <summary>
    ///     Removes the first service with the same <typeparamref name="TService" /> if exists.
    ///     And adds a transient service of the type specified in with an implementation type to the specified
    ///     <see cref="IServiceCollection" />.
    /// </summary>
    /// <typeparam name="TService">The type of the service to add.</typeparam>
    /// <typeparam name="TImplementation">The type of the implementation to use.</typeparam>
    /// <param name="services">The <see cref="IServiceCollection" /> to replace the service to.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    public static IServiceCollection ReplaceTransient<TService, TImplementation>(this IServiceCollection services) where TService : class
        where TImplementation : class, TService
    {
        if (services == null)
            throw new ArgumentNullException(nameof(services));
        return services.ReplaceTransient(typeof(TService), typeof(TImplementation));
    }

    /// <summary>
    ///     Removes the first service with the same <typeparamref name="TService" /> if exists.
    ///     And adds a transient service of the type specified in to the specified
    ///     <see cref="IServiceCollection" />.
    /// </summary>
    /// <typeparam name="TService">The type of the service to add.</typeparam>
    /// <param name="services">The <see cref="IServiceCollection" /> to replace the service to.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    public static IServiceCollection ReplaceTransient<TService>(this IServiceCollection services) where TService : class
    {
        if (services == null)
            throw new ArgumentNullException(nameof(services));
        return services.ReplaceTransient(typeof(TService));
    }

    /// <summary>
    ///     Removes the first service with the same <typeparamref name="TService" /> if exists.
    ///     and adds a transient service of the type specified in with an implementation type specified
    ///     in using the factory specified in <paramref name="implementationFactory" /> to the specified
    ///     <see cref="IServiceCollection" />.
    /// </summary>
    /// <typeparam name="TService">The type of the service to add.</typeparam>
    /// <param name="services">The <see cref="IServiceCollection" /> to replace the service to.</param>
    /// <param name="implementationFactory">The factory that creates the service.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    public static IServiceCollection ReplaceTransient<TService>(this IServiceCollection services,
        Func<IServiceProvider, TService> implementationFactory) where TService : class
    {
        if (services == null)
            throw new ArgumentNullException(nameof(services));
        if (implementationFactory == null)
            throw new ArgumentNullException(nameof(implementationFactory));
        return services.ReplaceTransient(typeof(TService), implementationFactory);
    }
}